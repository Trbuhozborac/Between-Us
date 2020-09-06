using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManagerFriendsView.xaml
    /// </summary>
    public partial class ManagerFriendsView : Window
    {
        public ManagerFriendsView(tblUser user)
        {
            InitializeComponent();
            this.DataContext = new ManageFriendsViewModel(this,user);
        }
    }
}
