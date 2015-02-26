using System;
using BasrterService.Model.Objects;

namespace BarterService.Business.Managers
{
    public class TransactionManager
    {
        public void Create(Account from, Account to, decimal ammount)
        {
            var tr = new Transaction();

            from.Ammount -= ammount;
            to.Ammount += ammount;

            tr.FromAccount = from;
            tr.ToAccount = to;
            tr.Ammount = ammount;
            tr.Date = DateTime.Now;
        }
    }
}
