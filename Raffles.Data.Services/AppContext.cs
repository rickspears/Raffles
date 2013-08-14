namespace Raffles.Data.Services
{
    using System.Data.Entity;
    using Raffles.Data.Services.Configuration;
    using Raffles.DomainObjects.Entities;

    public class AppContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Raffle> Raffles { get; set; }
        public DbSet<RaffleItem> RaffleItems { get; set; }
        public DbSet<RaffleParticipant> RaffleParticipants { get; set; }
        public DbSet<Winner> Winners { get; set; }

        public AppContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new ParticipantConfiguration());
            modelBuilder.Configurations.Add(new RaffleConfiguration());
            modelBuilder.Configurations.Add(new RaffleItemConfiguration());
            modelBuilder.Configurations.Add(new RaffleParticipantConfiguration());
            modelBuilder.Configurations.Add(new WinnerConfiguration());            
        }
    }
}
