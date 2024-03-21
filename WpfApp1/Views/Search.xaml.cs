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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        private SearchViewModel viewModel;
        public Search(string stringSearch)
        {
            InitializeComponent();
            viewModel = new SearchViewModel(stringSearch);
            DataContext = viewModel;
            viewModel.SelectItemBtn += ViewModel_ClickItem;
        }

        private void ViewModel_ClickItem(object sender, Int32 Id)
        {
            NavigationService?.Navigate(new MovieInfo(Id));
        }
    }
}
