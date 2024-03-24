using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfApp1.Models;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class AddMovie : Window
    {
        public AddMovie()
        {
            InitializeComponent();
            DataContext = new AddMovieViewModel();
        }

        public AddMovie(int originalId)
        {
            InitializeComponent();
            DataContext = new AddMovieViewModel(originalId);
            Title = "Update Movie";
        }

        private void imgUrlChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (sender == posterUrl)
                {
                    string text = textBox.Text;
                    try
                    {
                        BitmapImage bitmapImage = new BitmapImage(new Uri(text));
                        PosterPreview.Source = bitmapImage;
                    }
                    catch (Exception ex)
                    {
                        PosterPreview.Source = null;
                    }
                }
                if (sender == landscapeUrl)
                {
                    string text = textBox.Text;
                    try
                    {
                        BitmapImage bitmapImage = new BitmapImage(new Uri(text));
                        LandscapePreview.Source = bitmapImage;
                    }
                    catch (Exception ex)
                    {
                        LandscapePreview.Source = null;
                    }
                }
                
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
