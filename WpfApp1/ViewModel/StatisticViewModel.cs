using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class MovieTop
    {
        public string Title { get; set; }
        public double Revenue { get; set; }
    }
    class StatisticViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SeriesCollection ChartSeries { get; set; }
        public ObservableCollection<string> ColumnLabels { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<MovieTop> MovietopRevenue { get; set; } 
        public string RevenueYear { get; set; }
        public string RevenueMonth { get; set; }
        public string RevenueDay { get; set; }
        public Int32 TotalMovies { get; set; }
        public StatisticViewModel()
        {
            var t = new TicketDB();
            RevenueYear = t.GetYearTicket().ToString();
            RevenueMonth = t.GetMonthTicket().ToString();
            RevenueDay = t.GetDayTicket().ToString();
            TotalMovies = new MovieDB().QuantityMovie();
            var topMovies = new MovieDB().TopRevenue(20).ConvertAll(x => new MovieTop { Title = x.Title, Revenue = x.Revenue });


            var movies = new TicketDB().MovieGetStatistic();

            ChartValues<double> chartValues = new ChartValues<double>();
            MovietopRevenue = new ObservableCollection<MovieTop>(topMovies);

            foreach (var movie in movies)
            {
                chartValues.Add(movie.Revenue);
                ColumnLabels.Add("Day: " + movie.Day.ToString() + "/" + movie.Month.ToString());
            }

            ChartSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = chartValues
                }
            };
        }
    }
}
