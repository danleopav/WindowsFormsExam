using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExam
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public Cities City { get; set; }
        public double Price { get; set; }
        public int Rooms { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public byte[] PhotoSlider { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}
