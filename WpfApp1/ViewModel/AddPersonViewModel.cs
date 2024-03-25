using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class AddPersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Detail { get; set; }
        public string ButtonText { get; set; }
        public ICommand AddMovieBtn { get; set; }
        public event EventHandler<EventArgs> ClickInsert;

        private string _type;
        private int _id;
        
        public AddPersonViewModel(string type)
        {
            _type = type;
            AddMovieBtn = new RelayCommand(AddPersonBtnFunc);
            ButtonText = "Add";
        }
        public AddPersonViewModel(string type, int id) { // updating
            _type = type;
            _id = id;
            if (type == "director") {
                Director director = new DirectorDB().GetDirector(id);
                Name = director.Name;
                Avatar = director.Avatar;
                Detail = director.Bio;
            } else if (type == "cast") {
                Star star = new StarDB().GetStar(id);
                Name = star.Name;
                Avatar = star.Avatar;
                Detail = star.Bio;
            }
            ButtonText = "Update";
            AddMovieBtn = new RelayCommand(UpdatePersonBtnFunc);
        }

        private void UpdatePersonBtnFunc() {
            if (Name == "" || Avatar == "" || Detail == "") {
                MessageBox.Show("Please provide enough info...");
                return;
            }
            if (_type == "cast") {
                new StarDB().Update(new Star {
                    Id = _id,
                    Name = Name,
                    Avatar = Avatar,
                    Bio = Detail
                });
            } else if (_type == "director") {
                new DirectorDB().Update(new Director {
                    Id = _id,
                    Name = Name,
                    Avatar = Avatar,
                    Bio = Detail
                });
            }
            MessageBox.Show("Successfully update.");
            ClickInsert?.Invoke(this, EventArgs.Empty);
        }

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
            MessageBox.Show("Successfully insert.");
            ClickInsert?.Invoke(this, EventArgs.Empty);
        }   
    }
}
