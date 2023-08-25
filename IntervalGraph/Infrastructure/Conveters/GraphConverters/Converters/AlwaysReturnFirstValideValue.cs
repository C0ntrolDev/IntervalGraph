using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.Converters
{
    class AlwaysReturnFirstValideValue : MarkupConverter
    {
        private double? _valideNum;

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_valideNum != null) return _valideNum;

            double? num = System.Convert.ToDouble(value);
            if (num is null or double.NaN) return num;

            _valideNum = num;
            return _valideNum;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => _valideNum!;
    }
}
