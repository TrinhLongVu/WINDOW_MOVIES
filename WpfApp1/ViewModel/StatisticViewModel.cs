using LiveCharts;
using LiveCharts.Wpf;
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
    class StatisticViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SeriesCollection ChartSeries { get; set; }
        public ObservableCollection<string> ColumnLabels { get; set; }
        public ObservableCollection<Movie> MovietopRevenue { get; set; } = new ObservableCollection<Movie>();
        public string RevenueYear { get; set; }
        public string RevenueMonth { get; set; }
        public string RevenueDay { get; set; }
        public string TotalMovies { get; set; }
        public StatisticViewModel()
        {
            RevenueYear = "1000";
            RevenueMonth = "1233";
            RevenueDay = "2123";
            TotalMovies = "30";

            MovietopRevenue.Add(new Movie { Title = "Hi1" });
            MovietopRevenue.Add(new Movie { Title = "Hi2" });
            MovietopRevenue.Add(new Movie { Title = "Hi3" });
            MovietopRevenue.Add(new Movie { Title = "Hi4" });
            MovietopRevenue.Add(new Movie { Title = "Hi5" });
            MovietopRevenue.Add(new Movie { Title = "Hi6" });
            ChartSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { 1000000, 3000000, 2000000, 3000000, 1000000, 3000000, 2000000, 3000000, 1000000, 3000000, 2000000, 3000000, 1000000, 3000000, 2000000, 3000000 }
                }
            };
            ColumnLabels = new ObservableCollection<string> { "1", "2", "3", "4", "1", "2", "3", "4", "1", "2", "3", "4", "1", "2", "3", "4" };
        }
    }
}
