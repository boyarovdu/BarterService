using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using BarterService.DataAccess.Extensions;
using BarterService.DataAccess.Validation.Common;
using BasrterService.Model.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Common
{
    public class BarterServiceContext : DbContext, IContext
    {
        private IConfigurationSource _configSource;

        public IConfigurationSource ConfigSource
        {
            get { return _configSource ?? (_configSource = ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<IConfigurationSource>()); }
        }

        public BarterServiceContext()
        {
            //var settings = DatabaseSettings.GetDatabaseSettings(ConfigSource);
            Database.Connection.ConnectionString =
                @"data source=.\SQLEXPRESS;initial catalog=BarterService;      integrated security=True;multipleactiveresultsets=true;App=EntityFramework";//settings.DefaultConnectionString();
            Configuration.LazyLoadingEnabled = true;
        }

        public ObjectContext Core
        {
            get { return (this as IObjectContextAdapter).ObjectContext; }
        }

        public void Save()
        {
            SaveChanges();
        }

        public IEnumerable<T> ManagedEntites<T>()
        {
            var oses = Core.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            return oses.Where(entry => entry.Entity is T)
            .Select(entry => (T)entry.Entity);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            OverrideConventions(modelBuilder);
            MapEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        // ReSharper disable once UnusedParameter.Local
        private static void OverrideConventions(DbModelBuilder modelBuilder)
        {
            // Conventions override
            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p =>
                {
                    p.IsKey();
                    p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                });
        }

        private void MapEntities(DbModelBuilder modelBuilder)
        {
            var typesToRegister = GetTypesOf(typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }

        private static IEnumerable<Type> GetTypesOf(Type type)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !String.IsNullOrEmpty(t.Namespace))
                .Where(t => t.BaseType != null
                            && t.BaseType.IsGenericType
                            && (t.BaseType.GetGenericTypeDefinition() == type || t.BaseType == type));
            return types;
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var validatorType = GetTypesOf(typeof(EntityValidator<>)
                .MakeGenericType(entityEntry.Entity.GetType()))
                .FirstOrDefault();

            if (validatorType == null) return base.ValidateEntity(entityEntry, items);

            var validator = (EntityValidator)Activator.CreateInstance(validatorType);
            validator.Validate(entityEntry, items);

            var result = new DbEntityValidationResult(entityEntry, validator.Errors);

            return result.ValidationErrors.Any()
                ? result
                : base.ValidateEntity(entityEntry, items);
        }

        public IEnumerable<TResult> ExecuteEnumerable<TResult>(IStoredProcedure<TResult> procedure)
        {
            var result = Database.ExecuteStoredProcedure(procedure);
            return result;
        }

        public TResult ExecuteScalar<TResult>(IStoredProcedure<TResult> procedure)
        {
            var result = Database.ExecuteStoredProcedure(procedure);
            return result.FirstOrDefault();
        }

        public int ExecuteNonQuery(IStoredProcedure<int> procedure)
        {
            Database.ExecuteStoredProcedure(procedure);
            return 0;
        }

        public void BeginTransaction(IsolationLevel isoLevel)
        {
            Database.BeginTransaction(isoLevel);
        }

        public void BeginTransaction()
        {
            Database.BeginTransaction();
        }

        public void Rollback()
        {
            Database.CurrentTransaction.Rollback();
        }

        public void Commit()
        {
            Database.CurrentTransaction.Commit();
        }
    }
}
