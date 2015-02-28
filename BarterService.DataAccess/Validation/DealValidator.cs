using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using BarterService.DataAccess.Validation.Common;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Validation
{
    internal class DealValidator : EntityValidator<Deal>
    {
        public override void Validate(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            AddError("Test", "Test message");
        }
    }
}
