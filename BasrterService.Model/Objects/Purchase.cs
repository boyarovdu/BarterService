using System.ComponentModel.DataAnnotations;

namespace BasrterService.Model.Objects
{
    public class Purchase : Deal
    {
        public decimal Ammount { get; set; }

        public ScoreTransaction ScoreTransaction { get; set; }
    }
}
