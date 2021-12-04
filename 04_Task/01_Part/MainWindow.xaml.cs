using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private void UniformGrid_Click(object sender, RoutedEventArgs e)
        {
            string BtnName = (e.OriginalSource as Button).Name.ToString();
            switch (BtnName)
            {
                case "btn0":
                    resSum0.Text = Result(rate0, sum0);
                    break;
                case "btn1":
                    resSum1.Text = Result(rate1, sum1);
                    break;
                case "btn2":
                    resSum2.Text = Result(rate2, sum2);
                    break;
                case "btn3":
                    resSum3.Text = Result(rate3, sum3);
                    break;
                case "distBtn0":
                    distResult0.Text = Result(distIn0, 0.0254);
                    break;
                case "distBtn1":
                    distResult1.Text = Result(distIn1, 0.3048);
                    break;
                case "distBtn2":
                    distResult2.Text = Result(distIn2, 1609.34);
                    break;
                case "distBtn3":
                    distResult3.Text = Result(distIn3, 1066.8);
                    break;
            }
        }
        private string Result (TextBox t1,TextBox t2)
        {
            try
            {
                double rate = Convert.ToDouble(t1.Text);
                double sum = Convert.ToDouble(t2.Text);
                string res = (rate * sum).ToString();
                return res;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private string Result(TextBox t1, double t2)
        {
            try
            {
                double rate = Convert.ToDouble(t1.Text);
                double sum = t2;
                string res = (rate * sum).ToString();
                return res;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
