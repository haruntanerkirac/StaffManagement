using Microsoft.EntityFrameworkCore;
using StaffManagement.Domain.Employees;

namespace StaffManagement.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
