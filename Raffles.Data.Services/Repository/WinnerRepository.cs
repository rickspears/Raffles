namespace Raffles.Data.Services.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Raffles.DomainObjects.Entities;

    public class WinnerRepository : Repository<Winner>, IWinnerRepository
    {
        #region Constructors
        public WinnerRepository(DbContext context) :base(context) { }
        #endregion

        #region Methods
        public override Winner GetBy(int id){
            throw new InvalidOperationException("Cannot determine a Winner off of an Id");
        }

        public override void Remove(int id) {
            throw new InvalidOperationException("Cannot delete a winner off of a an Id");
        }

        public IQueryable<Winner> GetByRaffle(int Id) {
            return DbSet.Where(w => w.RaffleId == Id);
        }
        public IQueryable<Winner> GetByItem(int Id) {
            return DbSet.Where(w => w.ItemId == Id);
        }
        public IQueryable<Winner> GetByParticipant(int Id) {
            return DbSet.Where(w => w.ParticipantId == Id);
        }

        public Winner GetBy(int RaffleId, int RaffleCounter, int ParticipantId, int ItemId) {
            return DbSet.FirstOrDefault(w => w.RaffleId == RaffleId
                                          && w.RaffleCounter == RaffleCounter
                                          && w.ParticipantId == ParticipantId
                                          && w.ItemId == ItemId);
        }
        public Winner GetBy(Winner winner) {
            return GetBy(winner.RaffleId, winner.RaffleCounter, winner.ParticipantId, winner.ItemId);
        }

        public void Remove(int RaffleId, int RaffleCounter, int ParticipantId, int ItemId) {
            var entity = GetBy(RaffleId, RaffleCounter, ParticipantId, ItemId);
            if (entity == null) return;
            Remove(entity);
        }
        public void Remove(Winner winner) {
            Remove(winner.RaffleId, winner.RaffleCounter, winner.ParticipantId, winner.ItemId);
        }
        #endregion
    }
}
