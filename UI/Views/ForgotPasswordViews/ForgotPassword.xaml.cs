using System.Windows;
using System.Windows.Input;

namespace UI.Views.ForgotPasswordViews;

/// <summary>
/// Interaction logic for ForgotPassword.xaml
/// </summary>
public partial class ForgotPassword : Window
{
    public ForgotPassword()
    {
        InitializeComponent();
    }

    private void ForgotPassword_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void BackText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var login = new Login();
        login.Show();

        Close();
    }
}