using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Database;
using WpfApp1.Models;
using WpfApp1.Views;

namespace WpfApp1.ViewModel
{
    class MovieManageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Movie> MovieShow { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Filter> Filters { get; set; }
        public ArrayList movies = new ArrayList();
        public Movie SelectedItem { get; set; }
        public int CurrentPage { get; set; }
        private int _pageSize = 8;
        private int _totalMovies = 0;
        private int _quantityPage = 0;
        public MovieManageViewModel()
        {
            MovieDB movieDB = new MovieDB();
            movies = movieDB.GetAllMovie();

            CurrentPage = 0;
            _totalMovies = movies.Count;
            _quantityPage = (_totalMovies + _pageSize - 1) / _pageSize;

            UpdateMovie(0);
        }
        public ICommand PreviousPageCommand => new RelayCommand(Previous);
        public ICommand NextPageCommand => new RelayCommand(Next);
        private void Next()
        {
            CurrentPage++;
            CurrentPage = CurrentPage % _quantityPage;
            UpdateMovie(CurrentPage);
        }
        private void Previous()
        {
            CurrentPage--;
            CurrentPage = (CurrentPage + _quantityPage) % _quantityPage;
            UpdateMovie(CurrentPage);
        }
        private void UpdateMovie(int curPage)
        {
            int startIndex = curPage > 0 ? curPage * _pageSize : 0;
            int endIndex = Math.Min(startIndex + _pageSize, _totalMovies);
            MovieShow.Clear();
            for (int i = startIndex; i < endIndex; i++) MovieShow.Add((Movie)movies[i]);
        }

        public void Reload()
        {
            movies = new MovieDB().GetAllMovie();
            _totalMovies = movies.Count;
            _quantityPage = (_totalMovies + _pageSize - 1) / _pageSize;
            UpdateMovie(CurrentPage);
        }

        public void OpenUpdateMovie() {
            if (SelectedItem == null) return;
            new AddMovie(SelectedItem.Id).ShowDialog();
            MovieDB movieDB = new MovieDB();
            Reload();
        }
    }
}
