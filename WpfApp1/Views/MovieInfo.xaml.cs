using System;
using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class MovieInfo : Page
    {
        public MovieInfo(Int32 Id)
        {
            InitializeComponent();
            DataContext = new MovieInfoViewModel(Id);
        }
    }
}
