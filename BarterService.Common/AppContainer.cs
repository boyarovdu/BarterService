using Microsoft.Practices.Unity;

namespace BarterService.Common
{
    public class AppContainer
    {
        static AppContainer()
        {
            Current = new UnityContainer();
        }

        public static IUnityContainer Current { get; set; }
    }
}
