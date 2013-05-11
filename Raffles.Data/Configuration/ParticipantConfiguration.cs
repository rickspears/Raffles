namespace Raffles.Data.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Raffles.DomainObjects.Entities;

    public class ParticipantConfiguration : EntityTypeConfiguration<Participant>
    {
        public ParticipantConfiguration() {
            Property(p=>p.ParticipantId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
