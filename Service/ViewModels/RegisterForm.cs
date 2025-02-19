using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Service.ViewModels;

public class RegisterForm
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }

    public MessageBoxData? Validate()
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            return new MessageBoxData(MessageboxType.Error, "فیلد نام نمی تواند خالی باشد");

        if (string.IsNullOrWhiteSpace(LastName))
            return new MessageBoxData(MessageboxType.Error, "فیلد نام خانوادگی نمی تواند خالی باشد");

        if (string.IsNullOrWhiteSpace(Email))
            return new MessageBoxData(MessageboxType.Error, "فیلد ایمیل نمی تواند خالی باشد");

        try
        {
            _ = new MailAddress(Email);
        }
        catch (FormatException)
        {
            return new MessageBoxData(MessageboxType.Error, "فرمت ایمیل اشتباه است");
        }

        if (!string.IsNullOrWhiteSpace(PhoneNumber))
        {
            var phoneNumberRegex = new Regex("^09[0|1|2|3|9][0-9]{8}$");

            if (!phoneNumberRegex.IsMatch(PhoneNumber))
                return new MessageBoxData(MessageboxType.Error, "فرمت شماره همراه اشتباه است");
        }

        if (string.IsNullOrWhiteSpace(Password))
            return new MessageBoxData(MessageboxType.Error, "فیلد رمز عبور نمی تواند خالی باشد");

        if (string.IsNullOrWhiteSpace(ConfirmPassword))
            return new MessageBoxData(MessageboxType.Error, "فیلد تکرار رمز عبور نمی تواند خالی باشد");

        return Password != ConfirmPassword ? new MessageBoxData(MessageboxType.Error, "رمز عبور با تکرار آن برابر نیست") : null;
    }
}