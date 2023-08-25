using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.Converters
{
    class TestConverter : MarkupConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
