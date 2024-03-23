using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class Register : Page
    {
        private RegisterViewModel viewModel;
        public Register()
        {
            viewModel = new RegisterViewModel();
            DataContext = viewModel;
            viewModel.RegisterButtonClicked += ViewModel_RegisterButtonClicked;
            InitializeComponent();
        }
        private void ViewModel_RegisterButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully registered!!");
            NavigationService?.Navigate(new Login());
        }

        private void RegisterEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.RegisterBtn.Execute(null);
                e.Handled = true;
            }
        }

        private void Navigate_Login(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
