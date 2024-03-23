using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class HomePageModel : INotifyPropertyChanged
    {
        public MovieCarousel AllMovieCarousel { get; set; }
        public MovieCarousel AiringMovieCarousel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Movie SelectedItem { get; set; }
        public HomePageModel() {
            ArrayList movies = new MovieDB().GetAllMovie();
            AllMovieCarousel = new MovieCarousel(new List<Movie>(movies.ToArray(typeof(Movie)) as Movie[]), 2);
            AiringMovieCarousel = new MovieCarousel(new List<Movie>(movies.ToArray(typeof(Movie)) as Movie[]), 2);
            PropertyChanged += MyViewModel_PropertyChanged;
        }

        public event EventHandler<Int32> SelectItemBtn;
        private void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem))
            {
                SelectItemBtn?.Invoke(this, SelectedItem.Id);
            }
        }

    }
}
