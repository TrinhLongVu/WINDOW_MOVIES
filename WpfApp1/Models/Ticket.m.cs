using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Database;

namespace WpfApp1.Models
{
    class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Seat { get; set; }
        public DateTime Schedule { get; set; }
        public int MovieId { get; set; }
    }
}
