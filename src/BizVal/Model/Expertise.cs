﻿using System;
using System.Collections.Generic;

namespace BizVal.Model
{
    public class Expertise<T> where T : IComparable<T>
    {
        /// <summary>
        /// Gets or sets the interval on which we apply the expertise.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public Interval Interval { get; set; }

        /// <summary>
        /// Gets or sets the cardinalities of each opinion.
        /// </summary>
        /// <value>
        /// The cardinalities.
        /// </value>
        public SortedDictionary<T, Cardinality> Cardinalities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expertise{T}"/> class.
        /// </summary>
        /// <param name="interval">The interval.</param>
        public Expertise(Interval interval)
        {
            this.Cardinalities = new SortedDictionary<T, Cardinality>();
            this.Interval = interval;
        }
    }
}
