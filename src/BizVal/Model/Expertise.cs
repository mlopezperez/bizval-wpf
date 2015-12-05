using System;
using System.Collections.Generic;

namespace BizVal.Model
{
    public class Expertise<T> where T : IComparable<T>
    {
        public Interval Interval { get; set; }
        public Dictionary<T, Cardinality> Cardinalities { get; set; }

        public Expertise(Interval interval)
        {
            this.Cardinalities = new Dictionary<T, Cardinality>();
            this.Interval = interval;
        }
    }
}
