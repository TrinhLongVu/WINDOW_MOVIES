using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class DirectorManageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Director> DirectorList { get; set; } = new ObservableCollection<Director>();
        public ArrayList directors = new ArrayList();
        public int CurrentPage { get; set; }
        private int _pageSize = 8;
        private int _totalMovies = 0;
        private int _quantityPage = 0;
        public DirectorManageViewModel()
        {
            DirectorDB directorDB = new DirectorDB();
            directors = directorDB.GetAllDirectors();

            CurrentPage = 0;
            _totalMovies = directors.Count;
            _quantityPage = (_totalMovies + _pageSize - 1) / _pageSize;

            UpdateDirectorList(0);
        }
        public ICommand PreviousPageCommand => new RelayCommand(Previous);
        public ICommand NextPageCommand => new RelayCommand(Next);
        private void Next()
        {
            CurrentPage++;
            CurrentPage = CurrentPage % _quantityPage;
            UpdateDirectorList(CurrentPage);
        }
        private void Previous()
        {
            CurrentPage--;
            CurrentPage = (CurrentPage + _quantityPage) % _quantityPage;
            UpdateDirectorList(CurrentPage);
        }
        private void UpdateDirectorList(int curPage)
        {
            int startIndex = curPage > 0 ? curPage * _pageSize : 0;
            int endIndex = Math.Min(startIndex + _pageSize, _totalMovies);
            DirectorList.Clear();
            for (int i = startIndex; i < endIndex; i++) DirectorList.Add((Director)directors[i]);
        }
    }
}
