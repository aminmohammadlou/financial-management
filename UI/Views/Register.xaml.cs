using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using UI.ViewModels;

namespace UI.Views;

public partial class Register : Window
{
    public Register()
    {
        InitializeComponent();
    }

    private void Register_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void LoginText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var loginWindow = new Login();
        loginWindow.Show();

        Close();
    }

    private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        var registerForm = (RegisterForm)DataContext;
        registerForm.Password = PasswordInput.Password;
        registerForm.ConfirmPassword = ConfirmPasswordInput.Password;

        try
        {
            registerForm.Validate();
        }
        catch (Exception ex)
        {
            var messageBox = new MessageBox();

            var messageboxData = new MessageBoxData(MessageboxType.Error, ex.Message);
            messageBox.DataContext = messageboxData;

            var brush = (Brush)FindResource("RedBrush");
            messageBox.MainBorder.Background = brush;

            messageBox.ButtonsStackPanel.Visibility = messageboxData.Type switch
            {
                MessageboxType.Message => Visibility.Collapsed,
                MessageboxType.Error => Visibility.Visible,
                MessageboxType.Confirm => Visibility.Visible,
                _ => throw new ArgumentOutOfRangeException()
            };

            messageBox.ShowDialog();
        }


    }
}