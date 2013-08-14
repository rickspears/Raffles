namespace Raffles.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using MoreLinq;
    using Raffles.Data.Services;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;
    using Raffles.DomainObjects.Models;

    public class RaffleWinnersViewModel : NotifyPropertyChanged
    {
        public RaffleWinnersViewModel() {
            using (AppContext context = new AppContext()) {
                context.Raffles
                    .Include(r => r.RaffleItems)
                    .Include(r => r.RaffleParticipants)
                    .Include(r => r.Winners)
                    .Load();
                context.Items
                    .Include(i => i.RaffleItems)
                    .Load();
                context.Participants
                    .Include(p => p.RaffleParticipants)
                    .Load();

                ConvertCollection convert = new ConvertCollection();
                Raffles = convert.GetRaffleModelFrom(context.Raffles.Local);                
            }
        }

        private RaffleModel selectedRaffle;
        public RaffleModel SelectedRaffle {
            get { return selectedRaffle; }
            set { 
                selectedRaffle = value;
                OnPropertyChanged("SelectedRaffle");
                //DistinctCounters = selectedRaffle.Winners
                //    .GroupBy(i=>i.RaffleCounter)
                //    .Select(w => w.Key)
                //    .ToObservableCollection();
                DistinctCounters = null;
                DistinctCounter = 0;
                DistinctCounters = selectedRaffle.Winners
                    .DistinctBy(w => w.RaffleCounter)
                    .Select(w => w.RaffleCounter)
                    .ToObservableCollection();
                
            }
        }

        private ObservableCollection<RaffleModel> raffles;
        public ObservableCollection<RaffleModel> Raffles {
            get { return raffles; }
            set {
                raffles = value;
                OnPropertyChanged("Raffles");
            }
        }

        private int distinctCounter;
        public int DistinctCounter {
            get { return distinctCounter; }
            set { 
                distinctCounter = value;
                OnPropertyChanged("DistinctCounter");

                Winners = SelectedRaffle.Winners
                    .Where(w => w.RaffleId == SelectedRaffle.RaffleId
                        && w.RaffleCounter == distinctCounter)
                    .Select(w => new Winner {  Raffle = w.Raffle, 
                                               Participant = w.Participant, 
                                               Item = w.Item, 
                                               Claimed = w.Claimed })
                    .ToObservableCollection();
                    
            }
        }

        private ObservableCollection<int> distinctCounters;
        public ObservableCollection<int> DistinctCounters {
            get { return distinctCounters; }
            set { 
                distinctCounters = value;
                OnPropertyChanged("DistinctCounters");
            }
        }

        private ObservableCollection<Winner> winners;
        public ObservableCollection<Winner> Winners {
            get { return winners; }
            set { 
                winners = value;
                OnPropertyChanged("Winners");
            }
        }

        #region Helper Methods
        
        #endregion
        
    }
}
