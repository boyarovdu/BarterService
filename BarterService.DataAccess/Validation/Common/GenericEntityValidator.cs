using BasrterService.Model.Common;

namespace BarterService.DataAccess.Validation.Common
{
    internal abstract class EntityValidator<TEntity> : EntityValidator 
        where TEntity : BaseEntity 
    { 
    }
}
