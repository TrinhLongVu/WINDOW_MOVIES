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
    }
}
