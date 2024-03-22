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
        public ObservableCollection<Movie> MovieShow { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Filter> Filters { get; set; }
        public ArrayList movies = new ArrayList();
        public Movie SelectedItem { get; set; }
        public int CurrentPage { get; set; }
        private int _pageSize = 8;
        private int _totalMovies = 0;
        private int _quantityPage = 0;
        MovieDB movieDB;

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
        
        public SearchViewModel(string stringSearch)
        {
            movieDB = new MovieDB();
            movies = movieDB.SearchMovie(stringSearch);

            CurrentPage = 0;
            _totalMovies = movies.Count;
            _quantityPage = (_totalMovies + _pageSize - 1) / _pageSize;
           
            UpdateMovie(0);
            Filters = new ObservableCollection<Filter>
            {
                new Filter { Name = "Inscrease Rating" },
                new Filter { Name = "Decrease Rating" }
            };
            PropertyChanged += MyViewModel_PropertyChanged;
        }
        public event EventHandler<Int32> SelectItemBtn;
        private void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem))
            {
                SelectItemBtn?.Invoke(this, SelectedItem.Id);
            }
        }

        private void FilterItems()
        {
            // handle logic from database(_SelectedFilter.Name)
            MovieShow.Clear();
            if(_SelectedFilter.Name == "Inscrease Rating")
            {
                movies = movieDB.FilterAsc();
                UpdateMovie(0);
            }else if (_SelectedFilter.Name == "Decrease Rating")
            {
                movies = movieDB.FilterDesc();
                UpdateMovie(0);
            }

        }
        public ICommand PreviousPageCommand => new RelayCommand(Previous);
        public ICommand NextPageCommand => new RelayCommand(Next);
        public ICommand ItemClickCommand => new RelayCommand(SelectItem);
        private void SelectItem()
        {
            MessageBox.Show("hello");
        }
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
    }
}