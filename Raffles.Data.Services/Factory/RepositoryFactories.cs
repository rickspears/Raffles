namespace Raffles.Data.Services.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Raffles.Data.Services.Repository;

    public class RepositoryFactories
    {
        #region Constructors
        public RepositoryFactories() {
            repositoryFactories = GetRaffleFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories) {
            repositoryFactories = factories;
        }
        #endregion

        #region Fields
        private readonly IDictionary<Type, Func<DbContext, object>> repositoryFactories;
        #endregion

        #region Methods
        public Func<DbContext, object> GetRepositoryFactory<T>() {
            Func<DbContext, object> factory;
            repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class {
            return dbContext => new Repository<T>(dbContext);
        }
        #endregion

        #region Helpers
        private IDictionary<Type, Func<DbContext, object>> GetRaffleFactories() {
            return new Dictionary<Type, Func<DbContext, object>> {
                { typeof(IWinnerRepository), dbContext => new WinnerRepository(dbContext) }
            };
        }
        #endregion
    }
}