namespace IntervalGraph.Models.Graph
{
    public struct IntervalPoint<T>
    {
        public T X { get; set; }
        public bool IsInclusive { get; set; }
    }
}
