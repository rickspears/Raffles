namespace Raffles.Data.Services.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Raffles.DomainObjects.Entities;

    public class RaffleItemConfiguration : EntityTypeConfiguration<RaffleItem>
    {
        public RaffleItemConfiguration() {
            HasKey(r => new { r.RaffleId, r.ItemId });
        }
    }
}
