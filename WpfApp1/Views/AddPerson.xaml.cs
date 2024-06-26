﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class AddPerson : Window
    {
        public AddPerson(String type)
        {
            InitializeComponent();
            if (type == "director")
            {
                Title = "Add a director";
            }
            else if (type == "cast")
            {
                Title = "Add a cast";
            }
            AddPersonViewModel viewModel = new AddPersonViewModel(type);
            DataContext = viewModel;
            viewModel.ClickInsert += ViewModel_Clicked;
        }
        public AddPerson(String type, int id) {
            InitializeComponent();
            if (type == "director") {
                Title = "Update a director";
            } else if (type == "cast") {
                Title = "Update a cast";
            }
            AddPersonViewModel viewModel = new AddPersonViewModel(type, id);
            DataContext = viewModel;
            viewModel.ClickInsert += ViewModel_Clicked;
        }
        private void ViewModel_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        private void imgUrlChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string text = textBox.Text;
                try
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(text));
                    AvatarPreview.ImageSource = bitmapImage;
                }
                catch (Exception ex)
                {
                    AvatarPreview.ImageSource = null;
                }
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
