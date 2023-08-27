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
            if (values.Length != 9) throw new InvalidOperationException("Values is not set correctly. Template: GraphInterval, ColumnWidth, GraphWidth, GraphHeight, MinValue, MaxValue, MaxIntervalHeight, MaxStableIntervalHeight, IsIntervalHeightDependToWidth");

            GraphInterval interval = (GraphInterval)values[0];

            double columnWidth = System.Convert.ToDouble(values[1]);

            double graphWidth = System.Convert.ToDouble(values[2]);
            double graphHeight = System.Convert.ToDouble(values[3]);

            double minValue = System.Convert.ToDouble(values[4]);
            double maxValue = System.Convert.ToDouble(values[5]);

            double maxIntervalHeight = System.Convert.ToDouble(values[6]);
            double maxStableIntervalHeight = System.Convert.ToDouble(values[7]);

            bool isIntervalHeightDependToWidth = System.Convert.ToBoolean(values[8]);




            double? firstPoint = interval.Interval.FirstPoint?.X;
            double? lastPoint = interval.Interval.LastPoint?.X;

            if (firstPoint == null && lastPoint == null) return null;

            double intervalHeight;
            double intervalWidth = CalculateIntervalLength(firstPoint, lastPoint, minValue, maxValue) * columnWidth;

            if (isIntervalHeightDependToWidth)
            {
                double maxAvailableIntervalsHeigth = graphHeight * maxIntervalHeight;

                double heightRatio = intervalWidth / graphWidth;
                double stableHeight = maxAvailableIntervalsHeigth * maxStableIntervalHeight;
                double unstableHeight = heightRatio * maxAvailableIntervalsHeigth * (1 - maxStableIntervalHeight);

                intervalHeight = stableHeight + unstableHeight;
            }
            else
            {
                intervalHeight = graphHeight * maxIntervalHeight;
            }



            List<PathSegment> allSegments = new List<PathSegment>();

            double segmentLength;
            if (intervalWidth / 2 > intervalHeight)
            {
                segmentLength = intervalHeight;
            }
            else
            {
                segmentLength = intervalWidth / 2;
            }

            double startDrawingPoint = (firstPoint - minValue) * columnWidth ?? 0;
            double endDrawingPoint = startDrawingPoint + intervalWidth;
            double intervalHeightY = graphHeight - intervalHeight;

            if (firstPoint == null)
            {
                allSegments.Add(CreateInvisibleLineSegment(new Point(0, intervalHeightY)));
                allSegments.Add(CreateHorizontalLineSegment(new Point(segmentLength + startDrawingPoint, intervalHeightY)));
            }
            else
            {
                allSegments.Add(CreateInvisibleLineSegment(new Point(startDrawingPoint, graphHeight)));
                allSegments.Add(CreateArcSegment(segmentLength, intervalHeight, new Point(segmentLength + startDrawingPoint, intervalHeightY)));
            }


            if (segmentLength == intervalHeight)
            {
                allSegments.Add(CreateHorizontalLineSegment(new Point(endDrawingPoint - segmentLength, intervalHeightY)));
            }


            if (lastPoint == null)
            {
                allSegments.Add(CreateHorizontalLineSegment(new Point(graphWidth, intervalHeightY)));
                allSegments.Add(CreateInvisibleLineSegment(new Point(graphWidth, graphHeight)));
            }
            else
            {
                allSegments.Add(CreateArcSegment(segmentLength, intervalHeight, new Point(endDrawingPoint, graphHeight)));
            }


            PathFigure figure = new PathFigure(new Point(0, graphHeight), allSegments, false);
            PathGeometry geometry = new PathGeometry(new List<PathFigure>() { figure });

            return geometry;
        }

        private double CalculateIntervalLength(double? firstPoint, double? lastPoint, double minValue, double maxValue)
        {
            double intervalLength;

            if (firstPoint == null)
            {
                intervalLength = (double)lastPoint! - minValue;
            }
            else if (lastPoint == null)
            {
                intervalLength = maxValue - (double)firstPoint;
            }
            else
            {
                intervalLength = (double)lastPoint - (double)firstPoint;
            }

            return intervalLength;
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
            throw new InvalidOperationException("This converter is not intended for reverse conversions");

    }
}
