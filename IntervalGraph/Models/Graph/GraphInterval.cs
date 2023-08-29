using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace IntervalGraph.Models.Graph
{
    public class GraphInterval : Interval
    {
        public List<double> StrokeDashArray { get; set; } = new List<double>() { 1 };
        public double StrokeThickness { get; set; } = 1;
        public Brush StrokeBrush { get; set; } = Brushes.Black;
        public Brush FillBrush { get; set; } = Brushes.Black;

        /// <summary>
        /// Calculated relative to the height of the graph (from 0 to 1)
        /// </summary>
        public double? Height { get; set; }

        public object Icon { get; set; }
        public string LegendName { get; set; } = "";

        public GraphInterval() { }

        public GraphInterval(double x1, double x2, string legendName) : base(x1, x2)
        {
            LegendName = legendName;
        }

        public GraphInterval(Interval interval)
        {
            FirstPoint = (IntervalPoint)interval.FirstPoint.Clone();
            LastPoint = (IntervalPoint)interval.LastPoint.Clone();
            IsPositive = interval.IsPositive;
        }
        public GraphInterval(Interval interval, string legendName) : this(interval)
        {
            LegendName = legendName;
        }


        public new object Clone()
        {
            return new GraphInterval((Interval)base.Clone())
            {
                StrokeDashArray = StrokeDashArray,
                StrokeThickness = StrokeThickness,
                StrokeBrush = StrokeBrush,
                FillBrush = FillBrush,
                Height = Height,
                Icon = Icon,
                LegendName = LegendName,
            };
        }
    }
}
