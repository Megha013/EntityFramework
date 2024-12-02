using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Models
{
    public class ApplicationDbContext:DbContext
    {
        // override configuration that we need at app level
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // LINQ  --> conversion DBset --> SQL  -> exec
        // Entity <Employee> 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}
