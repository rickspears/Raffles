namespace Raffles.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Raffles.Data;
    using Raffles.DomainObjects.Commands;
    using Raffles.DomainObjects.Converters;
    using Raffles.DomainObjects.Events;
    using Raffles.DomainObjects.Models;

    public class RaffleWinnersViewModel : NotifyPropertyChanged
    {
        public RaffleWinnersViewModel() {
            using (AppContext context = new AppContext()) {
                context.Raffles.Load();
                ConvertCollection convert = new ConvertCollection();
                Raffles = convert.GetRaffleModelFrom(context.Raffles.Local);
                if (Raffles.Count > 0) SelectedRaffle = Raffles[0];
            }
        }

        private RaffleModel selectedRaffle;
        public RaffleModel SelectedRaffle {
            get { return selectedRaffle; }
            set { 
                selectedRaffle = value;
                OnPropertyChanged("SelectedRaffle");
                //ClearAllResults();
                using (AppContext context = new AppContext()) {
                    //SetResults(context);
                    //if (Results.Count > 0) SelectedResult = Results[0];  
                }
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

        //private ObservableCollection<ResultsModel> results;
        //public ObservableCollection<ResultsModel> Results {
        //    get { return results; }
        //    set {
        //        results = value;
        //        OnPropertyChanged("Results");
        //    }
        //}
        
        #region Helper Methods
        //private void ClearAllResults() {
        //    SelectedResult = null;
        //    Results = null;
        //}

        //private void SetResults(AppContext context){
        //    var resultQuery = from r in context.Results
        //                where r.RaffleId == SelectedRaffle.RaffleId
        //                select r;
        //    ConvertCollection convert = new ConvertCollection();
        //    Results = convert.GetResultsFrom(resultQuery);                      
        //}
        #endregion
        /*
        #region Commands
        //    Requires adding PresentationFramework reference
        //    Requires adding using System.Windows.Controls
        //    Instead, rely on a cascading effect between ItemsSource and SelectedItem for the comboboxes and datagrid
        
        private void ViewResultsExecute(object parameter) { 
             
        }
        private bool ViewResultsCanExecute(object parameter) { return true; }
        public ICommand ViewResults {
            get { return new RelayCommand(ViewResultsExecute, ViewResultsCanExecute); }
        }
        #endregion
        */
    }
}
