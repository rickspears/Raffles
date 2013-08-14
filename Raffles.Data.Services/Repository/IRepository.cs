namespace Raffles.Data.Services.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class  
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate);
        T GetBy(int id);
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}
