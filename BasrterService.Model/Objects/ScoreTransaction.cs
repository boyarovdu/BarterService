using System.ComponentModel.DataAnnotations;
using BasrterService.Model.Common;

namespace BasrterService.Model.Objects
{
    public class ScoreTransaction : BaseEntity
    {
        public ScoreAccount FromAccount { get; set; }

        public ScoreAccount ToAccount { get; set; }

        public decimal Ammount { get; set; }
    }
}
