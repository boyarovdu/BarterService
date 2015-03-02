using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    class ScoreAccountMap : EntityTypeConfiguration<ScoreAccount>
    {
        public ScoreAccountMap()
        {
            //HasRequired(a => a.User);
        }
    }
}
