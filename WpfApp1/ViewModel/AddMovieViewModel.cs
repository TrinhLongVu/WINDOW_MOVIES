using Microsoft.Win32.SafeHandles;
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
        public ObservableCollection<Genre> GenreData { get; set; }
        public ObservableCollection<Director> DirectorData { get; set; }
        public ObservableCollection<Star> StarData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private ArrayList _genres = new ArrayList();
        private ArrayList _director = new ArrayList();
        private ArrayList _star = new ArrayList();

        public string Title { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Landscape { get; set; }
        public string Release { get; set; }
        public string Runtime { get; set; }
        public string Detail { get; set; }
        public string ManageType { get; set; }
        public Genre SelectedGenre { get; set; }
        public Director SelectedDirector { get; set; }
        public Star SelectedStar { get; set; }

        public ICommand AddMovieBtn { get; set; }

        private int _updatingId = 0;

        private int HandlegetData(ArrayList datas)
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
            if(SelectedGenre == null || SelectedDirector == null || SelectedStar == null || Title == "" || Poster == "" || Release == "" || Rating == 0 || Runtime == "" || Detail == "" || Landscape == "")
            {
                MessageBox.Show("Please provide enough info");
                return;
            }
            int idGenre = SelectedGenre.Id;
            int idDirector = SelectedDirector.Id;
            int idStar = SelectedStar.Id;
            MovieDB mdb = new MovieDB();
            Movie tmp = new Movie { IdGener = idGenre, Title = Title, Poster = Poster, Rating = Rating, Release = Release, Runtime = Runtime, Detail = Detail, Landscape = Landscape};
            mdb.InsertMovie(tmp, idStar, idDirector);
            MessageBox.Show("Add successfully");
        }

        private void _updateMovieBtnFunc() {
            if (SelectedGenre == null || SelectedDirector == null || SelectedStar == null || Title == "" || Poster == "" || Release == "" || Rating == 0 || Runtime == "" || Detail == "" || Landscape == "") {
                MessageBox.Show("Please provide enough info");
                return;
            }
            int idGenre = SelectedGenre.Id;
            int idDirector = SelectedDirector.Id;
            int idStar = SelectedStar.Id;
            MovieDB mdb = new MovieDB();
            Movie tmp = new Movie { Id = _updatingId, IdGener = idGenre, Title = Title, Poster = Poster, Rating = Rating, Release = Release, Runtime = Runtime, Detail = Detail, Landscape = Landscape };
            mdb.UpdateMovie(tmp, idDirector, idStar);
            MessageBox.Show("Update successfully");
        }

        public AddMovieViewModel(int originalId) {
            _updatingId = originalId;
            InfoPageMovie original = new MovieDB().GetMovie(originalId);
            Title = original.Title;
            Poster = original.Poster;
            Rating = original.Rating ?? 0;
            Landscape = original.Landscape;
            Release = original.Release;
            Runtime = original.Runtime;
            Detail = original.Detail;

            GenreDB genreDB = new GenreDB();
            _genres = genreDB.GetAllGenre();
            GenreData = new ObservableCollection<Genre>(_genres.Cast<Genre>());

            DirectorDB directorDB = new DirectorDB();
            _director = directorDB.GetAllDirectors();
            DirectorData = new ObservableCollection<Director>(_director.Cast<Director>());

            StarDB starDB = new StarDB();
            _star = starDB.GetAllStar();
            StarData = new ObservableCollection<Star>(_star.Cast<Star>());


            SelectedGenre = GenreData.ToList().Find(x => x.Id == original.IdGener);
            SelectedDirector = DirectorData.ToList().Find(x => x.Name == original.NameDirector);
            SelectedStar = StarData.ToList().Find(x => x.Name == original.NameStar);
            
            ManageType = "Update";
            AddMovieBtn = new RelayCommand(_updateMovieBtnFunc);
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

            AddMovieBtn = new RelayCommand(AddMovieBtnFunc);
            ManageType = "Add";
        }

    }
}
