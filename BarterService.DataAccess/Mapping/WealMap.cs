using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    class WealMap : EntityTypeConfiguration<Weal>
    {
        public WealMap()
        {
            HasRequired(w => w.Owner);
            Property(w => w.Title)
                .IsRequired()
                .IsUnicode()
                .IsVariableLength()
                .HasMaxLength(300);

            Property(w => w.Description)
                .IsUnicode()
                .IsVariableLength()
                .IsMaxLength();
        }
    }
}
