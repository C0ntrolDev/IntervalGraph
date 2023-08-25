using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.MultiConverters
{
    internal class CheckingForMultiplicity : MultiMarkupConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2) throw new InvalidOperationException("Не верное количество параметров");
            return (int)values[0] % (int)values[1] == 0;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
        throw new InvalidOperationException("Данный конвертер не предназначен для обратных преобразований");
    }
}
