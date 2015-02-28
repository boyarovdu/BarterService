using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace BarterService.DataAccess.Validation.Common
{
    internal abstract class EntityValidator
    {
        protected EntityValidator()
        {
            Errors = new List<DbValidationError>();
        }

        protected void AddError(string propertyName, string errorMessage)
        {
            Errors.Add(new DbValidationError(propertyName, errorMessage));
        }

        public ICollection<DbValidationError> Errors { get; private set; }

        public abstract void Validate(DbEntityEntry entityEntry, IDictionary<object, object> items);
    }
}
