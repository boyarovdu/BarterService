using System;
using System.Collections.Generic;
using BasrterService.Model.Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Common
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly IContext _context;
        private bool _disposed;
        private Dictionary<string, object> _repositories;

        public UnitOfWork([Dependency]IContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.Save();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public IEntityRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = ServiceLocator.Current.GetInstance<IUnityContainer>()
                    .Resolve<IEntityRepository<T>>();
                _repositories.Add(type, repositoryInstance);
            }
            return (IEntityRepository<T>)_repositories[type];
        }
    }
}

