using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class SearchViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        public SearchViewModel()
        {
            // Populate the People collection with some sample data
            Movies.Add(new Movie { Name = "Mai(T18)", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Name = "Kungfu panda1", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Name = "Kungfu panda2", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Name = "Kungfu panda3", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Name = "Kungfu panda4", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Name = "Kungfu panda5", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Name = "Kungfu panda6", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Name = "Kungfu panda7", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
        }

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
