using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.MultiConverters
{
    class StringFormatConverter : MultiMarkupConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object value = values[0];
            if (values[1] is string stringFormat && value != null)
            {
                return stringFormat
                    .Replace("{0}", value.ToString())
                    .Replace("{", "")
                    .Replace("}", "");
            }

            return null;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new InvalidOperationException("This converter is not intended for reverse conversions");
    }
}
