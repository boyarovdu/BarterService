using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    public class DealMap : EntityTypeConfiguration<Deal>
    {
        public DealMap()
        {
            HasKey(t => t.Id);
            //Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(t => t.Title).IsRequired();
            //Property(t => t.Author).IsRequired();
            //Property(t => t.ISBN).IsRequired();
            //Property(t => t.Published).IsRequired();
            //ToTable("Books");
        }
    }
}