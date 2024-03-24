using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class CastManagement : Page
    {
        public CastManagement()
        {
            InitializeComponent();
            DataContext = new CastManageViewModel();
        }

        private void AddCast(object sender, System.Windows.RoutedEventArgs e)
        {
            AddPerson addCastWindow = new AddPerson("cast");
            addCastWindow.ShowDialog();
        }
    }
}
