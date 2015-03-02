using BasrterService.Model.Common;

namespace BarterService.DataAccess.Common
{
    public interface IUnitOfWork
    {
        void Save();

        IEntityRepository<T> Repository<T>() where T : BaseEntity;
    }
}
