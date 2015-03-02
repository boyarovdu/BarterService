using System.Data.Entity.ModelConfiguration;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Mapping
{
    public class AccountMap : EntityTypeConfiguration<ScoreAccount>
    {
        public AccountMap()
        {
            HasRequired(a => a.User);

            //MapToStoredProcedures();
        }
    }
}
