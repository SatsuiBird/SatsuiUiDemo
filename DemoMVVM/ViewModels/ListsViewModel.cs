using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SatsuiUi.Commands;
using System.Windows;

namespace DemoMVVM.ViewModels
{
    public class ListsViewModel : INotifyPropertyChanged
    {

        #region MyUsers

        private ObservableCollection<MyUserViewModel> myUsers;
        public ObservableCollection<MyUserViewModel> MyUsers
        {
            get { return this.myUsers; }
            set
            {
                if(value != this.myUsers)
                {
                    this.myUsers = value;
                    this.NotifyPropertyChanged("MyUsers");
                }
            }
        }

        #endregion


        #region SelectedUser

        private MyUserViewModel selectedUser = null;
        public MyUserViewModel SelectedUser
        {
            get { return this.selectedUser; }
            set
            {
                if(value != this.selectedUser)
                {
                    this.selectedUser = value;
                    this.NotifyPropertyChanged("SelectedUser");
                }
            }
        }

        #endregion


        public ListsViewModel()
        {
            // Creating firsts users
            this.MyUsers = new ObservableCollection<MyUserViewModel>();
            this.MyUsers.Add(new MyUserViewModel("SatsuiBird", "satsuibird@messatsu-dojo.com", true));
            this.MyUsers.Add(new MyUserViewModel("Nawers", "nawers@messatsu-dojo.com", true));
            this.MyUsers.Add(new MyUserViewModel("Zechs", "zechs@messatsu-dojo.com", true));
        }


        #region Commands

        #region UsersEditCommand

        private RelayCommand usersEditCommand = null;
        public RelayCommand UsersEditCommand
        {
            get
            {
                if (this.usersEditCommand == null) this.usersEditCommand = new RelayCommand(this.OnUsersEdit, this.CanUsersEdit);
                return this.usersEditCommand;
            }
            set
            {
                if (value != this.usersEditCommand)
                {
                    this.usersEditCommand = value;
                    this.NotifyPropertyChanged("UsersEditCommand");
                }
            }
        }

        public bool CanUsersEdit(object obj)
        {
            string id = obj.ToString();

            if (((id == "show") || (id == "delete")) && (this.SelectedUser == null)) return false;
            return true;
        }

        public void OnUsersEdit(object obj)
        {
            string id = obj.ToString();

            if (id == "show") MessageBox.Show("Selected item : " + this.SelectedUser, "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (id == "add") this.MyUsers.Add(new MyUserViewModel());
            else if (id == "delete") this.MyUsers.Remove(this.SelectedUser);
        }


        #endregion

        #endregion


        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        #endregion
    }
}
