using BasrterService.Model.Common;

namespace BarterService.DataAccess.Common
{
    public interface IUnitOfWork
    {
        void Save();

        Repository<T> Repository<T>() where T : BaseEntity;
    }
}
