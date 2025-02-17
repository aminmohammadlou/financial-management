using System.Windows;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace UI;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        // Db config
        var options = new DbContextOptionsBuilder<FinancialManagementDbContext>().UseSqlite("Data Source=db.sqlite3").Options;
        var dbContext = new FinancialManagementDbContext(options);
        dbContext.Database.EnsureCreatedAsync();

        base.OnStartup(e);
    }
}