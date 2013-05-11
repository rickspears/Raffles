namespace Raffles.DomainObjects.Models
{
    using System.Collections.ObjectModel;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;

    public class RaffleResultModel : NotifyPropertyChanged
    {
        public RaffleResultModel(RaffleResult entity) {
            RaffleResultId = entity.RaffleResultId;
            RaffleId = entity.RaffleId;

            Name = entity.Name;

            Winners = new ObservableCollection<Winner>(entity.Winners);
        }
        public int RaffleResultId { get; set; }
        public int RaffleId { get; set; }

        private string name;
        public string Name {
            get { return name; }
            set { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        ObservableCollection<Winner> winners;
        public ObservableCollection<Winner> Winners {
            get { return winners; }
            set {
                winners = value;
                OnPropertyChanged("Winners");
            }
        }        
    }
}
