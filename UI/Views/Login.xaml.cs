using System.Windows;
using System.Windows.Input;

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

    private void RegisterText_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var registerWindow = new Register();
        registerWindow.Show();

        Close();
    }
}