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

        public MovieCarousel(List<Movie> movies, int itemPerPage = 4) {
            _itemPerPage = itemPerPage;
            _movies = movies;
            _totalPage = _movies.Count / _itemPerPage + (_movies.Count % _itemPerPage == 0 ? 0 : 1);
            updateCollection();
        }

        public ICommand NextCommand => new RelayCommand(Next);
        public ICommand PrevCommand => new RelayCommand(Previous);


        private void updateCollection() {
            MovieCollection = new List<Movie>(_movies.Skip(_itemPerPage * CurrentPage).Take(_itemPerPage));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MovieCollection)));
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
