using FunSuper.Server.Infrastructure.Super;
using FunSuper.Server.Infrastructure.Super.Repositories;
using FunSuper.Server.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FunSuper.Server.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<IFileService, FileService>();

            services.AddScoped<IContextSeedService, ContextSeedService>();
            services.AddScoped<ISuperCalculationService, SuperCalculationService>();

            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {

            services.AddDbContext<SuperContext>(options =>
            {
                var connection = new SqliteConnection(config.GetConnectionString("SuperDb"));

                if (env.IsDevelopment())
                    connection.Open(); // Inmemory DB live when connection open and clear when connection close

                options.UseSqlite(new SqliteConnection(config.GetConnectionString("SuperDb")));

            });

            services.AddTransient<IDisbursementRepository, DisbursementRepository>();
            services.AddTransient<IPayCodeRepository, PayCodeRepository>();
            services.AddTransient<IPayslipRepository, PayslipRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
