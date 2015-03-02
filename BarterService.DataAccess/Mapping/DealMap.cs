using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    public class DealMap : EntityTypeConfiguration<Deal>
    {
        public DealMap()
        {
            HasRequired(d => d.Consumer);
            HasRequired(d => d.Seller);
            HasRequired(d => d.Weal);
            Property(d => d.Date).IsRequired();
        }
    }
}