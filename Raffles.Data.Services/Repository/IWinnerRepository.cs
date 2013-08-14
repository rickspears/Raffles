namespace Raffles.Data.Services.Repository
{
    using System.Linq;
    using Raffles.DomainObjects.Entities;

    public interface IWinnerRepository : IRepository<Winner>
    {
        IQueryable<Winner> GetByRaffle(int Id);
        IQueryable<Winner> GetByItem(int Id);
        IQueryable<Winner> GetByParticipant(int Id);

        Winner GetBy(int RaffleId, int RaffleCounter, int ItemId, int ParticipantId);
        Winner GetBy(Winner winner);

        void Remove(int RaffleId, int RaffleCounter, int ItemId, int ParticipantId);
        void Remove(Winner winner);
    }
}
