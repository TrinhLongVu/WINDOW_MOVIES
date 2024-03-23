using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Database;
using WpfApp1.Models;
using WpfApp1.Utils;

namespace WpfApp1.ViewModel
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDay { get; set; }
        private AccountDB _account;
        private ArrayList _users = new ArrayList();
        public ICommand RegisterBtn => new RelayCommand(RegisterButton);
        public event EventHandler<EventArgs> RegisterButtonClicked;

        public RegisterViewModel()
        {
            _account = new AccountDB();
            _users = _account.GetAllUser();
        }
        private void RegisterButton()
        {
            if ((BirthDay == DateTime.MinValue) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword) || string.IsNullOrEmpty(Username))
            {
                MessageBox.Show("Please fill in all the information before continuing!");
                return;
            }
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Password and confirm password is not match");
                return;
            }

            foreach (Account user in _users)
            {
                if(user.Username == Username)
                {
                    MessageBox.Show("Username is existed");
                    return;
                }
            }
            string newHashPassword = Hash.HashPassword(Password);
            _account.Register("user", BirthDay.Date.ToString(), Username, newHashPassword);
            RegisterButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
