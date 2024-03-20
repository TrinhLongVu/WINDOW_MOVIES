using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Views;
using System.Windows.Navigation;
using WpfApp1.Database;
using System.Collections;
using WpfApp1.Models;
using WpfApp1.Utils;

namespace WpfApp1.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Username{get; set;}
        public string Password{ get; set; }
        private ArrayList _users = new ArrayList();
        public LoginViewModel()
        {
            AccountDB account = new AccountDB();
            _users = account.GetAllUser();
        }
        public ICommand LoginBtn => new RelayCommand(LoginButton);
        public event EventHandler<bool> LoginButtonClicked;
        private void LoginButton()
        {
            bool isUser = true;

            foreach(Account user in _users)
            {
                if(user.Username == Username && Hash.VerifyPassword(user.Password, Password))
                {
                    if(user.Role == "user")
                    {
                        isUser = true;
                    }
                    else
                    {
                        isUser = false;
                    }
                    LoginButtonClicked?.Invoke(this, isUser);
                    return;
                }
            }
            MessageBox.Show("Username or Password is not correct!!!");
        }
    }
}
