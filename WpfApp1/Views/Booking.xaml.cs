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
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        BookingModel model;
        public Booking(int movieId)
        {
            InitializeComponent();
            model = new BookingModel(movieId);
            DataContext = model;
            model.CloseCommand += () => {
                Close();
            };
        }

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            model.OnSelectedDateChanged();
        }

        private void OnSelectedTimeChanged(object sender, SelectionChangedEventArgs e) {
            model.OnSelectedTimeChanged();
        }

        private void ToggleAddRemoveCommand(object sender, RoutedEventArgs e) {
            var button = sender as Button;
            var seat = button.Content as Seat;
            bool isSelected = model.ToggleAddRemoveCommand(seat);
            this.Dispatcher.Invoke(() => {
                button.Background = new SolidColorBrush(isSelected ? Colors.Yellow : Colors.White);
            });
        }
    }
}
