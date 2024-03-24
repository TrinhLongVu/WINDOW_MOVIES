using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class MovieManagement : Page
    {
        public MovieManagement()
        {
            InitializeComponent();
            DataContext = new MovieManageViewModel();
        }

        private void AddMovie(object sender, System.Windows.RoutedEventArgs e)
        {
            AddMovie addMovieWindow = new AddMovie();
            addMovieWindow.ShowDialog();
        }
    }
}
