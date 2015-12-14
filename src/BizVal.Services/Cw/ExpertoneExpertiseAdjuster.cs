using System;
using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.Cw
{
    internal sealed class ExpertoneExpertiseAdjuster : IExpertoneExpertiseAdjuster
    {
        private readonly IExpertoneAggregator expertoneAggregator;

        public ExpertoneExpertiseAdjuster(IExpertoneAggregator expertoneAggregator)
        {
            this.expertoneAggregator = Contract.NotNull(expertoneAggregator, "expertoneAggregator");
        }

        IList<Interval> IExpertoneExpertiseAdjuster.AdjustByExpertones(IList<Expertise> data, Hierarchy hierarchy)
        {
            var referenceLevel = hierarchy.LastOrDefault();
            if (referenceLevel == null)
            {
                throw new AggregateException("Hierarchy does not contains linguistic levels");
            }
            var adjustedData = new List<Interval>();
            foreach (var item in data)
            {
                var adjustedInterval = this.expertoneAggregator.AggregateByExpertone(item, hierarchy, referenceLevel.Count);
                adjustedData.Add(adjustedInterval);
            }
            return adjustedData;
        }
    }
}