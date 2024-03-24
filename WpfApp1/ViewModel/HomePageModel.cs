using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class HomePageModel : INotifyPropertyChanged
    {
        public MovieCarousel TopMovies { get; set; }
        public MovieCarousel AiringMovieCarousel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public TopRevenue SelectedItem { get; set; }
        public HomePageModel() {
            TopMovies = new MovieCarousel(new MovieDB().GetTopN_HotMovies(10), 2, 2);
            List<TopRevenue> airingMovies = new MovieDB().GetAllAiringMovies();
            Shuffle(airingMovies);
            AiringMovieCarousel = new MovieCarousel(airingMovies, 2, 2);
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
        public void Shuffle<T>(IList<T> list) {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
