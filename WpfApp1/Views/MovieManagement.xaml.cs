using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using WpfApp1.Models;

namespace WpfApp1.Views
{
    class AdminMovieManageViewModel : INotifyPropertyChanged
    {
        public AdminMovieManageViewModel()
        {
            Movies.Add(new Movie { Title = "Mai(T18) wda da wad adaw dadw", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Title = "Mai(T18)", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Title = "Mai(T18)", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Title = "Mai(T18)", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Title = "Mai(T18)", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Title = "Mai(T18)", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
            Movies.Add(new Movie { Title = "Mai(T18)", Poster = "https://api-website.cinestar.com.vn/media/wysiwyg/Posters/03-2024/sang-den-poster.jpg" });
        }

        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public partial class MovieManagement : Page
    {
        public MovieManagement()
        {
            InitializeComponent();
            DataContext = new AdminMovieManageViewModel();
        }
    }
}
