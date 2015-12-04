using System.Collections.Generic;

namespace BizVal.Model
{
    public class Expertise
    {
        public Interval Interval { get; set; }
        public Dictionary<TwoTuple, int> LowerBoundCardinalities { get; set; }
        public Dictionary<TwoTuple, int> UpperBoundCardinalities { get; set; }
    }
}