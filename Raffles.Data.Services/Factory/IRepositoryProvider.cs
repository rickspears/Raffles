namespace Raffles.Data.Services.Factory
{
    using System;
    using System.Data.Entity;
    using Raffles.Data.Services.Repository;

    public interface IRepositoryProvider
    {
        DbContext DbContext { get; set; }

        IRepository<T> GetRepositoryForEntityType<T>() where T : class;

        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;

        void SetRepository<T>(T repository);
    }
}
