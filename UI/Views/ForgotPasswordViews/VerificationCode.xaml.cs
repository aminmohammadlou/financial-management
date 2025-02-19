using System.Windows;
using System.Windows.Input;
using Service.Services;

namespace UI.Views.ForgotPasswordViews;

/// <summary>
/// Interaction logic for VerificationCode.xaml
/// </summary>
public partial class VerificationCode : Window
{
    private readonly UserService _userService;

    public VerificationCode(UserService userService)
    {
        _userService = userService;
        InitializeComponent();
    }

    private void VerificationCode_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void BackText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var forgotPassword = new ForgotPassword(_userService);
        forgotPassword.Show();

        Close();
    }
}