using System.Windows;
using System.Windows.Input;

namespace UI.Views.ForgotPasswordViews;

/// <summary>
/// Interaction logic for VerificationCode.xaml
/// </summary>
public partial class VerificationCode : Window
{
    public VerificationCode()
    {
        InitializeComponent();
    }

    private void VerificationCode_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void BackText_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var forgotPassword = new ForgotPassword();
        forgotPassword.Show();

        Close();
    }
}