using StaffManagement.Domain.Employees;
using StaffManagement.Infrastructure.Context;

namespace StaffManagement.Infrastructure.Repositories
{
    internal sealed class EmployeeRepository : Repository<Employee, ApplicationDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
