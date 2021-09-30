using DataAccess.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.EFCore
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEntityFrameworkDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlite(
                    connectionString,
                    x => x.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });
        }

        public static void AddEntityFrameworkRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
        }
    }
}