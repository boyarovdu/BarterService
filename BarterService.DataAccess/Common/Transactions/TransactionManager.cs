using System;
using System.Data;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Common.Transactions
{
    public class TransactionManager : ITransactionManager
    {
        [Dependency]
        public IContext Context { get; set; }

        public void BeginTransaction()
        {
            Context.BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel isoLevel)
        {
            Context.BeginTransaction(isoLevel);
        }

        public void Commit()
        {
            Context.Commit();
        }

        public void Rollback()
        {
            Context.Rollback();
        }
    }
}
