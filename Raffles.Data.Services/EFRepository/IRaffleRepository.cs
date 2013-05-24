using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raffles.DomainObjects.Entities;

namespace Raffles.Data.Services.EFRepository
{
    interface IRaffleRepository : IRepository<RaffleItem>, IRepository<RaffleParticipant>
    {
        IQueryable<RaffleItem> GetRaffleItems();
        IQueryable<RaffleParticipant> GetRaffleParticipants();
    }
}
