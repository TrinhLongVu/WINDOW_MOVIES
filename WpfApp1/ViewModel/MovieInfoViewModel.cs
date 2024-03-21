using System;
using System.ComponentModel;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class MovieInfoViewModel : INotifyPropertyChanged
    {
        public InfoPageMovie SelectedMovie { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MovieInfoViewModel(Int32 Id)
        {
            MovieDB movieDB = new MovieDB();
            InfoPageMovie selectedMovie = movieDB.GetMovie(Id);
            SelectedMovie = selectedMovie;
        }
    }
}
