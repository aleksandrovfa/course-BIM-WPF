using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _01_Part
{
    public class WindowCommands
    {
        public static RoutedCommand Exit { get; set; }
        static WindowCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
        }

    }
}
