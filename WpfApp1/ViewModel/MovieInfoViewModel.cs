using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class MovieInfoViewModel
    {
        public Movie SelectedMovie { get; set; }

        public MovieInfoViewModel(Movie selectedMovie)
        {
            SelectedMovie = selectedMovie;
        }
    }
}
