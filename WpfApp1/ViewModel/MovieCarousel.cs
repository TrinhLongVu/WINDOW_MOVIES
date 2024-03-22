using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class MovieCarousel
    {
        public List<Movie> MovieCollection { get; set; }

        private List<Movie> _movies;

        private bool onAnimation = false;

        private int _scrollPerPage = 0;
        private int _totalItems = 0;
        private int _itemsLeft = 0;
        private int _itemScrolled = 0;
        private int _itemPerPage = 0;
        private const int _MARGIN = 7;
        private const int _PADDING = 20;


        public MovieCarousel(List<Movie> movies, int scrollPerPage, int itemPerPage = 4) {
            _scrollPerPage = scrollPerPage;
            _itemPerPage = itemPerPage;
            _movies = movies;
            _totalItems = _movies.Count;
            _itemsLeft = Math.Max(_totalItems - _itemPerPage, 0);
            _itemScrolled = 0;
            MovieCollection = new List<Movie>(_movies);
        }

        public void Next(ListView container) {
            if (onAnimation) return;
            if (!(container.Parent is Canvas)) {
                throw new Exception("Wrap list view in canvas to use carousel");
            }
            if (_itemsLeft <= 0) return;
            var item = container.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
            var itemWidth = item.ActualWidth;
            var itemScroll = Math.Min(_scrollPerPage, _itemsLeft);
            _itemsLeft -= itemScroll;
            _itemScrolled += itemScroll;
            DoubleAnimation animation = new DoubleAnimation {
                By = - (itemWidth * itemScroll + _MARGIN + (_itemsLeft == 0 ? _PADDING : 0)),
                Duration = TimeSpan.FromSeconds(1.5),
            };
            Storyboard st = new Storyboard();
            Storyboard.SetTarget(animation, container);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Left)"));
            st.Children.Add(animation);
            st.Completed += (object sender, EventArgs e) => {
                onAnimation = false;
            };
            onAnimation = true;
            st.Begin();
        }
        public void Previous(ListView container) {
            if (onAnimation) return;
            if (!(container.Parent is Canvas)) {
                throw new Exception("Wrap list view in canvas to use carousel");
            }
            if (_itemScrolled == 0) return;
            var item = container.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
            var itemWidth = item.ActualWidth;
            var itemScroll = Math.Min(_scrollPerPage, _itemScrolled);
            _itemScrolled -= itemScroll;
            _itemsLeft += itemScroll;
            DoubleAnimation animation = new DoubleAnimation {
                By = itemWidth * itemScroll + _MARGIN + (_itemsLeft == itemScroll ? _PADDING : 0),
                Duration = TimeSpan.FromSeconds(1.5),
            };
            Storyboard st = new Storyboard();
            Storyboard.SetTarget(animation, container);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Left)"));
            st.Completed += (object sender, EventArgs e) => {
                onAnimation = false;
            };
            st.Children.Add(animation);
            onAnimation = true;
            st.Begin();
        }
    }
}
