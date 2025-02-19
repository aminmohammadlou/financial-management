using Data.Models;
using Service.Repositories;
using Service.ViewModels;

namespace Service.Services
{
    public class UserService(UserRepository repository)
    {
        public async Task<MessageBoxData> Register(RegisterForm form)
        {
            // Find user with email or phoneNumber
            var existedUser = await repository.FindUserByEmail(form.Email);
            if (existedUser is not null)
                return new MessageBoxData(MessageboxType.Error, "ایمیل تکراری است");

            if (!string.IsNullOrWhiteSpace(form.PhoneNumber))
            {
                existedUser = await repository.FindUserByPhoneNumber(form.PhoneNumber);
                if (existedUser is not null)
                    return new MessageBoxData(MessageboxType.Error, "شماره همراه تکراری است");
            }
            
            // Validate data
            var result = form.Validate();
            if (result is not null)
                return result;

            var user = new UserModel
            {
                FirstName = form.FirstName ,
                LastName = form.LastName,
                Email = form.Email,
                Password = Utils.HashPassword(form.Password, out var salt),
                Salt = salt,
                PhoneNumber = form.PhoneNumber
            };

            // Add to db
            await repository.AddEntity(user);
            await repository.SaveChanges();

            return new MessageBoxData(MessageboxType.Message, "کاربر با موفقیت ثبت شد");
        }
    }
}
