using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Movie
    {
        public Int32 Id { get; set; }
        public string? IdGener { get; set; }
        public string Title { get; set; }
        public string? Price { get; set; }
        public string? Release { get; set; }
        public string? Runtime { get; set; }
        public string? Landscape { get; set; }
        public string? Rating { get; set; }
        public string? Poster { get; set; }
        public string? Certification { get; set; }
        public string? Detail { get; set; }
    }
}
