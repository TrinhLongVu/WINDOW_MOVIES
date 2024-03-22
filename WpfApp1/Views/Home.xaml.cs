using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp1.ViewModel;

namespace WpfApp1.Views {
    class TrailerControl {
        public Image Landscape;
        public Grid Info;
        public MediaElement Trailer;
        public bool IsPlaying;
        public TrailerControl(Image img, Grid g, MediaElement vid) {
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

            Image? landscape = null;
            Grid? info = null;
            foreach (UIElement item in container.Children)
            {
                var ele = item as FrameworkElement;
                if (ele == null) {
                    throw new Exception($"Unexpected type {ele.GetType()}");
                }
                switch (ele.Name) {
                    case "landscape": {
                        landscape = ele as Image;
                        
/*                        Storyboard st = new Storyboard();
                        DoubleAnimation animation = new DoubleAnimation {
                            By = 10,
                            Duration = TimeSpan.FromSeconds(1),
                        };
                        Storyboard.SetTarget(animation, landscape);
                        Storyboard.SetTargetProperty(animation, new PropertyPath(("(Image.Width)")));
                        st.Children.Add(animation);
                        st.Begin();*/
                        break;
                    }
                    case "description":
                        info = ele as Grid;
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
            scaleAnimation(sender as FrameworkElement, 1.0, 0.2);
            resetTrailer();
        }

        private void OnPrevClick(object sender, RoutedEventArgs e) {
            var carousel = FindName("Carousel") as ListView;
            if (carousel == null) {
                throw new Exception("NULL");
            }
            viewModel.TestCarousel.Previous(carousel);
        }

        private void OnNextClick(object sender, RoutedEventArgs e) {
            var carousel = FindName("Carousel") as ListView;
            if (carousel == null) {
                throw new Exception("NULL");
            }
            viewModel.TestCarousel.Next(carousel);
        }
    }
}
