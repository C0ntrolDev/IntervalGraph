using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.MultiConverters
{
    internal class ReturnAreValuesEqual : MultiMarkupConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(values[0], values[1]);
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new InvalidOperationException("Данный конвертер не предназначен для обратных преобразований");
    }
}
