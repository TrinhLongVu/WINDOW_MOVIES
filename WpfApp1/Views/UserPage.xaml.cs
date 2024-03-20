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
<<<<<<< HEAD
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
=======
>>>>>>> 34a36b4e1be34170753419015bf638d091dbf8ff
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void loginLink_Click(object sender, RoutedEventArgs e) {
<<<<<<< HEAD
            Body.NavigationService.Navigate(new Login());
        }

        private void SearchBtn(object sender, RoutedEventArgs e)
        {
            Body.NavigationService.Navigate(new Search(SearchBox.Text));
=======
            UserBody.NavigationService.Navigate(new Login());
        }

        private void navigateHome(object sender, RoutedEventArgs e)
        {
            UserBody.NavigationService.Navigate(new Home());
>>>>>>> 34a36b4e1be34170753419015bf638d091dbf8ff
        }
    }
}
