using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _01_Part
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -100 && v <= 100)
                return true;
            else
                return false;

        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v < -50)
                return -50;
            else if (v >= -50 && v <= 50)
                return v;
            else if (v > 50)
                return 50;
            else
                return 0;
        }

        public int Temperature
        {
            get { return (int)GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }

        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public enum Precipitation : byte
        {
            Sunny,
            Cloudy,
            Rain,
            Snow,
        }
    }
}
