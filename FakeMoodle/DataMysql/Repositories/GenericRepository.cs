using DataMySql.Contexts;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMySql.Repositories
{
    public abstract class GenericRepositorySql<C, T> : IGenericRepository<T>
     where T : AbstractDto where C : DbContext, new()
    {

        private C _context = new C();
        public C Context
        {

            get { return _context; }
            set { _context = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public virtual T GetById(int id)
        {
            IQueryable<T> query = _context.Set<T>().Where(X => X.Id == id);
            return query.FirstOrDefault();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
