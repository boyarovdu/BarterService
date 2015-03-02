using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace BarterService.Common
{
    public class AppContainer
    {
        public IUnityContainer Current
        {
            get { return ServiceLocator.Current.GetInstance<IUnityContainer>(); }
        }

        public static void InitServices(UnityContainerExtension initialization)
        {
            var container = new UnityContainer();
            var configSource = ConfigurationSourceFactory.Create();
            container.RegisterType<IConfigurationSource>(new InjectionFactory(c => configSource));
            container.AddExtension(initialization);
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }
    }
}
