using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    class RatingMap : EntityTypeConfiguration<Rating>
    {
        public RatingMap()
        {
            HasRequired(r => r.User);
        }
    }
}
