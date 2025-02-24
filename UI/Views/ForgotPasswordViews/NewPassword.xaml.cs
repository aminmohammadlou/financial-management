using System.Windows;
using System.Windows.Input;

namespace UI.Views.ForgotPasswordViews;

/// <summary>
/// Interaction logic for NewPassword.xaml
/// </summary>
public partial class NewPassword : Window
{
    public NewPassword()
    {
        InitializeComponent();
    }

    private void NewPassword_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void ExitButton_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Close();
    }
}