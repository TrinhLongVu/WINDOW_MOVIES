using System;
using System.Collections.Generic;
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
    class UserInfoViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get ; set; }
        public ICommand UpdateInfoCommand => new RelayCommand(() => {
            LoginViewModel.SetAccount(new Account {
                Id = LoginViewModel.GetAccount().Id,
                Username = Username,
                Password = "********" == Password ? LoginViewModel.GetAccount().Password : Hash.HashPassword(Password),
                Date = BirthDate.ToString("MM/dd/yyyy"),
                Role = LoginViewModel.GetAccount().Role,
            });
            new AccountDB().UpdateAccount(LoginViewModel.GetAccount());
            MessageBox.Show("Update success.");
        });

        public UserInfoViewModel() {
            var account = LoginViewModel.GetAccount();
            Username = account.Username;
            Password = "********";
            BirthDate = DateTime.Parse(account.Date);
        }
    }
}
