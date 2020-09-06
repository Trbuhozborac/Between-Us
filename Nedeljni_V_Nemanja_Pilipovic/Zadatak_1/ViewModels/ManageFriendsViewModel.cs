using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManageFriendsViewModel : BaseViewModel
    {
        #region Objects

        ManagerFriendsView manageView;

        #endregion

        #region Constructors

        public ManageFriendsViewModel(ManagerFriendsView manageViewOpen, tblUser user)
        {
            manageView = manageViewOpen;
            User = user;
        }

        #endregion

        #region Properties

        private tblUser user;

        public tblUser User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        #endregion
    }
}
