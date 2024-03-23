﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
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

            if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(Username))
            {
                MessageBox.Show("Please enter all the information before continuing");
                return;
            }
            foreach (Account user in _users)
            {  
                if (user.Username == Username && Hash.VerifyPassword(Password, user.Password))
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
