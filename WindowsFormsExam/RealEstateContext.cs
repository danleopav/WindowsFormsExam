using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExam
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext() : base("DbConnection")
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        ~RealEstateContext()
        {
            this.Dispose();
        }
    }
}
