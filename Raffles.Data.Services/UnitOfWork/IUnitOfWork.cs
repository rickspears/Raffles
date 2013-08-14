namespace Raffles.Data.Services.UnitOfWork
{
    using Raffles.Data.Services.Repository;
    using Raffles.DomainObjects.Entities;

    public interface IUnitOfWork
    {
        IRepository<Raffle> Raffles { get; }
        IRepository<Participant> Participants { get; }
        IRepository<Item> Items { get; }
        IRepository<RaffleParticipant> RaffleParticipants { get; }
        IRepository<RaffleItem> RaffleItems { get; }
        IWinnerRepository Winners { get; }

        void Commit();
    }
}
