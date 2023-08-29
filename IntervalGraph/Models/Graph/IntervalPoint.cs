using System;

namespace IntervalGraph.Models.Graph
{
    public class IntervalPoint : ICloneable
    {
        public int Id { get; set; }

        public double X { get; set; }
        public bool IsInclusive { get; set; } = true;

        public IntervalPoint() { }
        public IntervalPoint(double x)
        {
            X = x;
        }

        public object Clone()
        {
            return new IntervalPoint()
            {
                Id = Id,
                IsInclusive = IsInclusive,
                X = X
            };
        }
    }
}
