using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.MultiConverters
{
    public class IsValueDivisibleConverter : MultiMarkupConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
            {
                return false;
            }

            double value = System.Convert.ToDouble(values[0]);
            double devider = System.Convert.ToDouble(values[1]);

            return value % devider == 0;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new InvalidOperationException("This converter is not intended for reverse conversions");
    }
}
