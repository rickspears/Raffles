namespace Raffles.Data.Services.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T> where T : class
    {
        #region Constructors
        public Repository(DbContext context) {
            if (context == null)
                throw new ArgumentNullException("context");
            this.Context = context;
            this.DbSet = Context.Set<T>();
        }
        #endregion

        #region Properties
        protected DbContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }
        #endregion

        #region Methods
        public IEnumerable<T> GetAll() {
            return DbSet;
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate) {
            return DbSet.Where(predicate);
        }

        public virtual T GetBy(int id) {
            return DbSet.Find(id);
        }

        public void Add(T entity) {
            var entry = Context.Entry(entity);
            if (entry.State == System.Data.EntityState.Detached)
                DbSet.Add(entity);
            else
                entry.State = System.Data.EntityState.Added;
        }

        public void Remove(T entity) {
            var entry = Context.Entry(entity);
            if (entry.State == System.Data.EntityState.Deleted) {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            else
                entry.State = System.Data.EntityState.Deleted;
        }

        public virtual void Remove(int id) {
            var entity = GetBy(id);
            if (entity == null) return;
            Remove(entity);
        }

        public void Update(T entity) {
            var entry = Context.Entry(entity);
            if (entry.State == System.Data.EntityState.Detached)
                DbSet.Attach(entity);
            entry.State = System.Data.EntityState.Modified;
        }
        #endregion
    }
}
