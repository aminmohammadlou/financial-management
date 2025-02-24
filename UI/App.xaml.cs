using System.Windows;
using Data.Models;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.ViewModels;
using UI.Views;

namespace UI;

public partial class App : Application
{
    private IServiceProvider _serviceProvider;

    protected override async void OnStartup(StartupEventArgs e)
    {
        // Db config
        var options = new DbContextOptionsBuilder<FinancialManagementDbContext>().UseSqlite("Data Source=db.sqlite3").Options;
        var dbContext = new FinancialManagementDbContext(options);
        await dbContext.Database.EnsureCreatedAsync();

        // Add settings data
        var settings = await dbContext.Settings.FirstOrDefaultAsync();

        if (settings is null)
        {
            settings = new SettingsModel
            {
                LastUserLoggedInEmail = null
            };
            await dbContext.Settings.AddAsync(settings);
            await dbContext.SaveChangesAsync();
        }

        base.OnStartup(e);

        var startup = new Startup();
        _serviceProvider = startup.ConfigureServices();

        var mainWindow = _serviceProvider.GetRequiredService<Login>();
        mainWindow.DataContext = new LoginForm
        {
            Email = settings.LastUserLoggedInEmail
        };
        mainWindow.Show();
    }
}