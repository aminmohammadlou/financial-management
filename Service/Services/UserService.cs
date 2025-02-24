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

        public async Task<MessageBoxData> Login(LoginForm form)
        {
            // Validate data
            var result = form.Validate();
            if (result is not null)
                return result;

            // Find user
            var user = await repository.FindUserByEmail(form.Email);
            if (user is null)
                return new MessageBoxData(MessageboxType.Error, "کاربر با این ایمیل پیدا نشد");

            // Validate password
            var messageBox = !Utils.VerifyPassword(form.Password, user.Salt, user.Password) ? new MessageBoxData(MessageboxType.Error, "رمز عبور اشتباه است") : new MessageBoxData(MessageboxType.Message, "ورود با موفقیت انجام شد");

            if (form.IsRememberMeChecked)
            {
                var settings = await repository.GetSettings();
                settings.LastUserLoggedInEmail = form.Email;
                await repository.SaveChanges();
            }

            return messageBox;
        }

        public async Task<string> GetUserFirstNameByEmail(string email)
        {
            var user = await repository.GetUserByEmail(email);
            return user.FirstName;
        }
    }
}
