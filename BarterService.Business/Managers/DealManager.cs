using BasrterService.Model.Objects;

namespace BarterService.Business.Managers
{
    public class DealManager
    {
        public DealManager(TransactionManager transactionManager)
        {
            TransactionManager = transactionManager;
        }

        TransactionManager TransactionManager { get; set; }

        public long Create(Deal deal)
        {
            // This must be transaction
            TransactionManager.Create(deal.FromAccount, deal.ToAccount, deal.Ammount);

            return deal.Id;
        }
    }
}
