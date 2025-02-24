using Data.Models;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Service.Repositories
{
    public class BaseRepository(FinancialManagementDbContext dbContext)
    {
        public async Task AddEntity<TEntity>(TEntity entity) where TEntity : class
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Remove<TEntity>(params TEntity[] entities) where TEntity : class
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public Task BeginTransaction()
        {
            return dbContext.Database.BeginTransactionAsync();
        }

        public Task CommitTransaction()
        {
            return dbContext.Database.CommitTransactionAsync();
        }

        public async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

        public bool ChangeTrackerHasChanges()
        {
            return dbContext.ChangeTracker.HasChanges();
        }

        public async Task<SettingsModel> GetSettings()
        {
            return await dbContext.Settings.FirstAsync();
        }
    }
}
