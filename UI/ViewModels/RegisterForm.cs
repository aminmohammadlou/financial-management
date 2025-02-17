using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UI.ViewModels;

public class RegisterForm
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            throw new Exception("فیلد نام نمی تواند خالی باشد");

        if (string.IsNullOrWhiteSpace(LastName))
            throw new Exception("فیلد نام خانوادگی نمی تواند خالی باشد");

        if (string.IsNullOrWhiteSpace(Email))
            throw new Exception("فیلد ایمیل نمی تواند خالی باشد");

        try
        {
            _ = new MailAddress(Email);
        }
        catch (FormatException ex)
        {
            throw new Exception("فرمت ایمیل اشتباه است");
        }

        if (!string.IsNullOrWhiteSpace(PhoneNumber))
        {
            var phoneNumberRegex = new Regex("^09[0|1|2|3|9][0-9]{8}$");
            if (!phoneNumberRegex.IsMatch(PhoneNumber))
                throw new Exception("فرمت شماره همراه اشتباه است");
        }

        if (string.IsNullOrWhiteSpace(Password))
            throw new Exception("فیلد رمز عبور نمی تواند خالی باشد");

        if (string.IsNullOrWhiteSpace(ConfirmPassword))
            throw new Exception("فیلد تکرار رمز عبور نمی تواند خالی باشد");

        if (Password != ConfirmPassword)
            throw new Exception("رمز عبور با تکرار آن برابر نیست");
    }
}