using System.Data.Entity.ModelConfiguration;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Configuration
{
    public interface IEfRepositoryExtension : IUnityContainerExtensionConfigurator
    {
        IEfRepositoryExtension WithConnection(string connectionString);
        
        IEfRepositoryExtension WithContextLifetime(LifetimeManager lifetimeManager);

        IEfRepositoryExtension ConfigureEntity<T>(EntityTypeConfiguration<T> config) where T : class;

        IEfRepositoryExtension ConfigureEntity<T>(EntityTypeConfiguration<T> config, string setName) where T : class;
    }
}
