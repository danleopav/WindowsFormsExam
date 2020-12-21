using System;
using System.Collections.Generic;

namespace WindowsFormsExam
{
    public class Client
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Status Status { get; set; } 
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Today;
        public byte[] ProfilePhoto { get; set; }
        public ICollection<RealEstate> RealEstate { get; set; } = new List<RealEstate>();
    }
}
