using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    class ScoreTransactionMap : EntityTypeConfiguration<ScoreTransaction>
    {
        public ScoreTransactionMap()
        {
            HasRequired(t => t.FromAccount);
            HasRequired(t => t.ToAccount);
        }
    }
}
