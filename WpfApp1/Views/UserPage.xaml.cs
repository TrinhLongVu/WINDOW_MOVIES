using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1.Views
{
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
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
