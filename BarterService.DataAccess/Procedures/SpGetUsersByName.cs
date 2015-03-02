using BarterService.DataAccess.Extensions;
using BarterService.DataAccess.Procedures.Common;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Procedures
{
    // ReSharper disable once InconsistentNaming

    [DbProcedure("get_users")]
    public class SpGetUsersByName : IStoredProcedure<User>
    {
        [DbProcedureParameter("name")]
        public string Name { get; set; }
    }
}
