using System;
using System.Collections.Generic;
using System.Data.Entity;
using BasrterService.Model.Common;

namespace BarterService.DataAccess.Common
{
    public interface IContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        void Save();

        IEnumerable<T> ManagedEntites<T>();
    }
}
