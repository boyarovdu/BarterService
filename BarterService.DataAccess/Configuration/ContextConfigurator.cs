using BarterService.DataAccess.Common;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Configuration
{
    public class ContextConfigurationExtension : UnityContainerExtension, IContextConfigurator
    {
        protected override void Initialize()
        {
            Container.RegisterType<IContext, BarterServiceContext>(
               new InjectionFactory(c => new BarterServiceContext(UseStoredProcedures)));
        }

        public bool UseStoredProcedures { get; set; }
    }
}
