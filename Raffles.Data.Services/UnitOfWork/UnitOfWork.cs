namespace Raffles.Data.Services.UnitOfWork
{
    using System;
    using Raffles.Data.Services.Factory;
    using Raffles.Data.Services.Repository;
    using Raffles.DomainObjects.Entities;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Constructors
        public UnitOfWork(IRepositoryProvider repositoryProvider) {
            InitializeDbContext();

            repositoryProvider.DbContext = context;
            RepositoryProvider = repositoryProvider;

        }
        #endregion

        #region Fields
        private AppContext context;
        #endregion

        #region Properties
        protected IRepositoryProvider RepositoryProvider { get; set; }

        public IRepository<Raffle> Raffles { get { return GetStandardRepository<Raffle>(); } }
        public IRepository<Participant> Participants { get { return GetStandardRepository<Participant>(); } }
        public IRepository<Item> Items { get { return GetStandardRepository<Item>(); } }
        public IRepository<RaffleParticipant> RaffleParticipants { get { return GetStandardRepository<RaffleParticipant>(); } }
        public IRepository<RaffleItem> RaffleItems { get { return GetStandardRepository<RaffleItem>(); } }
        public IWinnerRepository Winners { get { return GetRepository<IWinnerRepository>(); } }
        #endregion

        #region Methods
        public void Commit() {
            context.SaveChanges();
        }
        #endregion

        #region Helpers
        protected void InitializeDbContext() {
            context = new AppContext();

            context.Configuration.ProxyCreationEnabled = false;
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
        }

        private IRepository<T> GetStandardRepository<T>() where T : class {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepository<T>() where T : class {
            return RepositoryProvider.GetRepository<T>();
        }

        #endregion       

        #region IDisposable
        public void Dispose() {
            if (context != null) context.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}