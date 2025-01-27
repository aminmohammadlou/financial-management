using System.Windows;
using System.Windows.Input;
using UI.Views.ForgotPasswordViews;

namespace UI.Views;
public partial class Login : Window
{
    public Login()
    {
        InitializeComponent();
    }

    private void Login_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void RegisterText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var registerWindow = new Register();
        registerWindow.Show();

        Close();
    }

    private void ForgotPasswordText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var forgotPasswordWindow = new ForgotPassword();
        forgotPasswordWindow.Show();

        Close();
    }
}