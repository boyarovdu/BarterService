using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    class FeedbackDeal : EntityTypeConfiguration<Feedback>
    {
        public FeedbackDeal()
        {
            Property(f => f.Rating).IsRequired();
            Property(f => f.Content)
                .IsMaxLength()
                .IsUnicode();
            HasRequired(f => f.Deal);
        }
    }
}
