namespace IntervalGraph.Models.Graph
{
    public class Interval<T>
    {
        public IntervalPoint<T> FirstPoint { get; set; }
        public IntervalPoint<T> LastPoint { get; set; }
        public bool IsPositive { get; set; }
    }

    public class Interval : Interval<int> { }
}
