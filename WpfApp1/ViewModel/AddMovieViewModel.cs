using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
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

        public string Title { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Landscapre { get; set; }
        public string Release { get; set; }
        public string Runtime { get; set; }
        public string Detail { get; set; }


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

        public ICommand AddMovieBtn => new RelayCommand(AddMovieBtnFunc);

        private int HandlegetData(ArrayList datas, Filter x)
        {
            int result = -1;
            foreach(object obj in datas)
            {
                if (obj is Genre genre)
                {
                    result = genre.Id;
                    break;
                }
                else if(obj is Director d)
                {
                    result = d.Id;
                    break;
                }
                else if (obj is Star s)
                {
                    result = s.Id;
                    break;
                }
            }
            return result;
        }


        private void AddMovieBtnFunc()
        {
            int idGenre = HandlegetData(_genres, _SelectedGenre);
            int idDirector = HandlegetData(_director, _SelectedDirector);
            int idStar = HandlegetData(_star, _SelectedStar);
            MovieDB mdb = new MovieDB();
            Movie tmp = new Movie { IdGener = idGenre, Title = Title, Poster = Poster, Rating = Rating, Release = Release, Runtime = Runtime, Detail = Detail, Landscape = Landscapre};
            mdb.InsertMovie(tmp, idStar, idDirector);
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
