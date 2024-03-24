using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{

    class BookingModel: INotifyPropertyChanged
    {
        private MovieScheduleDB _db = new MovieScheduleDB();
        private int _movieId;

        public ObservableCollection<Coupon> Coupons { get; }
        private List<Coupon> _selectedCoupons;

        public event PropertyChangedEventHandler PropertyChanged;
        
        private List<MovieSchedule> _movieSchedules;

        public ObservableCollection<string> Dates { get; }
        public string DateSelected { get; set; }

        public ObservableCollection<Schedule> Times { get; set; }
        public int TimeSelected { get; set; }

        private List<Seat> _allSeats;
        public ObservableCollection<Seat> Seats { get; set;  }

        private List<Seat> _bookingSeat;

        public Action CloseCommand;
        public BookingModel(int movieId) {
            _movieId = movieId;
            _movieSchedules = _db.GetSchedules(movieId);
            if (_movieSchedules.Count == 0) {
                MessageBox.Show("Missing schedule for this movie");
                CloseCommand();
            }
            Dates = new ObservableCollection<string>(_movieSchedules.GroupBy(x => x.Date).Select(x => x.Key.ToString("dd-MM-yyyy")).ToList());
            DateSelected = Dates.First();
            _bookingSeat = new List<Seat>();
            _allSeats = new SeatDB().GetAllSeats()
                                  .ConvertAll<Seat>((seat /*(string, int)*/) => new Seat(seat.Position, true, seat.Id));
            Coupons = new ObservableCollection<Coupon>(new CouponDB().GetAvailableCoupons(LoginViewModel.GetAccount().Id));
            _selectedCoupons = new List<Coupon>();
        }   
        public bool ToggleSelectCoupon(Coupon cp) {
            if (_selectedCoupons.Find(x => x.Id == cp.Id) != null) {
                _selectedCoupons.RemoveAll(x => x.Id == cp.Id);
                return false;
            } else {
                _selectedCoupons.Add(cp);
                return true;
            }
        }

        public void OnSelectedDateChanged() {
            Times = new ObservableCollection<Schedule>(_db.GetAllTimes(_movieId, DateTime.ParseExact(DateSelected, "dd-MM-yyyy", null)));
            TimeSelected = 0;   
        }

        public void OnSelectedTimeChanged() {
            if (TimeSelected == -1) { // ItemsSource changed trigger this event and make TimeSelected = -1
                TimeSelected = 0;
            }
            List<string> takenSeats = new TicketDB().GetAllBookedSeats(
                                                    _movieId,
                                                    DateTime.ParseExact(DateSelected, "dd-MM-yyyy", null),
                                                    Times[TimeSelected].Time);
            _allSeats.ForEach((seat) => seat.IsAvailable = !takenSeats.Contains(seat.Position));
            Seats = new ObservableCollection<Seat>(_allSeats);
            _bookingSeat.Clear();
        }


        // Output: Seat is selected or not
        public bool ToggleAddRemoveCommand(Seat seat) {
            if (_bookingSeat.Find(x => x.Position == seat.Position) != null) {
                _bookingSeat.RemoveAll(x => x.Position == seat.Position);
                return false;
            } else {
                _bookingSeat.Add(seat);
                return true;
            }
        }

        public ICommand BookAllSeatsCommand => new RelayCommand(() => {
            if (!LoginViewModel.IsLogin()) throw new Exception("Unexpected, must login begin book ticket");
            if (_bookingSeat.Count > 0)
            {
                double discount = 0;
                var couponDB = new CouponDB();
                foreach (Coupon cp in _selectedCoupons) {
                    discount += cp.Discount;
                    discount = Math.Min(discount, 1);
                    couponDB.RemoveCoupon(cp.Id);
                }
                double price = 90000 * (1 - discount);
                foreach (Seat seat in _bookingSeat)
                {
                    new TicketDB().AddTicket(
                        LoginViewModel.GetAccount(),
                        seat,
                        _movieSchedules.Find(x => (x.Date.ToString("dd-MM-yyyy") == DateSelected) && (x.IdSchedule == Times[TimeSelected].Id)),
                        DateTime.Now,
                        price);
                }
                MessageBox.Show($"Successfully booked the ticket with: {price * _bookingSeat.Count}đ!");
                _bookingSeat.Clear();
                CloseCommand();
                return;
            }
            MessageBox.Show("Please choose a ticket before confirming!");
        });
    }
}
