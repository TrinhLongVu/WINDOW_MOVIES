using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
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
