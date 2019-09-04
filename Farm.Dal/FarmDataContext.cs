using Farm.Dal.Models;
using System.Data.Entity;

namespace Farm.Dal
{
    public class FarmDataContext : DbContext
    {
        public DbSet<FarmDal> Farms { get; set; }

        public FarmDataContext() : base("FarmBase") { }

        public FarmDataContext(string connectionString) : base(connectionString) { }
    }
}
