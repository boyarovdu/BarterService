using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using BarterService.DataAccess.Common.Transactions;
using BarterService.DataAccess.Extensions;
using BasrterService.Model.Common;

namespace BarterService.DataAccess.Common
{
    public interface IContext : IDisposable, ITransactionManager
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        void Save();

        IEnumerable<TResult> ExecuteEnumerable<TResult>(IStoredProcedure<TResult> procedure);

        TResult ExecuteScalar<TResult>(IStoredProcedure<TResult> procedure);

        int ExecuteNonQuery(IStoredProcedure<int> procedure);
    }
}
