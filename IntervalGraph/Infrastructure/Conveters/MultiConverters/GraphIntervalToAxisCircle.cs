using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using IntervalGraph.Infrastructure.Conveters.Base;
using IntervalGraph.Models.Graph;

namespace IntervalGraph.Infrastructure.Conveters.MultiConverters
{
    public class GraphIntervalToAxisCircle : MultiMarkupConverter 
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            GraphInterval interval = values[0] as GraphInterval;
            double columnWidth = System.Convert.ToDouble(values[1]);
            double circleRadius = System.Convert.ToDouble(values[2]);

            PathFigure firstCircle = CreateCircle(interval.Interval.FirstPoint, columnWidth, circleRadius);
            PathFigure lastCircle = CreateCircle(interval.Interval.LastPoint, columnWidth, circleRadius);


            PathGeometry geometry = new PathGeometry();

            if (firstCircle != null)
            {
                geometry.AddGeometry(new PathGeometry(new List<PathFigure>(){firstCircle}));
            }

            if (lastCircle != null)
            {
                geometry.AddGeometry(new PathGeometry(new List<PathFigure>() { lastCircle }));
            }

            return geometry;
        }
       

        private LineSegment CreateInvisibleLineSegment(Point endPoint)
        {
            return new LineSegment()
            {
                Point = endPoint,
                IsStroked = false
            };
        }

        private PathFigure? CreateCircle(IntervalPoint<int> intervalPoint, double columnWidth, double circleRadius)
        {
            List<PathSegment> circleSegments = new List<PathSegment>();

            if (intervalPoint != null)
            {
                circleSegments.Add(new ArcSegment()
                {
                    Size = new Size(circleRadius, circleRadius),
                    RotationAngle = 0,
                    SweepDirection = SweepDirection.Counterclockwise,
                    IsLargeArc = true,
                    Point = new Point(intervalPoint.X * columnWidth + 0.1, 0),
                    IsStroked = true
                });

                PathFigure circle = new PathFigure(new Point(intervalPoint.X * columnWidth, 0), circleSegments, true);
                circle.IsFilled = intervalPoint.IsInclusive;

                return circle;
            }
            
            return null;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
