using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raffles.DomainObjects.Entities
{
    public class RaffleItem
    {
        public int RaffleId { get; set; }
        public Raffle Raffle { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ItemCount { get; set; }
    }
}
