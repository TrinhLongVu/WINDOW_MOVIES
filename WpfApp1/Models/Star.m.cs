using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Star
    {
        public Int32 Id { get; set; }
        public string? Name { get; set; }
        // image can change datatype
        public string? Avatar { get; set; }
        public string? Bio { get; set; }
        public override string ToString() {
            return Name;
        }
    }
}
