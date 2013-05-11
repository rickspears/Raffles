using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raffles.DomainObjects.Entities
{
    public class RaffleParticipant
    {
        public int RaffleId { get; set; }
        public Raffle Raffle { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int TicketCount { get; set; }
    }
}