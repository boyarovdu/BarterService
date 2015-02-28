using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using BarterService.DataAccess.Validation;
using BarterService.DataAccess.Validation.Common;
using BasrterService.Model.Common;
using BasrterService.Model.Objects;

namespace BarterService.DataAccess.Common
{
    public class BarterServiceContext : DbContext, IContext
    {
        public const string ConnectionString = "name=BarterService.DbConnection.Dev";

        public BarterServiceContext()
            : base(ConnectionString)
        {
            Configuration.LazyLoadingEnabled = true;
            Database.Initialize(false);
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
            // Conventions override
            //modelBuilder.Properties()
            //        .Where(p => p.Name == "Id")
            //        .Configure(p => p.IsKey()); 

            var typesToRegister = GetTypesOf(typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        private static IEnumerable<Type> GetTypesOf(Type type)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !String.IsNullOrEmpty(t.Namespace))
                .Where(t =>
                {
                    return t.BaseType != null
                           && t.BaseType.IsGenericType
                           && (t.BaseType.GetGenericTypeDefinition() == type || t.BaseType == type);
                });
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
    }
}
