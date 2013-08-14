namespace Raffles.Data.Services.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Raffles.DomainObjects.Entities;

    public class RaffleResultConfiguration : EntityTypeConfiguration<RaffleResult>
    {
        public RaffleResultConfiguration() {
            HasKey(w => new { w.RaffleResultId, w.RaffleId });

            Property(r => r.RaffleResultId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}