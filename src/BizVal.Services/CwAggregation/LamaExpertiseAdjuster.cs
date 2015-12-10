using System;
using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    internal sealed class LamaExpertiseAdjuster : ILamaExpertiseAdjuster
    {
        private readonly ILamaAggregator aggregator;

        public LamaExpertiseAdjuster(ILamaAggregator aggregator)
        {
            this.aggregator = Contract.NotNull(aggregator, "aggregator");
        }

        IList<Interval> ILamaExpertiseAdjuster.AdjustByLama(IList<Expertise> data, Hierarchy hierarchy)
        {
            var referenceLevel = hierarchy.LastOrDefault();
            if (referenceLevel == null)
            {
                throw new AggregateException("Hierarchy does not contains linguistic levels");
            }
            var adjustedData = new List<Interval>();
            foreach (var item in data)
            {
                var adjustedInterval = this.aggregator.AggregateByLama(item, hierarchy, referenceLevel.Count);
                adjustedData.Add(adjustedInterval);
            }
            return adjustedData;
        }
    }
}