using System;
using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
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
