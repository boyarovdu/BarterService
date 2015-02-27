using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using BasrterService.Model.Common;

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

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
