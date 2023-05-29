using SkillApp.Core.Tools;
using SkillApp.WPF.Properties;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SkillApp.WPF.Converters
{
    public sealed class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is Enum)
            {
                var enumObj = (Enum)value; 
                return EnumTools.GetEnumDescription(enumObj);
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;

            foreach (object enumValue in Enum.GetValues(targetType))
            {
                if (str == Resources.ResourceManager.GetString(enumValue.ToString()))
                {
                    return enumValue;
                }
            }

            throw new ArgumentException(null, "value");
        }
    }
}
