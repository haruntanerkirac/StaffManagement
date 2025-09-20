using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StaffManagement.Application.Behaviors;

namespace StaffManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(conf=>
            {
                conf.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
            return services;
        }
    }
}
