using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using BarterService.DataAccess.Procedures.Common;

namespace BarterService.DataAccess.Extensions
{
    public static class DatabaseExtensions
    {
        public static IEnumerable<TResult> ExecuteStoredProcedure<TResult>(this Database database, IStoredProcedure<TResult> procedure)
        {
            var parameters = CreateSqlParametersFromProperties(procedure);
            var format = CreateSpCommand(parameters, procedure);
            return database.SqlQuery<TResult>(format, parameters.Cast<object>().ToArray());
        }

        private static List<SqlParameter> CreateSqlParametersFromProperties<TResult>(IStoredProcedure<TResult> procedure)
        {
            var procedureType = procedure.GetType();
            var propertiesOfProcedure = procedureType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var parameters = new List<SqlParameter>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var prop in propertiesOfProcedure)
            {
                var paramAttributes = prop.GetCustomAttribute<DbProcedureParameter>();
                var paramName = paramAttributes != null ? paramAttributes.ParameterName : prop.Name;

                parameters.Add(new SqlParameter(string.Format("@{0}", paramName), prop.GetValue(procedure, new object[] { })));
            }

            return parameters;
        }

        private static string CreateSpCommand<TResult>(List<SqlParameter> parameters, IStoredProcedure<TResult> procedure)
        {
            var procType = procedure.GetType();
            var procAttributes = procType.GetCustomAttribute<DbProcedure>();

            string name = procAttributes != null ? procAttributes.ProcName : procType.Name;

            string queryString = string.Format("sp_{0}", name);
            parameters.ForEach(x => queryString = string.Format("{0} {1},", queryString, x.ParameterName));

            return queryString.TrimEnd(',');
        }
    }

    // ReSharper disable once UnusedTypeParameter
    public interface IStoredProcedure<TResult>
    {
    }
}