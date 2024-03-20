using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private LoginViewModel viewModel;
        public Login()
        {
            InitializeComponent();

            viewModel = new LoginViewModel();
            DataContext = viewModel;
            viewModel.LoginButtonClicked += ViewModel_LoginButtonClicked;
        }

        private void NavigateRegister(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        private void ViewModel_LoginButtonClicked(object sender, bool isUser)
        {
            if (isUser)
            {
                NavigationService?.Navigate(new UserPage());
            }
            else
            {
                NavigationService?.Navigate(new Dashboard());
            }
        }
    }
}
