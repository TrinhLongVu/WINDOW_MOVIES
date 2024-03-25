using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class DirectorManagement : Page
    {
        private DirectorManageViewModel _model;
        public DirectorManagement()
        {
            InitializeComponent();
            _model = new DirectorManageViewModel();
            DataContext = _model;
        }

        private void AddDirector(object sender, System.Windows.RoutedEventArgs e)
        {
            AddPerson addDirectorWindow = new AddPerson("director");
            addDirectorWindow.ShowDialog();
            _model.Reload();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            _model.OpenUpdateDirector();
        }
    }
}
