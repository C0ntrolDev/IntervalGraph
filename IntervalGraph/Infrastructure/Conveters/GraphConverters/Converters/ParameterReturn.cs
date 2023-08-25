using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.Converters
{
    internal class ParameterReturn : MarkupConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => parameter;
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => parameter;
    }
}
