using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Movie
    {
        public string Id { get; set; }
        // ? can be assign null
        public string? IdGener { get; set; }
        public string Name { get; set; }
        public string? Release { get; set; }
        public string? Runtime { get; set; }
        public string? Plot { get; set; }
        public string? Rating { get; set; }
        public string? Poster { get; set; }
        public string? IdStar { get; set; }
        public string? IdDirector { get; set; }
        public string? Certification { get; set; }
    }
}
