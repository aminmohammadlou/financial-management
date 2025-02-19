using System.Windows;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UI.Views;

namespace UI;

public partial class App : Application
{
    private IServiceProvider _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        // Db config
        var options = new DbContextOptionsBuilder<FinancialManagementDbContext>().UseSqlite("Data Source=db.sqlite3").Options;
        var dbContext = new FinancialManagementDbContext(options);
        dbContext.Database.EnsureCreatedAsync();

        base.OnStartup(e);

        var startup = new Startup();
        _serviceProvider = startup.ConfigureServices();

        var mainWindow = _serviceProvider.GetRequiredService<Login>();
        mainWindow.Show();
    }
}