using System;
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
        private SqlConnection _connection;

        protected override void Initialize()
        {
            //_builder = new ContextBuilder<ObjectContext>();
            //register the builder instance as a singleton, this will hold all of our 
            //mapping information for the duration of our application as it creates 
            //new data contexts
            //Container.RegisterInstance("builder", _builder,
            //                           new ContainerControlledLifetimeManager());

            //Register Repo & UOW. Those these are transient instances, they both take
            //a ctor dependency on the ObjectContext which has its lifetime controlled
            //by the Extension. E.g., for an Http current request, all repository and
            //UOW will use the same context/transaction
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
            //add the configuration
            //_builder.Configurations.Add(config);
            ////register the set metadata
            //_builder.RegisterSet<T>(setName);
            //return this;

            throw  new NotImplementedException();
        }

        public IEfRepositoryExtension WithContextLifetime(LifetimeManager lifetimeManager)
        {
            //Container.AddNewExtension<StaticFactoryExtension>();
            //Container.Configure<IStaticFactoryConfiguration>()
            //         .RegisterFactory<IObjectContext>(x =>
            //             ContextResolver(x, lifetimeManager, _connection));

            //return this;

            throw new NotImplementedException();
        }

        //factory func to build context with given lifetime & connection
        static readonly Func<IUnityContainer, LifetimeManager, SqlConnection, object>
            ContextResolver = (c, l, s) =>
            {
                //var context = l.GetValue();
                //if (context == null)
                //{
                //    var builder = c.Resolve<ContextBuilder<ObjectContext>>("builder");
                //    var newContext = builder.Create(s);
                //    context = new ObjectContextAdapter(newContext);
                //    l.SetValue(context);
                //}

                //return context;

                throw new NotImplementedException();
            };
    }
}