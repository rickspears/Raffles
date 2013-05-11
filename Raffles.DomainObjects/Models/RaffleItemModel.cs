using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raffles.DomainObjects.Entities;
using Raffles.DomainObjects.Events;

namespace Raffles.DomainObjects.Models
{
    public class RaffleItemModel : NotifyPropertyChanged
    {
        public RaffleItemModel(RaffleItem entity) {

        }

        public int RaffleId { get; set; }
        private Raffle raffle;
        public Raffle Raffle {
            get { return raffle; }
            set { 
                raffle = value;
                OnPropertyChanged("Raffle");
            }
        }

        public int ItemId { get; set; }
        private Item item;
        public Item Item {
            get { return item; }
            set { 
                item = value;
                OnPropertyChanged("Item");
            }
        }

    }
}
