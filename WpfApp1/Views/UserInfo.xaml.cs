using System.Windows;

namespace WpfApp1.Views
{
    public partial class UserInfo : Window
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
