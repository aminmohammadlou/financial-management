using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI.Views.ForgotPasswordViews
{
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
}
