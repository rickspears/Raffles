namespace Raffles.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Input;
    using Raffles.Data;
    using Raffles.DomainObjects.Commands;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Events;
    using Raffles.DomainObjects.Models;

    public class ManageParticipantsViewModel : NotifyPropertyChanged
    {
        #region Constructor
        public ManageParticipantsViewModel() {
            using (AppContext context = new AppContext()) {
                context.Participants.Load();
                ConvertCollection convert = new ConvertCollection();
                Participants = convert.GetParticipantModelFrom(context.Participants.Local);
            }
        }
        #endregion

        #region Properties
        private ParticipantModel selectedParticipant;
        public ParticipantModel SelectedParticipant {
            get { return selectedParticipant; }
            set {
                selectedParticipant = value;
                OnPropertyChanged("SelectedParticipant");
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
        private void AddParticipant() {
            using (AppContext context = new AppContext()) {
                var participant = context.Participants.Create();

                participant.Name = "Update Name";
                participant.Contact = new DomainObjects.Entities.ContactDetails();
                participant.Contact.Address1 = "Update Contact Info";

                context.Participants.Add(participant);
                context.SaveChanges();

                SelectedParticipant = new ParticipantModel(participant);
                Participants.Add(SelectedParticipant);
            }
        }
        private void DeleteParticipant() {
            if (selectedParticipant != null) {
                using (AppContext context = new AppContext()) {
                    var participant = context.Participants.First(x => x.ParticipantId == selectedParticipant.ParticipantId);
                    context.Participants.Remove(participant);
                    context.SaveChanges();
                }
                Participants.Remove(selectedParticipant);
            }
        }
        private void UpdateParticipant() {
            using (AppContext context = new AppContext()) {
                var participant = context.Participants.First(x => x.ParticipantId == selectedParticipant.ParticipantId);
                context.Entry(participant).CurrentValues.SetValues(SelectedParticipant);
                context.SaveChanges();
            }
        }


        private void RefreshSelectedParticipant() {
            using (AppContext context = new AppContext()) {
                var dbParticipant = context.Participants.First(r => r.ParticipantId == SelectedParticipant.ParticipantId);
                SelectedParticipant.Name = dbParticipant.Name;
                SelectedParticipant.Contact = dbParticipant.Contact;
            }
        }
        #endregion

        #region Commands
        public ICommand SaveChanges {
            get { return new RelayCommand(ExecuteSave, CanExecuteSave); }
        }
        private void ExecuteSave(object obj) {
            UpdateParticipant();
        }
        private bool CanExecuteSave(object obj) {
            if (SelectedParticipant != null)
                return true;
            return false;
        }        

        public ICommand CancelChanges {
            get { return new RelayCommand(ExecuteCancel, CanExecuteCancel); }
        }
        private void ExecuteCancel(object obj) {
            RefreshSelectedParticipant();
        }
        private bool CanExecuteCancel(object obj) {
            if (SelectedParticipant != null)
                return true;
            return false;
        }        

        public ICommand NewEntry {
            get { return new RelayCommand(NewExecute, CanNewExecute); }
        }
        private void NewExecute(object obj) {
            AddParticipant();
        }
        private bool CanNewExecute(object obj) {
            return true; 
        }        

        public ICommand DeleteEntry {
            get { return new RelayCommand(DeleteEntryExecute, CanDeleteEntryExecute); }
        }
        private void DeleteEntryExecute(object obj) {
            DeleteParticipant();
        }
        private bool CanDeleteEntryExecute(object obj) {
            return SelectedParticipant != null;
        }
        
        #endregion
    }
}
