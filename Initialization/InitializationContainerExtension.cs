using BarterService.Common;
using BarterService.DataAccess.Configuration;
using Microsoft.Practices.Unity;

namespace Initialization
{
    public class InitializationContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            AppContainer.Current.AddExtension(new DataAccessConfigurationExtension());
        }
    }
}
