using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;

namespace RestuarantPOI
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Directory.GetCurrentDirectory() + "/Images/Items/" + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Substring(value.ToString().LastIndexOf('/') + 1);
        }
    }
}