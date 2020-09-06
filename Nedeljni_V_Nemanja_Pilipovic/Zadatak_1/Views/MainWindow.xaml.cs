using System.Collections.Generic;
using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;
using Zadatak_1.Views;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _username;
        private string _password;
        private bool _logged = false;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _username = txtUsername.Text;
            _password = txtPassword.Password;

            List<tblUser> users = new List<tblUser>();
            using(BetweenUsDbEntities db = new BetweenUsDbEntities())
            {
                foreach (tblUser user in db.tblUsers)
                {
                    users.Add(user);
                }
            }

            for (int i = 0; i < users.Count; i++)
            {
                if(users[i].Username == _username && users[i].Password == _password)
                {
                    _logged = true;
                    UserView view = new UserView(users[i]);
                    view.ShowDialog();
                    ClearCredentials();
                }              
                else
                {
                    continue;
                }
            }

            if(_logged == false)
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void ClearCredentials()
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
        }
    }
}
