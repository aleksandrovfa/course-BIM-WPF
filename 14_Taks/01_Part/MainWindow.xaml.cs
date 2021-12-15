using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Product> products;
        public MainWindow()
        {
            InitializeComponent();
            products = new ObservableCollection<Product>();
            products.Add(new Product()
            {
                ProductName = "Картошка",
                Cost = 50,
                ProductType = ProductTypes.Food,
                Image = "Data/еда.png"
            });
            products.Add(new Product()
            {
                ProductName = "Стиральная машина",
                Cost = 16550,
                ProductType = ProductTypes.Technics,
                Image = "Data/техника.png"
            });
            products.Add(new Product()
            {
                ProductName = "Салат",
                Cost = 150,
                ProductType = ProductTypes.Food,
                Image = "Data/еда.png"
            });
            products.Add(new Product()
            {
                ProductName = "Кофемашина",
                Cost = 6700,
                ProductType = ProductTypes.Food,
                Image = "Data/техника.png"
            });
        }
    }
}
