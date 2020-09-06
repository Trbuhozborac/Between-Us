using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        #region Objects

        RegisterView registerView;

        #endregion

        #region Constructors

        public RegisterViewModel(RegisterView registerViewOpen)
        {
            registerView = registerViewOpen;
            User = new tblUser();
            Genders = GetBothGender();
        }

        #endregion

        #region Properties

        private tblUser user;

        public tblUser User
        {
            get { return user; }
            set { user = value; }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set 
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private List<string> genders;

        public List<string> Genders
        {
            get { return genders; }
            set 
            {
                genders = value;
                OnPropertyChanged("Genders");
            }
        }

        #endregion

        #region Commands

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        #endregion

        #region Functions

        private void SaveExecute()
        {
            try
            {
                using (BetweenUsDbEntities db = new BetweenUsDbEntities()) 
                {
                    User.Gender = Gender;
                    db.tblUsers.Add(User);
                    db.SaveChanges();
                }
                MessageBox.Show("Registrated Successfully!");
                registerView.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(User.Name) || String.IsNullOrEmpty(User.Surname)
                || String.IsNullOrEmpty(Gender) || String.IsNullOrEmpty(User.DateOfBirth.ToString())
                || String.IsNullOrEmpty(User.Username)
                || String.IsNullOrEmpty(User.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CloseExecute()
        {
            registerView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        private List<string> GetBothGender()
        {
            List<string> genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");
            return genders;
        }

        #endregion
    }
}
