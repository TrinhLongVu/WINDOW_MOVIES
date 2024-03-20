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

namespace WpfApp1.Views {
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page {
        HomePageModel viewModel;
        public Home() {
            InitializeComponent();
            viewModel = new HomePageModel();
            DataContext = viewModel;
            viewModel.SelectItemBtn += ViewModel_ClickItem;
        }

        private void ViewModel_ClickItem(object sender, Int32 Id)
        {
            NavigationService?.Navigate(new MovieInfo(Id));
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e) {
            var title = FindName("Checking") as TextBlock;
            title.Foreground = Brushes.Yellow;
        }

        private void OnItemClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
            
        }
    }
}
