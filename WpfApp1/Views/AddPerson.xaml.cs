using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
    }
}
