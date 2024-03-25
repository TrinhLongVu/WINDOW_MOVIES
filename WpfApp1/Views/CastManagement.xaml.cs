using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class CastManagement : Page
    {
        private CastManageViewModel _model;
        public CastManagement()
        {
            InitializeComponent();
            _model = new CastManageViewModel();
            DataContext = _model;
        }

        private void AddCast(object sender, System.Windows.RoutedEventArgs e)
        {
            AddPerson addCastWindow = new AddPerson("cast");
            addCastWindow.ShowDialog();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            _model.OpenUpdateStar();
        }
    }
}
