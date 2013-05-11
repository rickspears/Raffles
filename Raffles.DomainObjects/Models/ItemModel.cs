namespace Raffles.DomainObjects.Models
{
    using System;
    using System.Collections.ObjectModel;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;

    public class ItemModel : NotifyPropertyChanged
    {
        #region Constructor
        

        public ItemModel(Item entity) {
            ItemId = entity.ItemId;
            
            Name = entity.Name;
            Description = entity.Description;
            Sku = entity.Sku;
        }
        #endregion

        #region Properties
        public int ItemId { get; set; }

        private string name;
        public string Name {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string description;
        public string Description {
            get { return description; }
            set {
                description = value;
                OnPropertyChanged("Decription");
            }
        }

        private string sku;
        public string Sku {
            get { return sku; }
            set {
                sku = value;
                OnPropertyChanged("Sku");
            }
        }

        private bool isIncluded;
        public bool IsIncluded {
            get { return isIncluded; }
            set { 
                isIncluded = value;
                OnPropertyChanged("IsIncluded");
            }
        }

        private int itemCount;
        public int ItemCount {
            get { return itemCount; }
            set { 
                itemCount = value;
                OnPropertyChanged("ItemCount");
            }
        }


        private ObservableCollection<RaffleItem> raffleItems;
        public ObservableCollection<RaffleItem> RaffleItems {
            get { return raffleItems; }
            set { 
                raffleItems = value;
                OnPropertyChanged("RaffleItems");
            }
        }
        #endregion
    }
}
