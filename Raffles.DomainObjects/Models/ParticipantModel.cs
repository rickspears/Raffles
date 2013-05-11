namespace Raffles.DomainObjects.Models
{
    using System;
    using System.Collections.ObjectModel;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;

    public class ParticipantModel : NotifyPropertyChanged
    {        
        #region Constructors
        public ParticipantModel(Participant entity) {
            ParticipantId = entity.ParticipantId;

            Name = entity.Name;
            Contact = entity.Contact;
        }
        #endregion

        #region Properties
        public int ParticipantId { get; set; }

        private string name;
        public string Name {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private ContactDetails contact;
        public ContactDetails Contact {
            get { return contact; }
            set {
                contact = value;
                OnPropertyChanged("Contact");
            }
        }

        private bool isRegistered;
        public bool IsRegistered {
            get { return isRegistered; }
            set { 
                isRegistered = value;
                OnPropertyChanged("IsRegistered");
            }
        }

        private int ticketCount;
        public int TicketCount {
            get { return ticketCount; }
            set { 
                ticketCount = value;
                OnPropertyChanged("TicketCount");
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
        #endregion
    }
}
