using System;
using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;

namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates an Expertone.
    /// </summary>
    /// <typeparam name="T">Type of the items in which we're applying the expertone.</typeparam>
    public class Expertone<T> where T : IComparable<T>
    {
        private readonly SortedList<T, ExpertoneItem> items;

        /// <summary>
        /// Gets or sets the interval where the expertone is applied.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public Interval Interval { get; set; }

        /// <summary>
        /// Gets the list of the values of the expertone for the lower bound.
        /// </summary>
        /// <value>
        /// The values of the expertone for the lower bound.
        /// </value>
        public List<decimal> LowerValues
        {
            get { return this.items.Values.Select(item => item.LowerBoundValue).ToList(); }
        }

        /// <summary>
        /// Gets the list of the values of the expertone for the upper bound.
        /// </summary>
        /// <value>
        /// The values of the expertone for the upper bound.
        /// </value>
        public List<decimal> UpperValues
        {
            get { return this.items.Values.Select(item => item.UpperBoundValue).ToList(); }
        }

        /// <summary>
        /// Gets the list of the values of the R-expertone for the lower bound.
        /// </summary>
        /// <value>
        /// The values of the R-expertone for the lower bound.
        /// </value>
        public List<decimal> LowerRValues
        {
            get
            {
                var returnValue = this.items.Values.Select(item => this.Interval.LowerBound + (this.Interval.Width * item.LowerBoundValue)).ToList();
                return returnValue;
            }
        }

        /// <summary>
        /// Gets the list of the values of the R-expertone for the upper bound.
        /// </summary>
        /// <value>
        /// The values of the R-expertone for the upper bound.
        /// </value>
        public List<decimal> UpperRValues
        {
            get
            {
                var returnValue = this.items.Values.Select(item => this.Interval.LowerBound + (this.Interval.Width * item.UpperBoundValue)).ToList();
                return returnValue;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expertone{T}"/> class.
        /// </summary>
        /// <param name="expertise">The expertise used to create the expertone.</param>
        public Expertone(CardinalityList<T> expertise)
        {
            Contract.NotNull(expertise, "expertise");
            this.items = new SortedList<T, ExpertoneItem>();
            this.Interval = expertise.Interval;
            this.ProcessExpertise(expertise);
        }

        private void ProcessExpertise(CardinalityList<T> expertise)
        {
            var totalCardinality = expertise.Cardinalities.Sum(c => c.Value.Lower);
            foreach (var item in expertise.Cardinalities)
            {
                decimal lowerBoundProbability = decimal.Divide(item.Value.Lower, totalCardinality);
                var lastLowerAccumulated = this.items.Values.LastOrDefault() == null ? 1 : this.items.Values.Last().LowerBoundValue;
                decimal lowerAccumulatedProbability = lastLowerAccumulated - lowerBoundProbability;

                decimal upperBoundProbability = decimal.Divide(item.Value.Upper, totalCardinality);
                var lastUpperAccumulated = this.items.Values.LastOrDefault() == null ? 1 : this.items.Values.Last().UpperBoundValue;
                decimal upperAccumulatedProbability = lastUpperAccumulated - upperBoundProbability;

                this.items.Add(item.Key, new ExpertoneItem(lowerAccumulatedProbability, upperAccumulatedProbability));
            }
        }

        /// <summary>
        /// Gets the expected value for the expertone.
        /// </summary>
        /// <returns>An interval containing the expected value of the expertone.</returns>
        public Interval GetExpectedValue()
        {
            var result = new Interval()
            {
                LowerBound = this.GetExpectedValue(this.LowerRValues),
                UpperBound = this.GetExpectedValue(this.UpperRValues)
            };
            return result;
        }

        private decimal GetExpectedValue(IList<decimal> expertoneItems)
        {
            var result = 0m;
            for (int i = 0; i < expertoneItems.Count; i++)
            {
                result = result + expertoneItems[i];
            }
            result = decimal.Divide(result, expertoneItems.Count - 1);
            return result;
        }
    }
}
