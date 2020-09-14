using DataAccess;
using MVVMDemo.Commands;
using MVVMDemo.Views;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    public class MainViewModel : ViewPropertyChanged
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value;  OnPropertyChanged(nameof(Username)); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand Login
        {
            get
            {
                
                return new DelegateCommand(LoginToApp, true);
            }
        }

        public Database Instance { get; set; }

        public MainViewModel()
        {
            Instance = Database.GetDatabase();
            
        }

        private void LoginToApp(object parameter = null)
        {
            var user = Instance.Login(Username, Password);
            if(user != null)
            {
                Window window = new HomeView();
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show($"{Username} does not exists");
            }
        }
    }
}
