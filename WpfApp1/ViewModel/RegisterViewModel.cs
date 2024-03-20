using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Database;
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
        AccountDB account;
        public ICommand RegisterBtn => new RelayCommand(RegisterButton);
        public event EventHandler<EventArgs> RegisterButtonClicked;

        public RegisterViewModel()
        {
            account = new AccountDB();
        }
        private void RegisterButton()
        {
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Password and confirm password is not match");
                return;
            }
        
            string newHashPassword = Hash.HashPassword(Password);
            account.Register("user", BirthDay.Date.ToString(), Username, newHashPassword);
            RegisterButtonClicked?.Invoke(this, EventArgs.Empty);
        }

    }
}
