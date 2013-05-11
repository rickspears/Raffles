namespace Raffles.DomainObjects.Models
{
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;

    public class WinnerModel : NotifyPropertyChanged
    {
        public WinnerModel(Winner entity) {
            RaffleResultId = entity.RaffleId;
            ParticipantId = entity.ParticipantId;
            ItemId = entity.ItemId;
            Claimed = entity.Claimed;
            
        }

        public int RaffleResultId { get; set; }

        private int itemId;
        public int ItemId {
            get { return itemId; }
            set { 
                itemId = value;
                OnPropertyChanged("ItemId");
            }
        }

        private int participantId;        
        public int ParticipantId {
            get { return participantId; }
            set { 
                participantId = value;
                OnPropertyChanged("ParticipantId");
            }
        }

        private bool claimed;
        public bool Claimed {
            get { return claimed; }
            set {
                claimed = value;
                OnPropertyChanged("Claimed");
            }
        }
    }
}
