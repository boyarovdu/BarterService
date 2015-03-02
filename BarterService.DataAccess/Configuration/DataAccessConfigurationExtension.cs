using BarterService.DataAccess.Common;
using BarterService.DataAccess.Common.Transactions;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Configuration
{
    public class DataAccessConfigurationExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IContext, BarterServiceContext>();
            Container.RegisterType<ITransactionManager, TransactionManager>();
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType(typeof(IEntityRepository<>), typeof(Repository<>));
        }
    }
}
