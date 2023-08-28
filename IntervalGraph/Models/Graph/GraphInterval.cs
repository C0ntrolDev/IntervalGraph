using System.Collections.Generic;
using System.Windows.Media;

namespace IntervalGraph.Models.Graph
{
    public class GraphInterval<T> : Interval<T>
    {
        public List<double> StrokeDashArray { get; set; } = new List<double>() { 1 };
        public double StrokeThickness { get; set; } = 1;
        public Brush StrokeBrush { get; set; } = Brushes.Black;
        public Brush FillBrush { get; set; } = Brushes.Black;

        public object Icon { get; set; }
        public string LegendName { get; set; } = "";
        public bool IsEnabled { get; set; } = true;


        public GraphInterval() { }

        public GraphInterval(T x1, T x2, string legendName) : base(x1, x2)
        {
            LegendName = legendName;
        }

        public GraphInterval(Interval<T> interval)
        {
            FirstPoint = interval.FirstPoint;
            LastPoint = interval.LastPoint;
            IsPositive = interval.IsPositive;
        }
        public GraphInterval(Interval<T> interval, string legendName) : this(interval)
        {
            LegendName = legendName;
        }
    }

    public class GraphInterval : GraphInterval<double> { }
}
