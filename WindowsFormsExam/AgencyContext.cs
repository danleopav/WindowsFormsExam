using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExam
{
    public class AgencyContext : DbContext
    {
        public AgencyContext() : base("DbConnection")
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RealEstate> RealEstate { get; set; }

        ~AgencyContext()
        {
            this.Dispose();
        }
    }
}
