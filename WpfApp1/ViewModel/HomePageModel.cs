using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class HomePageModel
    {
        public MovieCarousel TestCarousel { get; set; }
        public HomePageModel() {
            ArrayList movies = new MovieDB().GetAllMovie();
            TestCarousel = new MovieCarousel(new List<Movie>(movies.ToArray(typeof(Movie)) as Movie[]), 4);
        }
    }
}
