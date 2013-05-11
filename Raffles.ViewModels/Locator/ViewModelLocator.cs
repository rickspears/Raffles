using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raffles.ViewModels.Locator
{
    public class ViewModelLocator
    {
        private static MainPageViewModel mainPageViewModel;
        public static MainPageViewModel MainPageViewModel {
            get { return mainPageViewModel != null ? mainPageViewModel : new MainPageViewModel(); }            
        }

        private static ManageItemsViewModel manageItemsViewModel;
        public static ManageItemsViewModel ManageItemsViewModel {
            get { return manageItemsViewModel != null ? manageItemsViewModel : new ManageItemsViewModel(); }
        }

        private static ManageParticipantsViewModel manageParticipantsViewModel;
        public static ManageParticipantsViewModel ManageParticipantsViewModel {
            get { return manageParticipantsViewModel != null ? manageParticipantsViewModel : new ManageParticipantsViewModel(); }
        }

        private static ManageRafflesViewModel manageRafflesViewModel;
        public static ManageRafflesViewModel ManageRafflesViewModel {
            get { return manageRafflesViewModel != null ? manageRafflesViewModel : new ManageRafflesViewModel(); }
        }

        private static RaffleWinnersViewModel raffleWinnersViewModel;
        public static RaffleWinnersViewModel RaffleWinnersViewModel {
            get { return raffleWinnersViewModel != null ? raffleWinnersViewModel : new RaffleWinnersViewModel(); }
        }
    }
}
