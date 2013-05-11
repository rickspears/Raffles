using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raffles.DomainObjects.Entities;

namespace Raffles.Data.Configuration
{
    public class RaffleItemConfiguration : EntityTypeConfiguration<RaffleItem>
    {
        public RaffleItemConfiguration() {
            HasKey(r => new { r.RaffleId, r.ItemId });
        }
    }
}
