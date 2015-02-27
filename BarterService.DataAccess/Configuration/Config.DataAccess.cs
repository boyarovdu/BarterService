using BarterService.Common;
using BarterService.DataAccess.Common;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Configuration
{
    public class DataAccessConfigurationExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            AppContainer.Current.RegisterType<IContext, BarterServiceContext>();
        }
    }
}
