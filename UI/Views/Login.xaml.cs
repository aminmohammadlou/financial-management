using System.Windows;
using System.Windows.Input;
using Service.Services;
using Service.ViewModels;
using UI.Views.ForgotPasswordViews;

namespace UI.Views;
public partial class Login : Window
{
    private readonly UserService _userService;

    public Login(UserService userService)
    {
        _userService = userService;
        InitializeComponent();
    }

    private void Login_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void RegisterText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var registerWindow = new Register(_userService);
        registerWindow.Show();

        Close();
    }

    private void ForgotPasswordText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var forgotPasswordWindow = new ForgotPassword(_userService);
        forgotPasswordWindow.Show();

        Close();
    }

    private async void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        // Get data from UI
        var loginForm = (LoginForm)DataContext;
        loginForm.Password = PasswordInput.Password;

        var result = await _userService.Login(loginForm);

        var messageBox = new MessageBox();
        messageBox.ShowMessage(result);

        // Enter to app
        if (result.Type is MessageboxType.Message)
        {
            var userFirstName = await _userService.GetUserFirstNameByEmail(loginForm.Email);
            var home = new Home();

            home.DataContext = new HomePageData
            {
                TopBarText = $"! سلام {userFirstName}"
            };

            home.Show();

            Close();
        }
    }
}