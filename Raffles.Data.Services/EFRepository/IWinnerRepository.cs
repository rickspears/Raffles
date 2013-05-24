using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raffles.DomainObjects.Entities;

namespace Raffles.Data.Services.EFRepository
{
    interface IWinnerRepository : IRepository<Winner>
    {
        IQueryable<Winner> GetByRaffle(int Id);
        IQueryable<Winner> GetByItem(int Id);
        IQueryable<Winner> GetByParticipant(int Id);

        Winner GetBy(int RaffleId, int RaffleCounter, int ItemId, int ParticipantId);

        void Remove(int RaffleId, int RaffleCounter, int ItemId, int ParticipantId);
    }
}
