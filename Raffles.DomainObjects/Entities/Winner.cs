namespace Raffles.DomainObjects.Entities
{
    public class Winner
    {
        public int RaffleCounter { get; set; }

        public int RaffleId { get; set; }
        public Raffle Raffle { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public bool Claimed { get; set; }
    }
}