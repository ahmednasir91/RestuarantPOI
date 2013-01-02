using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using RestuarantPOI.Models;

namespace RestuarantPOI.Helpers
{
    public class RemainingIngredients : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentIngredients = value as BindingList<StockItem> ?? new BindingList<StockItem>();
            BindingList<StockItem> allIngredients;
            using (var dataStorage = new DataStorage())
                allIngredients = dataStorage.StockItems() as BindingList<StockItem> ?? new BindingList<StockItem>();
            return allIngredients.ExceptBy(currentIngredients, s => s.ItemName).Select(i => i.ItemName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}