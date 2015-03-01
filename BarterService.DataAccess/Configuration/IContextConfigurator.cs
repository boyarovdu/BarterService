using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Configuration
{
    public interface IContextConfigurator : IUnityContainerExtensionConfigurator
    {
        bool UseStoredProcedures { get; set; }
    }
}
