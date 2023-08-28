namespace IntervalGraph.Models.Graph
{
    public class IntervalPoint
    {
        public int Id { get; set; }

        public double X { get; set; }
        public bool IsInclusive { get; set; } = true;

        public IntervalPoint() { }
        public IntervalPoint(double x)
        {
            X = x;
        }
    }
}
