using System;
using BasrterService.Model.Objects;

namespace BarterService.Business.Managers
{
    public class TransactionManager
    {
        public void Create(ScoreAccount from, ScoreAccount to, decimal ammount)
        {
            var tr = new ScoreTransaction();

            from.Ammount -= ammount;
            to.Ammount += ammount;

            tr.FromScoreAccount = from;
            tr.ToScoreAccount = to;
            tr.Ammount = ammount;
            tr.Date = DateTime.Now;
        }
    }
}
