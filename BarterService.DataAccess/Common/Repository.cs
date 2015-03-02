using System.Data.Entity;
using System.Linq;
using BasrterService.Model.Common;
using Microsoft.Practices.Unity;

namespace BarterService.DataAccess.Common
{
    public class Repository<T> : IEntityRepository<T> where T : BaseEntity
    {
        private readonly IContext _context;
        private IDbSet<T> _entities;

        public Repository([Dependency]IContext context)
        {
            _context = context;
        }

        private IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }

        public T GetById(long id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            Entities.Add(entity);
            _context.Save();
        }

        public void Update(T entity)
        {
            _context.Save();
        }

        public virtual IQueryable<T> All()
        {
            return Entities;
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
            _context.Save();
        }
    }
}