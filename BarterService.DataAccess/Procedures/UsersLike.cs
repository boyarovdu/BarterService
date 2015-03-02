using BarterService.DataAccess.Extensions;
using BarterService.DataAccess.Procedures.Common;

namespace BarterService.DataAccess.Procedures
{
    // ReSharper disable once InconsistentNaming

    [DbProcedure("users_get_names")]
    public class UsersLike : IStoredProcedure<string>
    {
        [DbProcedureParameter("name")]
        public string NameLike { get; set; }
    }
}
