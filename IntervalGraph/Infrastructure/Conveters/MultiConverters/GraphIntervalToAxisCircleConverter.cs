using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using IntervalGraph.Infrastructure.Conveters.Base;
using IntervalGraph.Models.Graph;

namespace IntervalGraph.Infrastructure.Conveters.MultiConverters
{
    public class GraphIntervalToAxisCircleConverter : MultiMarkupConverter 
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 4) throw new InvalidOperationException("Values is not set correctly. Template: GraphInterval, ColumnWidth, MinValue, CircleRadius");

            GraphInterval interval = (GraphInterval)values[0];
            double columnWidth = System.Convert.ToDouble(values[1]);
            double minValue = System.Convert.ToDouble(values[2]);
            double circleRadius = System.Convert.ToDouble(values[3]);

            PathFigure? firstCircle = CreateCircle(interval.FirstPoint, columnWidth, minValue, circleRadius);
            PathFigure? lastCircle = CreateCircle(interval.LastPoint, columnWidth, minValue, circleRadius);


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
        
        private PathFigure? CreateCircle(IntervalPoint? intervalPoint, double columnWidth, double minValue, double circleRadius)
        {
            if (intervalPoint != null)
            {
                List<PathSegment> circleSegments = new List<PathSegment>();

                double pointRelativeToMinValue = intervalPoint.X - minValue;
                double startPoint = pointRelativeToMinValue * columnWidth;

                circleSegments.Add(new ArcSegment()
                {
                    Size = new Size(circleRadius, circleRadius),
                    RotationAngle = 0,
                    SweepDirection = SweepDirection.Counterclockwise,
                    IsLargeArc = true,
                    Point = new Point(startPoint + 0.1, 0),
                    IsStroked = true
                });

                PathFigure circle = new PathFigure(new Point(startPoint, 0), circleSegments, true);
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
