using System;
using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;

namespace BizVal.Model
{
    public class Expertone<T> where T : IComparable<T>
    {
        private readonly SortedList<T, ExpertoneItem> items;

        public Interval Interval { get; set; }

        public List<decimal> LowerItems
        {
            get { return this.items.Values.Select(item => item.LowerItem).ToList(); }
        }

        public List<decimal> UpperItems
        {
            get { return this.items.Values.Select(item => item.UpperItem).ToList(); }
        }

        public Expertone(Expertise<T> expertise)
        {
            Contract.NotNull(expertise, "expertise");
            this.items = new SortedList<T, ExpertoneItem>();
            this.Interval = expertise.Interval;
            this.ProcessExpertise(expertise);
        }

        private void ProcessExpertise(Expertise<T> expertise)
        {
            var totalCardinality = expertise.Cardinalities.Sum(c => c.Value.Lower);
            foreach (var item in expertise.Cardinalities)
            {
                decimal lowerBoundProbability = decimal.Divide(item.Value.Lower, totalCardinality);
                var lastLowerAccumulated = this.items.Values.LastOrDefault() == null ? 1 : this.items.Values.Last().LowerItem;
                decimal lowerAccumulatedProbability = lastLowerAccumulated - lowerBoundProbability;

                decimal upperBoundProbability = decimal.Divide(item.Value.Upper, totalCardinality);
                var lastUpperAccumulated = this.items.Values.LastOrDefault() == null ? 1 : this.items.Values.Last().UpperItem;
                decimal upperAccumulatedProbability = lastUpperAccumulated - upperBoundProbability;

                this.items.Add(item.Key, new ExpertoneItem(lowerAccumulatedProbability, upperAccumulatedProbability));
            }
        }

        public Interval GetExpectedValue()
        {
            var result = new Interval()
            {
                LowerBound = this.GetExpectedValue(this.LowerItems),
                UpperBound = this.GetExpectedValue(this.UpperItems)
            };
            return result;
        }

        private decimal GetExpectedValue(IList<decimal> expertoneItems)
        {
            var result = 0m;
            for (int i = 1; i < expertoneItems.Count; i++)
            {
                result = result + expertoneItems[i];
            }
            result = decimal.Divide(result, expertoneItems.Count);
            return result;
        }
    }
}
