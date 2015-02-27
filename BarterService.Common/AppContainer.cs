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
            container.AddExtension(initialization);
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }
    }
}
