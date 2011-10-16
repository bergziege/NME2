using System;
using System.Globalization;
using System.Windows.Data;

namespace NME2_Server_Manager.Converter {
    [ValueConversion(typeof(double), typeof(int))]
    public class DoubleToIntegerConverter : IValueConverter {
        public object Convert(
         object value, Type targetType,
         object parameter, CultureInfo culture) {
            return (int)(double)value;
        }

        public object ConvertBack(
         object value, Type targetType,
         object parameter, CultureInfo culture) {
            throw new NotSupportedException("Cannot convert back");
        }
    }

}
