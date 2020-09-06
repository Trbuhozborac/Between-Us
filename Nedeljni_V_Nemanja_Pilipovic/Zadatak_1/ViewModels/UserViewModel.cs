using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        #region Objects

        UserView userView;

        #endregion

        #region Constructors

        public UserViewModel(UserView userViewOpen, tblUser user)
        {
            userView = userViewOpen;
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

        #region Commands

        private ICommand manageFriends;
        public ICommand ManageFriends
        {
            get
            {
                if (manageFriends == null)
                {
                    manageFriends = new RelayCommand(param => ManageFriendsExecute(), param => CanManageFriendsExecute());
                }
                return manageFriends;
            }
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }


        #endregion

        #region Functions

        private void ManageFriendsExecute()
        {
            ManagerFriendsView view = new ManagerFriendsView(User);
            view.ShowDialog();
        }

        private bool CanManageFriendsExecute()
        {
            return true;
        }

        private void LogoutExecute()
        {
            userView.Close();
        }

        private bool CanLogoutExecute()
        {
            return true;
        }

        #endregion
    }
}
