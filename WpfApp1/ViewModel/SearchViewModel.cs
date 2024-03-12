using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();
        public int CurrentPage { get; set; }
        private int _pageSize = 2;
        private int _totalMovies = 8;
        private int _quantityPage = 0;

        // get from database
        public ArrayList a = new ArrayList();
        public SearchViewModel()
        {
            CurrentPage = 0;
            _quantityPage = _totalMovies / _pageSize;
            // test when dont have database
            a.Add(new Movie { Name = "0", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Name = "Kungfu panda1", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Name = "Kungfu panda2", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Name = "Kungfu panda3", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Name = "Kungfu panda4", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Name = "Kungfu panda5", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Name = "Kungfu panda6", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Name = "Kungfu panda7", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });

            updateMovie(1);
        }
        public ICommand PreviousPageCommand => new RelayCommand(Previous);
        public ICommand NextPageCommand => new RelayCommand(next);
        private void next()
        {
            CurrentPage++;
            CurrentPage = CurrentPage % _quantityPage;
            updateMovie(CurrentPage);
        }
        private void Previous()
        {
            CurrentPage--;
            CurrentPage = (CurrentPage + _quantityPage) % _quantityPage;
            updateMovie(CurrentPage);
        }
        private void updateMovie(int curPage)
        {
            int startIndex = curPage > 0 ? curPage * _pageSize : 0;
            int endIndex = Math.Min(startIndex + _pageSize, _totalMovies);
            Movies.Clear();
            for (int i = startIndex; i < endIndex; i++) Movies.Add((Movie)a[i]);
        }
    }
}