using System.Windows;
using System.Windows.Input;
using Service.Services;
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

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        var homeWindow = new Home();
        homeWindow.Show();

        Close();
    }
}