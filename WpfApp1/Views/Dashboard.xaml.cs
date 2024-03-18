using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace WpfApp1.Views
{
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void AdminInitStatistic(object sender, RoutedEventArgs e)
        {
            (sender as Button).Focus();
        }

        private void MenuButtonFocus(object sender, RoutedEventArgs e)
        {
            Button focusedButton = sender as Button;
            if (focusedButton != null && focusedButton.IsFocused)
            {
                MessageBox.Show("Button is focused.");
            }
        }

        private void AdminLogOut(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
