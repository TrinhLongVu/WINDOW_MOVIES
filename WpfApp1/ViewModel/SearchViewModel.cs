﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Filter> Filters { get; set; }
        private Filter _SelectedFilter;
        public Filter SelectedFilter
        {
            get => _SelectedFilter;
            set
            {
                _SelectedFilter = value;
                FilterItems();
            }
        }
        
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
            a.Add(new Movie { Title = "0", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Title = "Kungfu panda1", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Title = "Kungfu panda2", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Title = "Kungfu panda3", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Title = "Kungfu panda4", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Title = "Kungfu panda5", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Title = "Kungfu panda6", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            a.Add(new Movie { Title = "Kungfu panda7", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });

            UpdateMovie(1);

            Filters = new ObservableCollection<Filter>
            {
                new Filter { Name = "Hot" },
                new Filter { Name = "Increase" }
            };
        }

        private void FilterItems()
        {
            // handle logic from database(_SelectedFilter.Name)
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
            Movies.Clear();
            for (int i = startIndex; i < endIndex; i++) Movies.Add((Movie)a[i]);
        }
    }
}