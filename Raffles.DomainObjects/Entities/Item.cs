namespace Raffles.DomainObjects.Entities
{
    using System.Collections.Generic;

    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }

        public ICollection<RaffleItem> RaffleItems { get; set; }
        public ICollection<Winner> Winners { get; set; }
    }
}
