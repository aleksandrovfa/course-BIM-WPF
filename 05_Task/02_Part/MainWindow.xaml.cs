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

namespace _02_Part
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
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (ink != null)
            {
                if ((e.OriginalSource as RadioButton).Content.ToString() == "Черный")
                {
                    ink.DefaultDrawingAttributes.Color = Colors.Black;
                }
                else if ((e.OriginalSource as RadioButton).Content.ToString() == "Красный")
                {
                    ink.DefaultDrawingAttributes.Color = Colors.Red;
                }
                else if ((e.OriginalSource as RadioButton).Content.ToString() == "Зеленый")
                {
                    ink.DefaultDrawingAttributes.Color = Colors.Green;
                }

            }


        }
        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                //textbox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG-файл (*.jpeg)|*.jpeg";
            if (saveFileDialog.ShowDialog() == true)
            {
                //File.WriteAllText(saveFileDialog.FileName, i);
                //File.
            }

        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ink != null)
            {
                Slider sl = sender as Slider;
                ink.DefaultDrawingAttributes.Width = sl.Value;
            }
                
        }

        private void eraser_Click(object sender, RoutedEventArgs e)
        {
            if (ink != null)
            {
                if (ink.EditingMode == InkCanvasEditingMode.Ink)
                {
                    ink.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    eraser.Opacity = 0.2;
                }
                else
                {
                    ink.EditingMode = InkCanvasEditingMode.Ink;
                    eraser.Opacity = 1;
                }
            }

        }
    }
}
