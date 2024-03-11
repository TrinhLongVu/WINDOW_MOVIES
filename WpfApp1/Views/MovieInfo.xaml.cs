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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1.Views
{
    public partial class MovieInfo : Page
    {
        public MovieInfo()
        {
            InitializeComponent();
            Movie selectedMovie = new Movie
            {
                Name = "EXHUMA",
                Release = "2024",
                Runtime = "2h 14m",
                Rating = "7.5",
                Certification = "PG-16",
                Plot = "In Exhuma (2024), a spooky Korean family in LA calls on young shamans to battle a vengeful ancestor. The shamans track the source to a remote village and exhume the grave, unleashing a sinister force.  Their quest to appease the restless spirit turns into a fight for survival against a terrifying entity.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMzczMmQ0NTItM2JkZi00MTRhLTg5OGMtZWEyZTE2ZDgwM2FjXkEyXkFqcGdeQXVyMTU1MDczNjU1._V1_FMjpg_UY2048_.jpg"
            }; 
            DataContext = new MovieInfoViewModel(selectedMovie).SelectedMovie;
        }
    }
}
