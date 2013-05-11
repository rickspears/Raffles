namespace Raffles.Data.EFRepository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext context) {
            

        }

        public IQueryable<T> GetAll() {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetByPred(Expression<Func<T, bool>> predicate) {
            throw new NotImplementedException();
        }

        public T GetById(int id) {
            throw new NotImplementedException();
        }

        public void Add(T entity) {
            throw new NotImplementedException();
        }

        public void Remove(T entity) {
            throw new NotImplementedException();
        }
        public void Remove(int id) {
            throw new NotImplementedException();
        }

        public void Update(T entity) {
            throw new NotImplementedException();
        }
    }
}
