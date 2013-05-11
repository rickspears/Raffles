namespace Raffles.DomainObjects.Models
{
    using System.Collections.ObjectModel;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;

    public class RaffleModel : NotifyPropertyChanged
    {
        #region Constructors
        public RaffleModel(Raffle entity) {
            RaffleId = entity.RaffleId;

            Name = entity.Name;
            Description = entity.Description;
            Location = entity.Location;

            RaffleParticipants = 
                new ObservableCollection<RaffleParticipant>(
                    entity.RaffleParticipants);
            RaffleItems =
                new ObservableCollection<RaffleItem>(
                    entity.RaffleItems);
        }
        #endregion

        #region Properties
        public int RaffleId { get; set; }

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
                OnPropertyChanged("Description");
            }
        }

        private ContactDetails location;
        public ContactDetails Location {
            get { return location; }
            set {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        private ObservableCollection<RaffleParticipant> raffleParticipants;
        public ObservableCollection<RaffleParticipant> RaffleParticipants {
            get { return raffleParticipants; }
            set {
                raffleParticipants = value;
                OnPropertyChanged("RaffleParticipants");
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
