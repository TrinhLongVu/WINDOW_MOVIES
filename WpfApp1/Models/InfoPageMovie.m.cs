using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class InfoPageMovie
    {
        public Int32 Id { get; set; }
        public Int32? IdGener { get; set; }
        public string Title { get; set; }
        public string? Price { get; set; }
        public string? Release { get; set; }
        public string? Runtime { get; set; }
        public string? Landscape { get; set; }
        public string? Rating { get; set; }
        public string? Poster { get; set; }
        public string? Certification { get; set; }
        public string? Detail { get; set; }
        public string? NameStar { get; set; }
        public string? AvatarStar { get; set; }
        public string? BioStar { get; set; }
        public string? NameDirector { get; set; }
        public string? AvatarDirector { get; set; }
        public string? BioDirector { get; set; }
        public string? NameGenre { get; set; }
    }
}
