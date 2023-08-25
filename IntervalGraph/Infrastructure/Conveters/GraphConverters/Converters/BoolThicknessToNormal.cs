using System;
using System.Globalization;
using System.Windows;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.Converters
{
    class BoolThicknessToNormal : MarkupConverter
    {
        public Thickness BoolThickness { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);

            Thickness realThickness = BoolThickness;

            realThickness.Bottom *= doubleValue;
            realThickness.Left *= doubleValue;
            realThickness.Right *= doubleValue;
            realThickness.Top += doubleValue;

            return realThickness;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new InvalidOperationException("Данный конвертер не предназначен для обратных преобразований");

    }
}
