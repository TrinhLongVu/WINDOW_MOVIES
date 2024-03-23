using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Database
{
    class MovieSchedule
    {
        public int Id { get; set; }
        public int IdSchedule { get; set; }
        public int IdMovie { get; set; }
        public DateTime Date { get; set; }
    }
}
