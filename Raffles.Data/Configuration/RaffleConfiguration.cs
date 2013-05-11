namespace Raffles.Data.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Raffles.DomainObjects.Entities;

    public class RaffleConfiguration : EntityTypeConfiguration<Raffle>
    {
        public RaffleConfiguration() {
            Property(r => r.RaffleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}