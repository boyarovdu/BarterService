using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            Property(c => c.Content)
                .IsMaxLength()
                .IsUnicode();
            HasRequired(c => c.Weal);
            HasRequired(c => c.Author);
        }
    }
}
