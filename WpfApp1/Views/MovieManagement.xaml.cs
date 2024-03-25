using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class MovieManagement : Page
    {
        private MovieManageViewModel _model;
        public MovieManagement()
        {
            InitializeComponent();
            _model = new MovieManageViewModel();
            DataContext = _model;
        }

        private void AddMovie(object sender, System.Windows.RoutedEventArgs e)
        {
            AddMovie addMovieWindow = new AddMovie();
            addMovieWindow.ShowDialog();
            _model.Reload();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            _model.OpenUpdateMovie();
        }
    }
}
