namespace Raffles.Data.Services.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Raffles.DomainObjects.Entities;

    public class RaffleParticipantConfiguration : EntityTypeConfiguration<RaffleParticipant>
    {
        public RaffleParticipantConfiguration() {
            HasKey(r => new { r.RaffleId, r.ParticipantId });
        }
    }
}
