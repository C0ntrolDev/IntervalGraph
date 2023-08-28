namespace IntervalGraph.Models.Graph
{
    public class Interval<T>
    {
        public IntervalPoint<T> FirstPoint { get; set; }
        public IntervalPoint<T> LastPoint { get; set; }
        public bool IsPositive { get; set; }


        public Interval() { }

        public Interval(T? x1, T? x2)
        {
            if (x1 != null)
            {
                FirstPoint = new IntervalPoint<T>(x1);
            }

            if (x2 != null)
            {
                LastPoint = new IntervalPoint<T>(x2);
            }
        }

        public Interval(T? x1) : this(x1, x1) { }
    }

    public class Interval : Interval<double> { }
}
