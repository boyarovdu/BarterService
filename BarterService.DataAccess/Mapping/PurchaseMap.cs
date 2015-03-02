using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    class PurchaseMap : EntityTypeConfiguration<Purchase>
    {
        public PurchaseMap()
        {
            Property(p => p.Ammount).IsRequired();
            HasRequired(p => p.ScoreTransaction);
        }
    }
}
