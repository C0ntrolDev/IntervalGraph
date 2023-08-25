using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using IntervalGraph.Infrastructure.Conveters.Base;
using IntervalGraph.Models.Graph;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.MultiConverters
{
    class GraphIntervalToGeometry : MultiMarkupConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 7) throw new InvalidOperationException("Values задано не верно. Шаблон: Интервал, Ширина_столбца, Высота_столбца, Мин_знач, Мак_знач, Коэффицент_доп_высоты_от_длинны, Коэффицент_ширины_линии");

            GraphInterval interval = (GraphInterval)values[0];

            double columnWidth = System.Convert.ToDouble(values[1]);
            double columnHeight = System.Convert.ToDouble(values[2]);

            double minValue = System.Convert.ToDouble(values[3]);
            double maxValue = System.Convert.ToDouble(values[4]);

            double stableRatio = System.Convert.ToDouble(values[5]);
            double ratio = System.Convert.ToDouble(values[6]);


            double axisLength = (maxValue - minValue) * columnWidth;
            double graphLength = (interval.Interval.LastPoint.X - interval.Interval.FirstPoint.X) * columnWidth;

            double startIntervalPoint = interval.Interval.FirstPoint.X * columnWidth;
            double endIntervalPoint = interval.Interval.LastPoint.X * columnWidth;

            double maxStableHeight = columnHeight * stableRatio;
            double maxHeight = maxStableHeight + ratio * columnHeight * (graphLength / axisLength);

            double realMaxHeight = columnHeight - maxHeight;


            List<PathSegment> allSegments = new List<PathSegment>();


            double segmentLength;
            if (graphLength / 2 > maxHeight)
            {
                segmentLength = maxHeight;
            }
            else
            {
                segmentLength = graphLength / 2;
            }


            if (interval.Interval.FirstPoint.X <= minValue)
            {
                allSegments.Add(CreateInvisibleLineSegment(new Point(startIntervalPoint, realMaxHeight)));
                allSegments.Add(CreateHorizontalLineSegment(new Point(segmentLength + startIntervalPoint, realMaxHeight)));
            }
            else
            {
                allSegments.Add(CreateInvisibleLineSegment(new Point(startIntervalPoint, columnHeight)));
                allSegments.Add(CreateArcSegment(segmentLength, maxHeight, new Point(segmentLength + startIntervalPoint, realMaxHeight)));
            }


            if (segmentLength == maxHeight)
            {
                allSegments.Add(CreateHorizontalLineSegment(new Point(endIntervalPoint - segmentLength, realMaxHeight)));
            }


            if (interval.Interval.LastPoint.X >= maxValue)
            {
                allSegments.Add(CreateHorizontalLineSegment(new Point(axisLength, realMaxHeight)));
                allSegments.Add(CreateInvisibleLineSegment(new Point(axisLength, columnHeight)));
            }
            else
            {
                allSegments.Add(CreateArcSegment(segmentLength, maxHeight, new Point(endIntervalPoint, columnHeight)));
            }


            PathFigure figure = new PathFigure(new Point(0,columnHeight), allSegments, false);
            PathGeometry geometry = new PathGeometry(new List<PathFigure>() { figure });

            return geometry;
        }

        private ArcSegment CreateArcSegment(double width, double height, Point endPoint)
        {
            return new ArcSegment()
            {
                Size = new Size(width, height),
                RotationAngle = 0,
                SweepDirection = SweepDirection.Clockwise,
                IsLargeArc = false,
                Point = endPoint,
                IsStroked = true
            };
        }
        private LineSegment CreateInvisibleLineSegment(Point endPoint)
        {
            return new LineSegment()
            {
                Point = endPoint,
                IsStroked = false
            };
        }
        private LineSegment CreateHorizontalLineSegment(Point endPoint)
        {
            return new LineSegment()
            {
                Point = endPoint,
                IsStroked = true
            };
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new InvalidOperationException("Данный конвертер не предназначен для обратных преобразований");

    }
}
