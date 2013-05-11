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

    public class ManageItemsViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public ManageItemsViewModel() {
            using (AppContext context = new AppContext()) {
                context.Items.Load();
                ConvertCollection convert = new ConvertCollection();
                Items = convert.GetItemModelFrom(context.Items.Local);
            }
        }
        #endregion

        #region Properties
        private ItemModel selectedItem;
        public ItemModel SelectedItem {
            get { return selectedItem; }
            set {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
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
        #endregion

        #region Methods
        private void AddItem() {
            using (AppContext context = new AppContext()) {
                var item = context.Items.Create();
                item.Name = "<Enter Name>";
                item.Description = "<Enter Description>";
                item.Sku = "<Sku>";
                context.Items.Add(item);
                context.SaveChanges();
                var model = new ItemModel(item);
                Items.Add(model);
                SelectedItem = model;
            }
        }
        private void DeleteItem() {
            using (AppContext context = new AppContext()) {
                var item = context.Items.First(x => x.ItemId == selectedItem.ItemId);
                context.Items.Remove(item);
                context.SaveChanges();
            }
            Items.Remove(selectedItem);
        }
        private void UpdateItem() {
            using (AppContext context = new AppContext()) {
                var item = context.Items.First(x => x.ItemId == selectedItem.ItemId);
                context.Entry(item).CurrentValues.SetValues(selectedItem);
                context.SaveChanges();
            }
        }

        private void RefreshSelectedItem() {
            using (AppContext context = new AppContext()) {
                var dbItem = context.Items.First(r => r.ItemId == SelectedItem.ItemId);
                SelectedItem.Name = dbItem.Name;
                SelectedItem.Description = dbItem.Description;
                SelectedItem.Sku = dbItem.Sku;
            }
        }
        #endregion

        #region Commands
        public ICommand SaveChanges {
            get {
                return new RelayCommand(SaveExecute, CanSaveExecute);
            }
        }
        private void SaveExecute(object p) {
            UpdateItem();
        }
        private bool CanSaveExecute(object p) {
            if (SelectedItem != null) 
                return true;
            return false;
        }

        public ICommand CancelChanges { 
            get { 
                return new RelayCommand(CancelExecute, CanCancelExecute); 
            } 
        }
        private void CancelExecute(object obj) {
            RefreshSelectedItem();
        }
        private bool CanCancelExecute(object obj) {
            if (SelectedItem != null)
                return true;
            return false;
        }
        
        public ICommand NewEntry {
            get { return new RelayCommand(NewExecute, CanNewExecute); }
        }
        private void NewExecute(object obj) {
            AddItem();
        }
        private bool CanNewExecute(object obj) {            
            return true; 
        }

        public ICommand DeleteEntry {
            get { return new RelayCommand(DeleteEntryExecute, CanDeleteEntryExecute); }
        }
        private void DeleteEntryExecute(object obj) {
            DeleteItem();
        }
        private bool CanDeleteEntryExecute(object obj) { 
            return SelectedItem != null; 
        }
        #endregion   
    }    
}