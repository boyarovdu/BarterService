using BarterService.DataAccess.Configuration;
using Microsoft.Practices.Unity;

namespace Initialization.Common
{
    public class InitializationContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddExtension(new DataAccessConfigurationExtension());
        }
    }
}
