using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SnackMVVM.Helpers
{
    class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double num = double.Parse(value.ToString());
            if (num <= 3)
                return Brushes.Red;
            else if (num <= 8)
                return Brushes.Orange;
            else if (num <= 13)
                return Brushes.Yellow;
            else if (num <= 18)
                return Brushes.GreenYellow;
            else
                return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}