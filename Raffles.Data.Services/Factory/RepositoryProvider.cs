namespace Raffles.Data.Services.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Raffles.Data.Services.Repository;

    public class RepositoryProvider : IRepositoryProvider
    {
        #region Constructor
        public RepositoryProvider(RepositoryFactories repositoryFactories) {
            this.repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }
        #endregion

        #region Fields
        private RepositoryFactories repositoryFactories;
        #endregion

        #region Properties
        public DbContext DbContext { get; set; }
        protected Dictionary<Type, object> Repositories { get; private set; }
        #endregion

        #region Methods
        public IRepository<T> GetRepositoryForEntityType<T>() where T : class {
            return GetRepository<IRepository<T>>(
                repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class {
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null) return (T)repoObj;
            return MakeRepository<T>(factory, DbContext);
        }

        public void SetRepository<T>(T repository) {
            Repositories[typeof(T)] = repository;
        }

        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext) {
            var f = factory ?? repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            var repo = (T)f(dbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }
        #endregion
    }
}