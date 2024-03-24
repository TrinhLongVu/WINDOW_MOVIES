using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class UserInfo : Window
    {
        private UserInfoViewModel _model;
        public UserInfo()
        {
            _model = new UserInfoViewModel();
            DataContext = _model;
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
