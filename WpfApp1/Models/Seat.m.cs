using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Seat
    {
        public String Position { get; set; }
        public bool IsAvailable { get; set; }

        public int Id { get; set; }

        public Seat(string position, bool isAvailable, int id) {
            Position = position;
            IsAvailable = isAvailable;
            Id = id;
        }
        public override string ToString() {
            return Position;
        }
    }
}
