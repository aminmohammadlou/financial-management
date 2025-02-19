using System.Net.Mail;

namespace Service.ViewModels;

public class LoginForm
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required bool IsRememberMeChecked { get; set; }

    public MessageBoxData? Validate()
    {
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

        return string.IsNullOrWhiteSpace(Password) ? new MessageBoxData(MessageboxType.Error, "فیلد رمز عبور نمی تواند خالی باشد") : null;
    }
}