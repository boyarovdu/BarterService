using System;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class ScoreTransaction : BaseEntity
    {
        public ScoreAccount FromScoreAccount { get; set; }

        public ScoreAccount ToScoreAccount { get; set; }

        public decimal Ammount { get; set; }

        public DateTime Date { get; set; }

        public Purchase Purchase { get; set; }
    }
}
