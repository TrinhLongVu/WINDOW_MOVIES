using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Movie
    {
        public Int32 Id { get; set; }
        public Int32? IdGener { get; set; }
        public string Title { get; set; }
        public string? Release { get; set; }
        public string? Runtime { get; set; }
        public string? Landscape { get; set; }
        public double? Rating { get; set; }
        public string? Poster { get; set; }
        public string? Certification { get; set; }
        public string? Detail { get; set; }
        public string? GenreName { get; set; }
    }
}
