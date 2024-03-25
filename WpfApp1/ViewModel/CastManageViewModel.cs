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
    class CastManageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Star> CastList { get; set; } = new ObservableCollection<Star>();
        public ArrayList casts = new ArrayList();
        public Star SelectedStar { get; set; }
        public int CurrentPage { get; set; }
        private int _pageSize = 8;
        private int _totalCasts = 0;
        private int _quantityPage = 0;
        public CastManageViewModel()
        {
            StarDB starDB = new StarDB();
            casts = starDB.GetAllStar();

            CurrentPage = 0;
            _totalCasts = casts.Count;
            _quantityPage = (_totalCasts + _pageSize - 1) / _pageSize;

            UpdateCastList(0);
        }
        public ICommand PreviousPageCommand => new RelayCommand(Previous);
        public ICommand NextPageCommand => new RelayCommand(Next);
        private void Next()
        {
            CurrentPage++;
            CurrentPage = CurrentPage % _quantityPage;
            UpdateCastList(CurrentPage);
        }
        private void Previous()
        {
            CurrentPage--;
            CurrentPage = (CurrentPage + _quantityPage) % _quantityPage;
            UpdateCastList(CurrentPage);
        }   
        private void UpdateCastList(int curPage)
        {
            int startIndex = curPage > 0 ? curPage * _pageSize : 0;
            int endIndex = Math.Min(startIndex + _pageSize, _totalCasts);
            CastList.Clear();
            for (int i = startIndex; i < endIndex; i++) CastList.Add((Star)casts[i]);
        }
        public void OpenUpdateStar() {
            if (SelectedStar == null) return;
            new AddPerson("cast", SelectedStar.Id).ShowDialog();
            casts = new StarDB().GetAllStar();
            UpdateCastList(CurrentPage);
        }
    }
}
