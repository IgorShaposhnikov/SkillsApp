using System;
using System.Globalization;
using System.Windows.Data;

namespace SkillApp.WPF.Converters
{
    public class StringToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
                return (double)value;

            var str = (string)value;

            if (double.TryParse(str, out double result)) 
            {
                return result;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
