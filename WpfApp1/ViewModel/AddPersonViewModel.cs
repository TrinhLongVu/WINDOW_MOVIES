using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Database;

namespace WpfApp1.ViewModel
{
    class AddPersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Detail { get; set; }
        private string _type;
        
        public AddPersonViewModel(string type)
        {
            _type = type;
        }
        public ICommand AddMovieBtn => new RelayCommand(AddPersonBtnFunc);
        public event EventHandler<EventArgs> ClickInsert;
        private void AddPersonBtnFunc()
        {
            if (Name == "" || Avatar == "" || Detail == "")
            {
                MessageBox.Show("Please provide enough info...");
                return;
            }

            if(_type == "cast")
            {
                StarDB s = new StarDB();
                s.insertStar(Name, Avatar, Detail);
            }
            else if (_type == "director")
            {
                DirectorDB d = new DirectorDB();
                d.insertDirector(Name, Avatar, Detail);
            }
            ClickInsert?.Invoke(this, EventArgs.Empty);
        }   
    }
}
