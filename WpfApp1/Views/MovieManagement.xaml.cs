using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using WpfApp1.Models;
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
    }
}
