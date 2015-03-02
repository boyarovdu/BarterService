using System;

namespace BarterService.DataAccess.Procedures.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DbProcedureParameter : Attribute
    {
        public string ParameterName { get; set; }

        public DbProcedureParameter(string parameterName)
        {
            ParameterName = parameterName;
        }
    }
}
