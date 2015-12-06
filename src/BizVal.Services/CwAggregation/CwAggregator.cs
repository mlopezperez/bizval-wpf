using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    internal class CwAggregator : ICwAggregator
    {
        private readonly ILamaCalculator lamaCalculator;
        private readonly IExpertiseStandardizer standardizer;

        public CwAggregator(IExpertiseStandardizer standardizer, ILamaCalculator lamaCalculator)
        {
            this.lamaCalculator = Contract.NotNull(lamaCalculator, "lamaCalculator");
            this.standardizer = Contract.NotNull(standardizer, "standardizer");
        }

        Interval ICwAggregator.AggregateByExpertone(LinguisticExpertise expertise, Hierarchy hierarchy, int referenceLevel)
        {
            var standardExpertise = this.standardizer.Standardize(expertise, hierarchy, referenceLevel);
            var expertone = new Expertone<TwoTuple>(standardExpertise);
            var expectedInterval = expertone.GetExpectedValue();
            return expectedInterval;
        }

        public Interval AggregateByLama(LinguisticExpertise expertise, Hierarchy hierarchy, int referenceLevel)
        {
            var standardExpertise = this.standardizer.Standardize(expertise, hierarchy, referenceLevel);

            Dictionary<TwoTuple, int> lowerCardinalities = standardExpertise.Cardinalities.ToDictionary(k => k.Key, v => v.Value.Lower);
            Dictionary<TwoTuple, int> upperCardinalities = standardExpertise.Cardinalities.ToDictionary(k => k.Key, v => v.Value.Upper);
            var aggregatedLowerTuple = this.lamaCalculator.LinguisticLama(lowerCardinalities, hierarchy[referenceLevel]);
            var aggregatedUpperTuple = this.lamaCalculator.LinguisticLama(upperCardinalities, hierarchy[referenceLevel]);

            var resultingInterval = this.AdjustInterval(expertise.Interval, aggregatedLowerTuple, aggregatedUpperTuple);

            return resultingInterval;
        }

        private Interval AdjustInterval(Interval interval, TwoTuple aggregatedLowerTuple, TwoTuple aggregatedUpperTuple)
        {
            return interval;
        }
    }
}