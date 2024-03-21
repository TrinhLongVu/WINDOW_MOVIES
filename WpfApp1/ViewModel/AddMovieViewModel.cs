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

        private Filter _SelectedFilter;
        private ArrayList _genres = new ArrayList();
        public Filter SelectedFilter
        {
            get => _SelectedFilter;
            set
            {
                _SelectedFilter = value;
                //FilterItems();
            }
        }
        public AddMovieViewModel()
        {
            GenreDB genreDB = new GenreDB();
            _genres = genreDB.GetAllGenre();
            GenreData = new ObservableCollection<Genre>(_genres.Cast<Genre>());
            
        }
        public ObservableCollection<Genre> GenreData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
