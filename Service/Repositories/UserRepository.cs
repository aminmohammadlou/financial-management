using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Service.ViewModels;

namespace Service.Repositories
{
    public class UserRepository(FinancialManagementDbContext dbContext) : BaseRepository(dbContext)
    {
        public async Task<UserModel?> FindUserByEmail(string email)
        {
            return await dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserModel?> FindUserByPhoneNumber(string phoneNumber)
        {
            return await dbContext.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await dbContext.Users.SingleAsync(x => x.Email == email);
        }
    }
}
