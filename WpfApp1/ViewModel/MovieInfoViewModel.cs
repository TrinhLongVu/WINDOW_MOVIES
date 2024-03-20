using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class MovieInfoViewModel : INotifyPropertyChanged
    {
        public Movie SelectedMovie { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MovieInfoViewModel(Int32 Id)
        {
            MovieDB movieDB = new MovieDB();
            Movie selectedMovie = movieDB.GetMovie(Id);
            SelectedMovie = selectedMovie;
        }
    }
}
