using ApplicationT3.Domain;
using ApplicationT3.Domain.Context;
using ApplicationT3.Service.ApplicationService;
using ApplicationT3.Service.Contract;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace ApplicationT3.Service.DI
{
    public static class DependenciIjeccionProfile
    {
        public static IServiceCollection dbConectionService(this IServiceCollection service, IConfiguration config)
        {
           

            service.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("dbConexion")));

            service.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));
            return service;
        }

        public static IServiceCollection ApplicationService(this IServiceCollection service)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));
            service.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
            service.AddTransient<IUserApplicationService, UserApplicationService>();
            return service;
        }
    }
}
