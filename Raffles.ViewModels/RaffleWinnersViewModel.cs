namespace Raffles.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using MoreLinq;
    using Raffles.Data.Services;
    using Raffles.Data.Services.UnitOfWork;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;
    using Raffles.DomainObjects.Models;

    public class RaffleWinnersViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public RaffleWinnersViewModel(IUnitOfWork uow) {
            this.uow = uow;

            var raffles = uow.Raffles.GetAll()
                             .Include(r => r.RaffleItems)
                             .Include(r => r.RaffleParticipants)
                             .Include(r => r.Winners)
                             .ToObservableCollection();
            var convert = new ConvertCollection();
            Raffles = convert.GetRaffleModelFrom(raffles);
        }
        #endregion

        #region Fields
        IUnitOfWork uow;
        #endregion

        #region Properties
        private RaffleModel selectedRaffle;
        public RaffleModel SelectedRaffle {
            get { return selectedRaffle; }
            set { 
                selectedRaffle = value;
                OnPropertyChanged("SelectedRaffle");
                GetSelectedRaffleDistinctExecutions();                
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
                GetSelectedRaffleWinners();
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
        #endregion

        #region Helper Methods
        // We need to get the distinct executions for the raffle... e.g.,  1 thru 10
        private void GetSelectedRaffleDistinctExecutions() {
            DistinctCounters = null;
            DistinctCounter = 0;
            DistinctCounters = selectedRaffle.Winners
                .DistinctBy(w => w.RaffleCounter)
                .Select(w => w.RaffleCounter)
                .ToObservableCollection();
        }

        private void GetSelectedRaffleWinners() {
            Winners = uow.Winners.GetByRaffle(SelectedRaffle.RaffleId)
                .Where(w => w.RaffleCounter == distinctCounter)
                .Include(w => w.Participant)
                .Include(w => w.Item)
                .ToObservableCollection();
        }
        #endregion        
    }
}
