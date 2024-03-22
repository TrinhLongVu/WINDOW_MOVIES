using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Movie : IComparable
    {
        public Int32 Id { get; set; }
        public Int32? IdGener { get; set; }
        public string Title { get; set; }
        public string? Price { get; set; }
        public string? Release { get; set; }
        public string? Runtime { get; set; }
        public string? Landscape { get; set; }
        public double? Rating { get; set; }
        public string? Poster { get; set; }
        public string? Certification { get; set; }
        public string? Detail { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public string? Bio { get; set; }
        public string? GenreName { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Movie otherMovie = obj as Movie;
            if (otherMovie != null)
            {
                return this.Rating.GetValueOrDefault().CompareTo(otherMovie.Rating.GetValueOrDefault());
            }
            else
            {
                throw new ArgumentException("Object is not a Movie");
            }
        }
    }
}
