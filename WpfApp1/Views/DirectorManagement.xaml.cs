using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class DirectorManagement : Page
    {
        public DirectorManagement()
        {
            InitializeComponent();
            DataContext = new DirectorManageViewModel();
        }

        private void AddDirector(object sender, System.Windows.RoutedEventArgs e)
        {
            AddPerson addDirectorWindow = new AddPerson("director");
            addDirectorWindow.ShowDialog();
        }
    }
}
