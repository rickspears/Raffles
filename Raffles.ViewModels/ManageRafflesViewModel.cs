namespace Raffles.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Input;
    using Raffles.Data.Services;
    using Raffles.Data.Services.UnitOfWork;
    using Raffles.DomainObjects.Commands;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;
    using Raffles.DomainObjects.Models;

    public class ManageRafflesViewModel : NotifyPropertyChanged
    {
        public ManageRafflesViewModel(IUnitOfWork uow) {
            this.uow = uow;

            var raffles = uow.Raffles.GetAll()
                             .Include(r => r.RaffleItems)
                             .Include(r => r.RaffleParticipants)
                             .Include(r => r.Winners)
                             .ToObservableCollection();
            var items = uow.Items.GetAll().ToObservableCollection();
            var participants = uow.Participants.GetAll()
                                  .ToObservableCollection();

            var convert = new ConvertCollection();
            Raffles = convert.GetRaffleModelFrom(raffles);
            Items = convert.GetItemModelFrom(items);
            Participants = convert.GetParticipantModelFrom(participants);
        }

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
                RefreshSelectedItems();
                RefreshSelectedParticipants();
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

        private ObservableCollection<ItemModel> items;
        public ObservableCollection<ItemModel> Items {
            get { return items; }
            set { 
                items = value;
                OnPropertyChanged("Items");
            }
        }

        private ObservableCollection<ParticipantModel> participants;
        public ObservableCollection<ParticipantModel> Participants {
            get { return participants; }
            set {
                participants = value;
                OnPropertyChanged("Participants");
            }
        }
        #endregion

        #region Methods
        private void AddRaffle() {
            var raffle = new Raffle {
                Name = "<Enter Name, and Select Items and Participants>",
                Location = new ContactDetails() { Address1 = "<Enter Location and Contact Details>" },
                RaffleParticipants = new ObservableCollection<RaffleParticipant>(),
                RaffleItems = new ObservableCollection<RaffleItem>()
            };
            uow.Raffles.Add(raffle);
            SelectedRaffle = new RaffleModel(raffle);
            Raffles.Add(SelectedRaffle);
            ClearSelectedItems();
            ClearSelectedParticipants();
        }
        private void DeleteRaffle() {
            uow.Raffles.Remove(SelectedRaffle.RaffleId);
            Raffles.Remove(SelectedRaffle);
        }
        private void UpdateRaffle() {
            //Check checked items against already stored list of items
            var items = Items.Where(i => i.IsIncluded)
                .Select(i => new RaffleItem { ItemId = i.ItemId, 
                                              Item = uow.Items.GetBy(i.ItemId), 
                                              RaffleId = SelectedRaffle.RaffleId,
                                              ItemCount = i.ItemCount })
                                              .ToObservableCollection();
            var participants = Participants.Where(p => p.IsRegistered)
                                              .Select(p => new RaffleParticipant { 
                                              ParticipantId = p.ParticipantId,
                                              RaffleId = SelectedRaffle.RaffleId,
                                              TicketCount = p.TicketCount })
                                              .ToObservableCollection();
            var raffle = uow.Raffles.GetBy(SelectedRaffle.RaffleId);
            raffle.Name = SelectedRaffle.Name;
            raffle.Description = SelectedRaffle.Description;
            raffle.Location = SelectedRaffle.Location;
            raffle.ExecutionCount = SelectedRaffle.ExecutionCount;
            raffle.Winners = SelectedRaffle.Winners;
            raffle.RaffleItems = items;
            raffle.RaffleParticipants = participants;

            uow.Raffles.Update(raffle);
            uow.Commit();
        }

        private void RefreshSelectedRaffle() {
            using (AppContext context = new AppContext()) {
                var dbRaffle = context.Raffles.First(r => r.RaffleId == SelectedRaffle.RaffleId);
                SelectedRaffle.Name = dbRaffle.Name;
                SelectedRaffle.Description = dbRaffle.Description;
                SelectedRaffle.Location = dbRaffle.Location;
            }
        }
        private void RefreshSelectedItems() {
            if (SelectedRaffle == null || Items == null) return;
            foreach (var checkedItem in Items) {
                var raffleItem = SelectedRaffle.RaffleItems.FirstOrDefault(
                                    i => i.ItemId == checkedItem.ItemId);
                if (raffleItem != null) {
                    checkedItem.IsIncluded = true;
                    checkedItem.ItemCount = raffleItem.ItemCount;
                }
                else {
                    checkedItem.IsIncluded = false;
                    checkedItem.ItemCount = 0;
                }
            }
        }
        private void RefreshSelectedParticipants() {
            if (SelectedRaffle == null || Participants == null) return;
            foreach (var checkedParticipant in Participants) {
                var raffleParticipant = SelectedRaffle.RaffleParticipants.FirstOrDefault(
                                            p => p.ParticipantId == checkedParticipant.ParticipantId);

                if (raffleParticipant != null) {
                    checkedParticipant.IsRegistered = true;
                    checkedParticipant.TicketCount = raffleParticipant.TicketCount;
                }
                else {
                    checkedParticipant.IsRegistered = false;
                    checkedParticipant.TicketCount = 0;
                }
            }
        }

        private void ClearSelectedItems() {
            foreach (var checkedItem in Items) {
                checkedItem.IsIncluded = false;
                checkedItem.ItemCount = 0;
            }
        }
        private void ClearSelectedParticipants() {
            foreach (var checkedParticpant in Participants) {
                checkedParticpant.IsRegistered = false;
                checkedParticpant.TicketCount = 0;
            }
        }
        #endregion

        #region Commands
        public ICommand SaveChanges {
            get {
                return new RelayCommand(ExecuteSave, CanExecuteSave);
            }
        }
        private void ExecuteSave(object parameter) {            
            UpdateRaffle();
        }
        private bool CanExecuteSave(object parameter) {
            if (SelectedRaffle != null)
                return true;
            return false;
        }

        public ICommand CancelChanges {
            get { return new RelayCommand(ExecuteCancel, CanExecuteCancel); }
        }
        private void ExecuteCancel(object parameter) {
            RefreshSelectedRaffle();
            RefreshSelectedItems();
            RefreshSelectedParticipants();
        }
        private bool CanExecuteCancel(object parameter) {
            if (SelectedRaffle != null)
                return true;
            return false;
        }

        public ICommand NewEntry {
            get { return new RelayCommand(NewExecute, CanNewExecute); } 
        }
        private void NewExecute(object obj) {
            AddRaffle();
        }
        private bool CanNewExecute(object obj) { 
            return true; 
        }

        public ICommand DeleteEntry { 
            get { return new RelayCommand(DeleteEntryExecute, CanDeleteEntryExecute); } 
        }
        private void DeleteEntryExecute(object obj) {
            DeleteRaffle();
        }
        private bool CanDeleteEntryExecute(object obj) {
            return SelectedRaffle != null;
        }
        #endregion

    }
}
