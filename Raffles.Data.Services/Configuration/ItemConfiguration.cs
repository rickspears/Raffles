namespace Raffles.Data.Services.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Raffles.DomainObjects.Entities;

    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration() {
            Property(i => i.ItemId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
