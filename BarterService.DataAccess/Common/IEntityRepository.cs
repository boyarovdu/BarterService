using System.Collections.Generic;
using System.Linq;

namespace BarterService.DataAccess.Common
{
    public interface IEntityRepository<TEntity>
    {
        TEntity GetById(long id);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        void Insert(TEntity entity);

        IQueryable<TEntity> All();
    }
}
