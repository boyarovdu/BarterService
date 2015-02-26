using System.Collections.Generic;

namespace BarterService.DataAccess.Common
{
    public interface IEntityRepository<TEntity>
    {
        TEntity GetById(long id);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        void Insert(TEntity entity);

        IList<TEntity> All();
    }
}
