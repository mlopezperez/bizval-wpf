using System;
using System.Globalization;
using System.Windows.Data;

namespace BizVal.App.Converters
{
    [ValueConversion(typeof(decimal), typeof(string))]
    public class StringToDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            decimal decimalValue = decimal.Parse(value.ToString());
            return decimalValue.ToString(CultureInfo.InvariantCulture);


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value as string;
            decimal result;
            if (!Decimal.TryParse(stringValue, out result))
            {
                return 0m;
            }
            else
            {
                return result;
            }

        }
    }
}
