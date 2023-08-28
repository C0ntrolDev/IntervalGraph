namespace IntervalGraph.Models.Graph
{
    public class IntervalPoint<T>
    {
        public T X { get; set; }
        public bool IsInclusive { get; set; } = true;

        public IntervalPoint() { }
        public IntervalPoint(T x)
        {
            X = x;
        }
    }
}
