using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAppDomain.DataModel
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public void Delete(object Id)
        {
           T obj = Context.Set<T>().Find(Id);
            Context.Set<T>().Remove(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(object Id)
        {
            return Context.Set<T>().Find(Id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Context.Set<T>().Where(predicate);
            return query;
        }

        public void Update(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            Context.Entry(obj).State = EntityState.Deleted;
        }
    }
}
