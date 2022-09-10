using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Entities.Models;

namespace RepositoryDesignPattern.Entities
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
