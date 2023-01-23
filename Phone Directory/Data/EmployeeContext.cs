using Microsoft.EntityFrameworkCore;
using Phone_Directory.Models;

namespace PhoneDirectory.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }
    }

}
