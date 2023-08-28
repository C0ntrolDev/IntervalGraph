namespace IntervalGraph.Models.Graph
{
    public class Interval
    {
        public IntervalPoint FirstPoint { get; set; }
        public IntervalPoint LastPoint { get; set; }
        public bool IsPositive { get; set; }


        public Interval() { }

        public Interval(double? x1, double? x2)
        {
            if (x1 != null)
            {
                FirstPoint = new IntervalPoint((double)x1);
            }

            if (x2 != null)
            {
                LastPoint = new IntervalPoint((double)x2);
            }
        }

        public Interval(double? x1) : this(x1, x1) { }
    }
}
