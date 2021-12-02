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

namespace _01_Part
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textbox!= null)
            {
                textbox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int size = Convert.ToInt32(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (textbox != null)
            {
                textbox.FontSize = size;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == bold)
            {
                if (textbox.FontWeight == FontWeights.Normal)
                {
                    textbox.FontWeight = FontWeights.Bold;
                    bold.Opacity = 0.2;
                }
                else
                {
                    textbox.FontWeight = FontWeights.Normal;
                    bold.Opacity = 1;
                }
            }
            else if (e.OriginalSource == italic)
            {
                if (textbox.FontStyle == FontStyles.Normal)
                {
                    textbox.FontStyle = FontStyles.Italic;
                    italic.Opacity = 0.2;
                }
                else
                {
                    textbox.FontStyle = FontStyles.Normal;
                    italic.Opacity = 1;
                }
            }
            else if (e.OriginalSource == underline)
            {
                if (textbox.TextDecorations == null)
                {
                    textbox.TextDecorations = TextDecorations.Underline;
                    underline.Opacity = 0.2;
                }
                else
                {
                    textbox.TextDecorations = null;
                    underline.Opacity = 1;
                }
            }
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

            if ((e.OriginalSource as RadioButton).Content.ToString() == "Черный")
            {
                textbox.Foreground = Brushes.Black;
            }
            else if ((e.OriginalSource as RadioButton).Content.ToString() == "Красный")
            {
                textbox.Foreground = Brushes.Red;
            }
            else if ((e.OriginalSource as RadioButton).Content.ToString() == "Зеленый")
            {
                textbox.Foreground = Brushes.Green;
            }
        }
    }
}
