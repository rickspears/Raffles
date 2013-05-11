namespace Raffles.DomainObjects.Entities
{
    using System.Collections.Generic;

    public class RaffleResult
    {
        public int RaffleResultId { get; set; }

        public int RaffleId { get; set; }
        public Raffle Raffle { get; set; }

        public string Name { get; set; }

        public ICollection<Winner> Winners { get; set; }

    }
}
