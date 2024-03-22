using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class AddMovieViewModel : INotifyPropertyChanged
    {

        private Filter _SelectedGenre;
        private Filter _SelectedDirector;
        private Filter _SelectedStar;

        private ArrayList _genres = new ArrayList();
        private ArrayList _director = new ArrayList();
        private ArrayList _star = new ArrayList();
        public Filter SelectedFilter
        {
            get => _SelectedGenre;
            set
            {
                _SelectedGenre = value;
            }
        }

        public Filter SelectedDirector
        {
            get => _SelectedDirector;
            set
            {
                _SelectedDirector = value;
            }
        }
        public Filter SelectedStar
        {
            get => _SelectedStar;
            set
            {
                _SelectedStar = value;
            }
        }

        public AddMovieViewModel()
        {
            GenreDB genreDB = new GenreDB();
            _genres = genreDB.GetAllGenre();
            GenreData = new ObservableCollection<Genre>(_genres.Cast<Genre>());

            DirectorDB directorDB = new DirectorDB();
            _director = directorDB.GetAllDirectors();
            DirectorData = new ObservableCollection<Director>(_director.Cast<Director>());

            StarDB starDB = new StarDB();
            _star = starDB.GetAllStar();
            StarData = new ObservableCollection<Star>(_star.Cast<Star>());
        }
        public ObservableCollection<Genre> GenreData { get; set; }
        public ObservableCollection<Director> DirectorData { get; set; }
        public ObservableCollection<Star> StarData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
