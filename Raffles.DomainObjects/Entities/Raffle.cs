namespace Raffles.DomainObjects.Entities
{
    using System.Collections.Generic;

    public class Raffle
    {
        public int RaffleId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public ContactDetails Location { get; set; }

        public int ExecutionCount { get; set; }

        public ICollection<RaffleItem> RaffleItems { get; set; }
        public ICollection<RaffleParticipant> RaffleParticipants { get; set; }
        public ICollection<Winner> Winners { get; set; }
    }
}