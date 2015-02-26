using System;
using System.Collections.Generic;
using BasrterService.Model.Common;

namespace BarterService.DataAccess.Common
{
    namespace EF.Data
    {
        public class UnitOfWork : IDisposable, IUnitOfWork
        {
            private readonly IContext _context;
            private bool _disposed;
            private Dictionary<string, object> _repositories;

            public UnitOfWork(IContext context)
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

            public Repository<T> Repository<T>() where T : BaseEntity
            {
                if (_repositories == null)
                {
                    _repositories = new Dictionary<string, object>();
                }

                var type = typeof(T).Name;

                if (!_repositories.ContainsKey(type))
                {
                    var repositoryType = typeof(Repository<>);
                    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                    _repositories.Add(type, repositoryInstance);
                }
                return (Repository<T>)_repositories[type];
            }
        }
    } 
}
