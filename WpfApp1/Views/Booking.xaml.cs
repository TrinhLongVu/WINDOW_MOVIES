using Accessibility;
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
        private BookingModel _model;
        public Booking(int movieId)
        {
            _model = new BookingModel(movieId, () => {
                Close();
            });
            InitializeComponent();
            DataContext = _model;
        }

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            _model.OnSelectedDateChanged();
        }

        private void OnSelectedTimeChanged(object sender, SelectionChangedEventArgs e) {
            _model.OnSelectedTimeChanged();
        }

        private void ToggleAddRemoveCommand(object sender, RoutedEventArgs e) {
            var button = sender as Button;
            var seat = button.Content as Seat;
            bool isSelected = _model.ToggleAddRemoveCommand(seat);
            this.Dispatcher.Invoke(() => {
                button.Background = new SolidColorBrush(isSelected ? Colors.Yellow : Colors.White);
            });
        }

        private void OnCouponSelect(object sender, RoutedEventArgs e) {
            Button btn = sender as Button;
            Coupon cp = btn.Content as Coupon;
            if (_model.ToggleSelectCoupon(cp)) { // selected
                btn.Background = new SolidColorBrush(Colors.Yellow);
                btn.Foreground = new SolidColorBrush(Colors.White);
            } else { // unselected
                btn.Background = new SolidColorBrush(Colors.White);
                btn.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
    }
}
