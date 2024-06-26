﻿using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfApp1.ViewModel;

namespace WpfApp1.Views {
    class TrailerControl {
        public Border Landscape;
        public Grid Info;
        public MediaElement Trailer;
        public bool IsPlaying;
        public TrailerControl(Border img, Grid g, MediaElement vid) {
            Landscape = img;
            Trailer = vid;
            Info = g;
            IsPlaying = false;
            Trailer.MediaEnded += Trailer_MediaEnded;
        }

        public void Play() {
            IsPlaying = true;
            Trailer.Visibility = Visibility.Visible;
            Trailer.Play();
            Landscape.Visibility = Visibility.Hidden;
            Info.Visibility = Visibility.Hidden;
        }

        private void Trailer_MediaEnded(object sender, RoutedEventArgs e) {
            Stop();
        }

        public void Stop() {
            Info.Visibility = Landscape.IsMouseOver ? Visibility.Visible : Visibility.Hidden;
            Landscape.Visibility = Visibility.Visible;
            Trailer.Visibility = Visibility.Hidden;
            Trailer.Stop();
            IsPlaying = false;
        }
    }
}
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>

namespace WpfApp1.Views
{
    public partial class Home : Page {
        HomePageModel viewModel;
        Timer? timer = null;
        private TrailerControl? playing = null;
        public Home() {
            InitializeComponent();
            viewModel = new HomePageModel();
            DataContext = viewModel;
            viewModel.SelectItemBtn += ViewModel_ClickItem;
        }

        private void ViewModel_ClickItem(object sender, Int32 Id)
        {
            NavigationService?.Navigate(new MovieInfo(Id));
        }

        private void scaleAnimation(FrameworkElement element, double scale, double secs) {
            var scaler = element.LayoutTransform as ScaleTransform;
            if (scaler == null) {
                scaler = new ScaleTransform(1.0, 1.0);
                element.LayoutTransform = scaler;
            }
            DoubleAnimation animator = new DoubleAnimation() {
                Duration = new Duration(TimeSpan.FromSeconds(secs)),
            };
            animator.To = scale;
            scaler.BeginAnimation(ScaleTransform.ScaleXProperty, animator);
            scaler.BeginAnimation(ScaleTransform.ScaleYProperty, animator);
        }

        private void ItemMouseEnter(object sender, MouseEventArgs e) {
            Grid container = sender as Grid;
            scaleAnimation(container, 1.1, 0.2);
            if (container == null) {
                throw new Exception($"Unexpected type {sender.GetType()}");
            }

            Border? landscape = null;
            Grid? info = null;
            foreach (UIElement item in container.Children)
            {
                var ele = item as FrameworkElement;
                if (ele == null) {
                    throw new Exception($"Unexpected type {ele.GetType()}");
                }
                switch (ele.Name) {
                    case "landscape": {
                        landscape = ele as Border;
                        break;
                    }
                    case "description":
                        info = ele as Grid;
                        info.Visibility = Visibility.Visible;
                        break;
                    case "trailer":
                        MediaElement vid = ele as MediaElement;
                        playing = new TrailerControl(landscape, info, vid);
                        if (info == null || landscape == null) {
                            throw new Exception("Missing landscape (poster) and description before trailer");
                        } else {
                            if (timer != null) timer.Stop();
                            timer = new Timer {
                                Interval = 2000,
                                Enabled = true,
                                    
                            };
                            timer.Elapsed += ((object source, ElapsedEventArgs e) => {
                                this.Dispatcher.Invoke(() => {
                                    playing?.Play();
                                });
                                timer.Stop();
                            });
                        }
                        return;
                    default:
                        throw new Exception($"Unexpected name {ele.Name} type {ele.GetType()} before trailer");
                }
            }
        }

        private void OnItemClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
            
        }

        private void resetTrailer() {
            if (playing != null && playing.IsPlaying) {
                playing.Stop();
            }
            if (timer != null) {
                timer.Stop();
            }
            playing = null;
            timer = null;
        }
        private void ItemMouseLeave(object sender, MouseEventArgs e) {
            ((sender as Grid).FindName("description") as Grid).Visibility = Visibility.Hidden;
            scaleAnimation(sender as FrameworkElement, 1.0, 0.2);
            resetTrailer();
        }

        private void OnPrevClick(object sender, RoutedEventArgs e) {
            var carousel = FindName("TopMoviesCarousel") as ListView;
            if (carousel == null) {
                throw new Exception("NULL");
            }
            viewModel.TopMovies.Previous(carousel);
        }

        private void OnNextClick(object sender, RoutedEventArgs e) {
            var carousel = FindName("TopMoviesCarousel") as ListView;
            if (carousel == null) {
                throw new Exception("NULL");
            }
            viewModel.TopMovies.Next(carousel);
        }

        private void OnPrevClick2(object sender, RoutedEventArgs e) {
            var carousel = FindName("AiringCarousel") as ListView;
            if (carousel == null) {
                throw new Exception("NULL");
            }
            viewModel.AiringMovieCarousel.Previous(carousel);
        }

        private void OnNextClick2(object sender, RoutedEventArgs e) {
            var carousel = FindName("AiringCarousel") as ListView;
            if (carousel == null) {
                throw new Exception("NULL");
            }
            viewModel.AiringMovieCarousel.Next(carousel);
        }

        private void OnBookingClick(object sender, RoutedEventArgs e) {
            if (LoginViewModel.IsLogin()) {
                new Booking(1).ShowDialog();
            } else {
                ((MainWindow)App.Current.MainWindow).frame.NavigationService.Navigate(new Login());
            }
        }
    }
}
