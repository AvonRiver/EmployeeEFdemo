using System.Data.Entity;

namespace Stephen.Webb.HR.DataAccess
{
    public class DelarueSystemContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
