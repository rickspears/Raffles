namespace Raffles.Data.Services.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Raffles.DomainObjects.Entities;

    public class WinnerConfiguration : EntityTypeConfiguration<Winner>
    {
        public WinnerConfiguration() {
            HasKey(w => new { w.RaffleId, w.RaffleCounter, w.ParticipantId, w.ItemId });
        }
    }
}