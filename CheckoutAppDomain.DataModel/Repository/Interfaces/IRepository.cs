using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAppDomain.DataModel
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T obj);
        void Update(T obj);
        void Delete(Object Id);
        void Delete(T Obj);
        void Save();
    }
}
