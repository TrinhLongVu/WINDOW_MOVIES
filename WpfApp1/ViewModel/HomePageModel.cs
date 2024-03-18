using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class HomePageModel
    {
        public MovieCarousel TestCarousel { get; set; } = new MovieCarousel(4);
        public Movie Sample { get; set; } = new Movie {
            Title = "EXHUMA",
            Release = "2024",
            Runtime = "2h 14m",
            Rating = "7.5",
            Certification = "PG-16",
            Detail = "In Exhuma (2024), a spooky Korean family in LA calls on young shamans to battle a vengeful ancestor. The shamans track the source to a remote village and exhume the grave, unleashing a sinister force.  Their quest to appease the restless spirit turns into a fight for survival against a terrifying entity.",
            Poster = "https://m.media-amazon.com/images/M/MV5BMzczMmQ0NTItM2JkZi00MTRhLTg5OGMtZWEyZTE2ZDgwM2FjXkEyXkFqcGdeQXVyMTU1MDczNjU1._V1_FMjpg_UY2048_.jpg"
        };

        public HomePageModel() {
        }
    }
}
