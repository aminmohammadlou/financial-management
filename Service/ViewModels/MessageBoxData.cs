namespace Service.ViewModels;

public class MessageBoxData
{
    public MessageBoxData(MessageboxType type, string message)
    {
        Type = type;
        Title = Type switch
        {
            MessageboxType.Message => "پیغام",
            MessageboxType.Error => "خطا",
            MessageboxType.Confirm => "تایید",
            _ => throw new ArgumentOutOfRangeException()
        };
        Message = message;
    }

    public MessageboxType Type { get; set; }

    public string Title { get; }
    public string Message { get; set; }
}