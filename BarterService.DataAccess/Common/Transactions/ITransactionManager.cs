using System.Data;

namespace BarterService.DataAccess.Common.Transactions
{
    public interface ITransactionManager
    {
        void BeginTransaction();

        void BeginTransaction(IsolationLevel isoLevel);

        void Commit();

        void Rollback();
    }
}
