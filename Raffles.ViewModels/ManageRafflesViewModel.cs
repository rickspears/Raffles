namespace Raffles.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Input;
    using Raffles.Data.Services;
    using Raffles.DomainObjects.Commands;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Entities;
    using Raffles.DomainObjects.Events;
    using Raffles.DomainObjects.Models;

    public class ManageRafflesViewModel : NotifyPropertyChanged
    {
        public ManageRafflesViewModel() {
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
                Items = convert.GetItemModelFrom(context.Items.Local);
                Participants = convert.GetParticipantModelFrom(context.Participants.Local);
            }
        }

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
            using (AppContext context = new AppContext()) {
                var raffle = context.Raffles.Create();
                raffle.Location = new ContactDetails();
                raffle.Name = "<Enter Name, and Select Items and Participants>";
                raffle.Location.Address1 = "<Enter Location and Contact Details>";
                raffle.RaffleParticipants = new ObservableCollection<RaffleParticipant>();
                raffle.RaffleItems = new ObservableCollection<RaffleItem>();

                context.Raffles.Add(raffle);
                context.SaveChanges();
                SelectedRaffle = new RaffleModel(raffle);
                Raffles.Add(SelectedRaffle);
                ClearSelectedItems();
                ClearSelectedParticipants();
            }            

        }
        private void DeleteRaffle() {
            using (AppContext context = new AppContext()) {
                var raffle = context.Raffles.First(r => r.RaffleId == SelectedRaffle.RaffleId);
                context.Raffles.Remove(raffle);
                context.SaveChanges();
            }
            Raffles.Remove(SelectedRaffle);
        }
        private void UpdateRaffle() {
            using (AppContext context = new AppContext()) {
                context.Items.Include(i => i.RaffleItems).Load();
                context.Participants.Include(i => i.RaffleParticipants).Load();
                var raffle = context.Raffles.Include(r => r.RaffleItems)
                                            .Include(r=>r.RaffleParticipants)
                                            .First(r => r.RaffleId == SelectedRaffle.RaffleId);

                context.Entry(raffle).CurrentValues.SetValues(SelectedRaffle);               
                UpdateRaffleItems(context, raffle);
                UpdateRaffleParticipants(context, raffle);

                context.SaveChanges();
            }
        }

        private void UpdateRaffleItems(AppContext context, Raffle raffle) {
            foreach (var dbRaffleItem in raffle.RaffleItems.ToList())
                if (Items.Any(i => !i.IsIncluded && i.ItemId == dbRaffleItem.ItemId)) {
                    var temp = SelectedRaffle.RaffleItems.FirstOrDefault(t => t.ItemId == dbRaffleItem.ItemId);
                    SelectedRaffle.RaffleItems.Remove(temp);
                    context.RaffleItems.Remove(dbRaffleItem);
                }

            foreach (var checkedItem in Items) {
                if (checkedItem.IsIncluded) {
                    var dbRaffleItem = raffle.RaffleItems.FirstOrDefault(
                                            i => i.ItemId == checkedItem.ItemId
                                            && i.RaffleId == SelectedRaffle.RaffleId);
                    if (dbRaffleItem != null) {
                        context.Entry(dbRaffleItem).CurrentValues.SetValues(checkedItem);
                        SelectedRaffle.RaffleItems.First(t => t.ItemId == dbRaffleItem.ItemId).ItemCount = dbRaffleItem.ItemCount;                            
                    }
                    else {
                        RaffleItem raffleItem = new RaffleItem() {
                            RaffleId = SelectedRaffle.RaffleId,
                            Raffle = raffle,
                            ItemId = checkedItem.ItemId,
                            Item = context.Items.FirstOrDefault(i => i.ItemId == checkedItem.ItemId),
                            ItemCount = checkedItem.ItemCount
                        };
                        SelectedRaffle.RaffleItems.Add(raffleItem);
                        raffle.RaffleItems.Add(raffleItem);
                    }
                }           
            }
        }
        private void UpdateRaffleParticipants(AppContext context, Raffle raffle) {           
            foreach (var dbRaffleParticipant in raffle.RaffleParticipants.ToList())
                if (Participants.Any(p => !p.IsRegistered
                    && p.ParticipantId == dbRaffleParticipant.ParticipantId)) {
                    var temp = SelectedRaffle.RaffleParticipants.FirstOrDefault(t => t.ParticipantId == dbRaffleParticipant.ParticipantId);
                    SelectedRaffle.RaffleParticipants.Remove(temp);
                    context.RaffleParticipants.Remove(dbRaffleParticipant);
                }

            foreach (var checkedParticipant in Participants) {
                if (checkedParticipant.IsRegistered) {
                    var dbRaffleParticipant = raffle.RaffleParticipants.FirstOrDefault(
                                        p => p.ParticipantId == checkedParticipant.ParticipantId
                                        && p.RaffleId == SelectedRaffle.RaffleId);
                    if (dbRaffleParticipant != null) {
                        context.Entry(dbRaffleParticipant).CurrentValues.SetValues(checkedParticipant);
                        SelectedRaffle.RaffleParticipants.First(p => p.ParticipantId == dbRaffleParticipant.ParticipantId).TicketCount = dbRaffleParticipant.TicketCount;
                    }
                    else {
                        RaffleParticipant raffleParticipant = new RaffleParticipant() {
                            RaffleId = SelectedRaffle.RaffleId,
                            Raffle = raffle,
                            ParticipantId = checkedParticipant.ParticipantId,
                            Participant = context.Participants.FirstOrDefault(p => p.ParticipantId == checkedParticipant.ParticipantId),
                            TicketCount = checkedParticipant.TicketCount
                        };
                        SelectedRaffle.RaffleParticipants.Add(raffleParticipant);
                        raffle.RaffleParticipants.Add(raffleParticipant);
                    }
                }
            }
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
