using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaffManagement.Domain.Employees;
using StaffManagement.Infrastructure.Context;
using StaffManagement.Infrastructure.Repositories;

namespace StaffManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                string connectionString = configuration.GetConnectionString("SqlServer")!;
                opt.UseSqlServer(connectionString);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //Scruter kullanılabilir

            return services;
        }
    }
}
