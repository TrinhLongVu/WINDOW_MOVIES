using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using WpfApp1.Models;

namespace WpfApp1.Views
{
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            
        }

        private void AdminInitStatistic(object sender, RoutedEventArgs e)
        {
            (sender as Button).Focus();
        }

        private void MenuButtonFocus(object sender, RoutedEventArgs e)
        {
            Button focusedButton = sender as Button;
            if (focusedButton != null && focusedButton.IsFocused)
            {
                if (focusedButton.Name == "AdminStatistic")
                {
                    DashboardBody.Source = new Uri("DashboardStatistic.xaml", UriKind.Relative);
                }
                else if (focusedButton.Name == "AdminMovie")
                {
                    DashboardBody.Source = new Uri("MovieManagement.xaml", UriKind.Relative);
                }
                else if (focusedButton.Name == "AdminDirector")
                {
                    DashboardBody.Source = new Uri("DirectorManagement.xaml",UriKind.Relative);
                }
            }
        }

        private void AdminLogOut(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}