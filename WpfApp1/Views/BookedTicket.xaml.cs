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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for BookedTicket.xaml
    /// </summary>
    public partial class BookedTicket : Page
    {
        private BookedTicketViewModel _model;
        public BookedTicket()
        {
            _model = new BookedTicketViewModel();
            DataContext = _model;
            InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            _model.OpenMovieInfo(NavigationService);
        }
    }
}
