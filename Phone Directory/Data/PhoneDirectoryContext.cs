using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PhoneDirectory.Data
{
    public class PhoneDirectoryContext: IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
            optionsBuilder.UseSqlite("connecting string");

            return new EmployeeContext(optionsBuilder.Options);
        }
    }
}
