using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExam
{
    public class Apartment
    {
        [Key]
        [ForeignKey("Client")]
        public int Id { get; set; }
        public string Street { get; set; }
        public Cities City { get; set; }
        public double Price { get; set; }
        public int Rooms { get; set; }
        public string Description { get; set; }
        public bool IsRenting { get; set; }
        public byte[][] Photos { get; set; } = new byte[5][]; 
        public Client Client { get; set; }
    }
}
