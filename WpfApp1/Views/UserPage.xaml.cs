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

namespace WpfApp1.Views
{
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void loginLink_Click(object sender, RoutedEventArgs e) {
            UserBody.NavigationService.Navigate(new Login());
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
