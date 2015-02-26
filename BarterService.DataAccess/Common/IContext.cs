using System;
using System.Collections.Generic;
using System.Data.Entity;
using BasrterService.Model.Common;

namespace BarterService.DataAccess.Common
{
    public interface IContext : IDisposable
    {
        //IDbSet<User> Users { get; }

        //IDbSet<Weal> Weals { get; }

        //IDbSet<Deal> Deals { get; }

        //IDbSet<Account> Accounts { get; }

        //IDbSet<Service> Services { get; }

        //IDbSet<Goods> Goodses { get; }

        //IDbSet<Transaction> Transaction { get; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        string Save();

        IEnumerable<T> ManagedEntites<T>();

        bool ValidateBeforeSave(out string validationErrors);
    }
}
