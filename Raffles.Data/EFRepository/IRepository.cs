using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Raffles.Data.EFRepository
{
    interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByPred(Expression<Func<T,bool>> predicate);
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}
