using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
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
