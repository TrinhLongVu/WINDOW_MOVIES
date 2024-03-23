using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class UserPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string LoginOrOutText { get; set; } = LoginViewModel.IsLogin() ? "Logout" : "Login";
        public UserPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OnLoginLinkClicked(object sender, RoutedEventArgs e) {
            if (LoginViewModel.IsLogin()) {
                LoginViewModel.Logout();
                LoginOrOutText = "Login";
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(LoginOrOutText)));
            } else {
                NavigationService.Navigate(new Login());
            }
        }

        private void SearchMovies(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UserBody.NavigationService.Navigate(new Search(SearchBox.Text));
                e.Handled = true;
            }
        }

        private void loginLink_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Login());
        }

        private void SearchBtn(object sender, RoutedEventArgs e)
        {
            UserBody.NavigationService.Navigate(new Search(SearchBox.Text));
        }

        private void navigateHome(object sender, RoutedEventArgs e)
        {
            UserBody.NavigationService.Navigate(new Home());
        }
    }
}
