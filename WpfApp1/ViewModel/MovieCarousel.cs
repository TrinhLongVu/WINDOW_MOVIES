using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class MovieCarousel : INotifyPropertyChanged
    {
        public List<Movie> MovieCollection { get; set; }

        private List<Movie> _movies;

        private int CurrentPage = 0;

        private int _itemPerPage = 4;

        private int _totalPage = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public MovieCarousel(int itemPerPage = 4) {
            _itemPerPage = itemPerPage;
            _movies = new List<Movie>();
            for (int i = 0; i < 10; i++) {
                _movies.Add(new Movie {
                    Title = "EXHUMA WQEQ WE QWE QWEQ EQW" + i.ToString(),
                    Release = "2024",
                    Runtime = "2h 14m",
                    Rating = "7.5",
                    Certification = "PG-16",
                    Detail = "In Exhuma (2024), a spooky Korean family in LA calls on young shamans to battle a vengeful ancestor. The shamans track the source to a remote village and exhume the grave, unleashing a sinister force.  Their quest to appease the restless spirit turns into a fight for survival against a terrifying entity.",
                    Poster = "https://m.media-amazon.com/images/M/MV5BMzczMmQ0NTItM2JkZi00MTRhLTg5OGMtZWEyZTE2ZDgwM2FjXkEyXkFqcGdeQXVyMTU1MDczNjU1._V1_FMjpg_UY2048_.jpg"
                });
            }
            _totalPage = _movies.Count / _itemPerPage + (_movies.Count % _itemPerPage == 0 ? 0 : 1);
            updateCollection();
        }

        public ICommand NextCommand => new RelayCommand(Next);
        public ICommand PrevCommand => new RelayCommand(Previous);


        private void updateCollection() {
            MovieCollection = new List<Movie>(_movies.Skip(_itemPerPage * CurrentPage).Take(_itemPerPage));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MovieCollection"));
        }

        public void Next() {
            CurrentPage = CurrentPage == _totalPage - 1 ? 0 : CurrentPage + 1;
            updateCollection();
        }

        public void Previous() {
            CurrentPage = CurrentPage == 0 ? _totalPage - 1 : CurrentPage - 1;
            updateCollection();
        }
    }
}
