using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raffles.Data.Services.Factory;
using Raffles.Data.Services.UnitOfWork;

namespace Raffles.ViewModels.Locator
{
    public class ViewModelLocator
    {
        private static RepositoryFactories factory = new RepositoryFactories();
        private static IRepositoryProvider provider = new RepositoryProvider(factory);
        private static IUnitOfWork uow = new UnitOfWork(provider);

        private static MainPageViewModel mainPageViewModel;
        public static MainPageViewModel MainPageViewModel {
            get {
                if (mainPageViewModel == null)
                    mainPageViewModel = new MainPageViewModel();
                return mainPageViewModel;
            }            
        }

        private static ManageItemsViewModel manageItemsViewModel;
        public static ManageItemsViewModel ManageItemsViewModel {
            get {
                if (manageItemsViewModel == null)
                    manageItemsViewModel = new ManageItemsViewModel();
                return manageItemsViewModel;
            }
        }

        private static ManageParticipantsViewModel manageParticipantsViewModel;
        public static ManageParticipantsViewModel ManageParticipantsViewModel {
            get {
                if (manageParticipantsViewModel == null)
                    manageParticipantsViewModel = new ManageParticipantsViewModel();
                return manageParticipantsViewModel;
            }
        }

        private static ManageRafflesViewModel manageRafflesViewModel;
        public static ManageRafflesViewModel ManageRafflesViewModel {
            get {
                if (manageRafflesViewModel == null)
                    manageRafflesViewModel = new ManageRafflesViewModel(uow);
                return manageRafflesViewModel;
            }
        }

        private static RafflePlayViewModel rafflePlayViewModel;
        public static RafflePlayViewModel RafflePlayViewModel {
            get {
                if (rafflePlayViewModel == null)
                    rafflePlayViewModel = new RafflePlayViewModel();
                return rafflePlayViewModel;
            }
        }

        private static RaffleWinnersViewModel raffleWinnersViewModel;
        public static RaffleWinnersViewModel RaffleWinnersViewModel {
            get {
                if (raffleWinnersViewModel == null)
                    raffleWinnersViewModel = new RaffleWinnersViewModel(uow);
                return raffleWinnersViewModel;
            }
        }
    }
}
