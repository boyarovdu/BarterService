using BarterService.DataAccess.Extensions;
using BarterService.DataAccess.Procedures.Common;
using BarterService.DataAccess.Procedures.Projections;

namespace BarterService.DataAccess.Procedures
{
    [DbProcedure("users_getdetails")]
    public class SpUsersGetDetails : IStoredProcedure<UserDetailsProjection>
    {
        [DbProcedureParameter("user_id")]
        public long UserId { get; set; }
    }
}
