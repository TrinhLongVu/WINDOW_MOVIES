using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class ChartData
    {
        public string Category { get; set; }
        public double Value { get; set; }
    }
    class StatisticViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SeriesCollection ChartSeries { get; set; }
        public ObservableCollection<string> ColumnLabels { get; set; }
        public StatisticViewModel()
        {
            ChartSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { 1000000, 3000000, 2000000, 3000000}
                }
            };
            ColumnLabels = new ObservableCollection<string> { "Week 1", "Week 2", "Week 3", "Week 4"};
        }
    }
}
