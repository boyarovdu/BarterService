using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using BarterService.DataAccess.Common;
using BarterService.DataAccess.Common.EF.Data;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Configuration
{
    public class EfRepositoryExtension : UnityContainerExtension, IEfRepositoryExtension
    {
        //private ContextBuilder<ObjectContext> _builder;
        private DbModelBuilder _modelBuilder;
        private SqlConnection _connection;

        protected override void Initialize()
        {
            _modelBuilder = new DbModelBuilder();//ContextBuilder<ObjectContext>();
            Container.RegisterInstance("builder", _modelBuilder, new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof(IEntityRepository<>), typeof(Repository<>));
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
        }

        public IEfRepositoryExtension WithConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            return this;
        }

        public IEfRepositoryExtension ConfigureEntity<T>(EntityTypeConfiguration<T> config) where T:class 
        {
            //simple pluralization of the entity set
            ConfigureEntity(config, typeof(T).Name + "s");
            return this;
        }

        public IEfRepositoryExtension ConfigureEntity<T>(EntityTypeConfiguration<T> config, string setName) where T : class 
        {
            _modelBuilder.Configurations.Add(config);
            return this;
        }

        public IEfRepositoryExtension WithContextLifetime(LifetimeManager lifetimeManager)
        {
            //Container.AddNewExtension<StaticFactoryExtension>();
            //Container.Configure<IStaticFactoryConfiguration>()
            //         .RegisterFactory<IObjectContext>(x =>
            //             ContextResolver(x, lifetimeManager, _connection));

            return this;
        }

        //factory func to build context with given lifetime & connection
        static readonly Func<IUnityContainer, LifetimeManager, SqlConnection, object>
            ContextResolver = (c, l, s) => null;
    }
}