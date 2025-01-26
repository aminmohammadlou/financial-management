using System.Windows;
using System.Windows.Input;

namespace UI.Views;
public partial class Register : Window
{
    public Register()
    {
        InitializeComponent();
    }

    private void Register_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void LoginText_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var loginWindow = new Login();
        loginWindow.Show();

        Close();
    }
}