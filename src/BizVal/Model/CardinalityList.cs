using System;
using System.Collections.Generic;
using System.Linq;

namespace BizVal.Model
{
    public class CardinalityList<T> where T : IComparable<T>
    {
        /// <summary>
        /// Gets or sets the interval on which we apply the expertise.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public Interval Interval { get; set; }

        /// <summary>
        /// Gets the current number of opinions.
        /// </summary>
        /// <value>
        /// The number of opinions.
        /// </value>
        public int NumberOfOpinions
        {
            get { return this.Cardinalities.Sum(i => i.Value.Lower); }
        }

        /// <summary>
        /// Gets or sets the cardinalities of each opinion.
        /// </summary>
        /// <value>
        /// The cardinalities.
        /// </value>
        public SortedDictionary<T, Cardinality> Cardinalities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cardinalities{T}"/> class.
        /// </summary>
        /// <param name="interval">The interval.</param>
        public CardinalityList(Interval interval)
        {
            this.Cardinalities = new SortedDictionary<T, Cardinality>();
            this.Interval = interval;
        }
    }
}
