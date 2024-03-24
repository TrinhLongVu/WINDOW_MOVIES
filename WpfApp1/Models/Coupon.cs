using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Coupon
    {
        public int Id { get; set; }
        public DateTime Expire { get; set; }
        public int UserId { get; set; }
        public double Discount {  get; set; }
    }
}
