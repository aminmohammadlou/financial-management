using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Service.ViewModels;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window
    {
        public MessageBox()
        {
            InitializeComponent();
        }

        private void MessageBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
                DragMove();
        }

        private void ConfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void ShowMessage(MessageBoxData data)
        {
            // Set data
            var messageboxData = new MessageBoxData(data.Type, data.Message);
            DataContext = messageboxData;

            // Set color
            var brush = messageboxData.Type switch
            {
                MessageboxType.Message => (Brush)FindResource("GreenBrush"),
                MessageboxType.Error => (Brush)FindResource("RedBrush"),
                MessageboxType.Confirm => (Brush)FindResource("PurpleBrush"),
                _ => throw new ArgumentOutOfRangeException()
            };
            MainBorder.Background = brush;

            ShowDialog();
        }
    }
}
