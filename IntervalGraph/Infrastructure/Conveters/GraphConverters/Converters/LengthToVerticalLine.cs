using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.Converters
{
    class LengthToVerticalLine : MarkupConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double length = System.Convert.ToDouble(value);

            LineSegment line = new LineSegment(new Point(0, length), true);

            PathFigure figure = new PathFigure(new Point(0, 0), new List<LineSegment>() { line }, false);
            PathGeometry geometry = new PathGeometry(new List<PathFigure>() { figure });

            return geometry;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is PathGeometry geometry == false) throw new InvalidCastException("Не удалось преобразовать значение в фигуру");

            return ((LineSegment)geometry.Figures[0].Segments[^1]).Point.Y;
        }
    }
}
