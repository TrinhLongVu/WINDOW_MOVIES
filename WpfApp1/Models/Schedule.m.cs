using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Schedule {
        public int Id { get; set; }
        public string Time { get; set; }
        public Schedule(int id, string time) {
            Id = id;
            Time = time;
        }
    }
}
