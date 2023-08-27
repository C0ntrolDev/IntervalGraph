using System.Collections.Generic;
using System.Windows.Media;

namespace IntervalGraph.Models.Graph
{
    public class GraphInterval<T>
    {
        public Interval<T> Interval { get; set; }

        public List<double> StrokeDashArray { get; set; } = new List<double>() { 1 };
        public double StrokeThickness { get; set; } = 1;
        public Brush StrokeBrush { get; set; } = Brushes.Black;
        public Brush FillBrush { get; set; } = Brushes.Black;

        public object Icon { get; set; }
        public string LegendName { get; set; } = "";
        public bool IsEnabled { get; set; } = true;
    }

    public class GraphInterval : GraphInterval<int> { }
}
