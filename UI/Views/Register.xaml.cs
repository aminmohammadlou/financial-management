using System.Windows;
using System.Windows.Input;
using Service.ViewModels;

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
        // Get data from UI
        var registerForm = (RegisterForm)DataContext;
        registerForm.Password = PasswordInput.Password;
        registerForm.ConfirmPassword = ConfirmPasswordInput.Password;

        // Validate data
        var result = registerForm.Validate();
        if (result is not null)
        {
            var messageBox = new MessageBox();
            messageBox.ShowMessage(result);
        }
    }
}