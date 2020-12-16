using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExam.Admin
{
    class Apartment
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Cost { get; set; }
        public int Rooms { get; set; }
        public int SquareMeters { get; set; }
        public string Description { get; set;   }
        public bool IsRenting { get; set; }
    }
}
