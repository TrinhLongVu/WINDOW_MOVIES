using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    class HomePageModel
    {
        public MovieCarousel TestCarousel { get; set; } = new MovieCarousel(4);
        public HomePageModel() {
        }
    }
}
