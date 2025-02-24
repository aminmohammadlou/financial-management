using Microsoft.Extensions.DependencyInjection;
using Service.Repositories;
using Service.Services;
using UI.Views;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<Login>();
            services.AddScoped<UserService>();
            services.AddScoped<UserRepository>();
            services.AddDbContext<FinancialManagementDbContext>(options => options.UseSqlite("Data Source=db.sqlite3"));

            return services.BuildServiceProvider();
        }
    }
}
