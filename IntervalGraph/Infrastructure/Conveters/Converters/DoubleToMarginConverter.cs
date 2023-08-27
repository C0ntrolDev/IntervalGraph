using System;
using System.Globalization;
using System.Windows;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.Converters
{
    public class DoubleToMarginConverter : MarkupConverter
    {
        public Thickness BoolMargin { get; set; } = new Thickness(1, 1, 1, 1);

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);

            if (Double.IsNaN(doubleValue))
            {
                return new Thickness(1,1,1,1);
            }

            return new Thickness()
            {
                Bottom = BoolMargin.Bottom * doubleValue,
                Left = BoolMargin.Left * doubleValue,
                Right = BoolMargin.Right * doubleValue,
                Top = BoolMargin.Top * doubleValue
            };
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new InvalidOperationException("This converter is not intended for reverse conversions");
    }
}
