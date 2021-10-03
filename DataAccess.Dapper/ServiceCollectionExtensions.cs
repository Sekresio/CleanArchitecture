using System.Data;
using DataAccess.Dapper.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Dapper
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDapperDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDbConnection>((sp) => new SqliteConnection(connectionString));
        }

        public static void AddDapperRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}