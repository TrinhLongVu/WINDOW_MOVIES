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

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
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
