using System.Windows;
using System.Windows.Input;
using Service.Services;

namespace UI.Views.ForgotPasswordViews;

/// <summary>
/// Interaction logic for ForgotPassword.xaml
/// </summary>
public partial class ForgotPassword : Window
{
    private readonly UserService _userService;

    public ForgotPassword(UserService userService)
    {
        _userService = userService;
        InitializeComponent();
    }

    private void ForgotPassword_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void BackText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var login = new Login(_userService);
        login.Show();

        Close();
    }

    private void ExitButton_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Close();
    }
}