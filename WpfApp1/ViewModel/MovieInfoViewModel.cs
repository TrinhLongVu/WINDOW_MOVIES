using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Database;
using WpfApp1.Models;
using WpfApp1.Views;

namespace WpfApp1.ViewModel
{
    class MovieInfoViewModel : INotifyPropertyChanged
    {
        public InfoPageMovie SelectedMovie { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand OnBookingClicked => new RelayCommand(() => {
            if (LoginViewModel.IsLogin()) {
                if (SelectedMovie == null) return;
                new Booking(SelectedMovie.Id).ShowDialog();
            } else {
                ((MainWindow)App.Current.MainWindow).frame.NavigationService.Navigate(new Login());
            }
        });

        public MovieInfoViewModel(Int32 Id)
        {
            MovieDB movieDB = new MovieDB();
            InfoPageMovie selectedMovie = movieDB.GetMovie(Id);
            SelectedMovie = selectedMovie;
        }
    }
}
