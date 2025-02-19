using System.Windows;
using System.Windows.Input;
using Service.Services;
using Service.ViewModels;

namespace UI.Views;

public partial class Register : Window
{
    private readonly UserService _userService;

    public Register(UserService userService)
    {
        _userService = userService;
        InitializeComponent();
    }

    private void Register_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void LoginText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var loginWindow = new Login(_userService);
        loginWindow.Show();

        Close();
    }

    private async void RegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        // Get data from UI
        var registerForm = (RegisterForm)DataContext;
        registerForm.Password = PasswordInput.Password;
        registerForm.ConfirmPassword = ConfirmPasswordInput.Password;

        var result = await _userService.Register(registerForm);

        var messageBox = new MessageBox();
        messageBox.ShowMessage(result);

        // Enter to app
        if (result.Type is MessageboxType.Message)
        {
            var home = new Home();

            home.DataContext = new HomePageData
            {
                TopBarText = $"! سلام {registerForm.FirstName}"
            };

            home.Show();

            Close();
        }
    }
}