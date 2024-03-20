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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class Register : Page
    {
        private RegisterViewModel _viewModel;
        public Register()
        {
            _viewModel = new RegisterViewModel();
            DataContext = _viewModel;
            _viewModel.RegisterButtonClicked += ViewModel_RegisterButtonClicked;
            InitializeComponent();
        }
        private void ViewModel_RegisterButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Success register!!");
            NavigationService?.Navigate(new Login());
        }
        private void Navigate_Login(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
