using BarterService.DataAccess.Common;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Configuration
{
    public class DataAccessConfigurationExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<ContextConfigurationExtension>()
                .Configure<IContextConfigurator>()
                .UseStoredProcedures = true;

            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType(typeof(IEntityRepository<>), typeof(Repository<>));
        }
    }
}
