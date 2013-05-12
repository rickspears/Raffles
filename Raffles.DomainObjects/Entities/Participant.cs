namespace Raffles.DomainObjects.Entities
{
    using System.Collections.Generic;

    public class Participant
    {
        public int ParticipantId { get; set; }

        public string Name { get; set; }
        public ContactDetails Contact { get; set; }

        public ICollection<RaffleParticipant> RaffleParticipants { get; set; }
        public ICollection<Winner> Winners { get; set; }
    }
}
