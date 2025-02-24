using Data.Models;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Service.Repositories
{
    public class UserRepository(FinancialManagementDbContext dbContext) : BaseRepository(dbContext)
    {
        private readonly FinancialManagementDbContext _dbContext = dbContext;

        public async Task<UserModel?> FindUserByEmail(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserModel?> FindUserByPhoneNumber(string phoneNumber)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _dbContext.Users.SingleAsync(x => x.Email == email);
        }
    }
}
