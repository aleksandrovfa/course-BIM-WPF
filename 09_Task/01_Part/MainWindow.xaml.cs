using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

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
            if (textbox != null)
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
        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textbox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textbox.Text);
            }
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Тут должна быть справка");
        }

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int themeIndex = themeBox.SelectedIndex;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            if (themeIndex == 1)
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }
    }

    
}
