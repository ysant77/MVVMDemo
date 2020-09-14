using DataAccess;
using MVVMDemo.Commands;
using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    public class HomeViewModel : ViewPropertyChanged
    {
        private ObservableCollection<User> _users;
        private readonly Database _database;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged(nameof(Users)); }
        }

        public HomeViewModel()
        {
            Users = new ObservableCollection<User>();
            _database = Database.GetDatabase();
            InitializeUsersFromDB(_database.GetUsers());
            Users.Add(new User { Id = 10, Username = "hhh", DateOfBirth = DateTime.Now, IsLoggedIn = false });
        }

        private void InitializeUsersFromDB(List<User> users)
        {
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public ICommand Show
        {
            get
            {
                return new DelegateCommand(ShowUserDetails, true);
            }
        }
        private void ShowUserDetails(object parameter)
        {
            var user = Users.ToList().FirstOrDefault(u => u.Id == (parameter as User).Id);
            MessageBox.Show($"Hello {user.Username}");
        }
    }
}
