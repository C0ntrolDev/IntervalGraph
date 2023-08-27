using System;
using System.Globalization;
using System.Windows.Data;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.Converters
{
    public class CompositeConverter : MarkupConverter
    {
        public IValueConverter First { get; set; }
        public IValueConverter Second { get; set; }


        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object? firstResult = First?.Convert(value, targetType, parameter, culture);
            object? secondResult = Second?.Convert(firstResult, targetType, parameter, culture);

            return secondResult!;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object? secondResult = Second?.ConvertBack(value, targetType, parameter, culture);
            object? firstResult = First?.Convert(secondResult, targetType, parameter, culture);

            return firstResult!;
        }
    }
}
