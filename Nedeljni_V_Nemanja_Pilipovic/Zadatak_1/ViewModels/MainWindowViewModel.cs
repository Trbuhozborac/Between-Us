using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Objects

        MainWindow main;

        #endregion

        #region Constructors

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }

        #endregion

        #region Properties



        #endregion

        #region Commands

        private ICommand register;
        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    register = new RelayCommand(param => RegisterExecute(), param => CanRegisterExecute());
                }
                return register;
            }
        }

        #endregion

        #region Functions

        private void RegisterExecute()
        {
            RegisterView view = new RegisterView();
            view.ShowDialog();
        }

        private bool CanRegisterExecute()
        {
            return true;
        }

        #endregion
    }
}
