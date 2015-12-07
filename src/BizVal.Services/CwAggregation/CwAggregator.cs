using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    /// <summary>
    /// Impementation of IAggregator.
    /// </summary>
    /// <seealso cref="BizVal.IAggregator" />
    internal sealed class CwAggregator : IAggregator
    {
        private readonly ILamaCalculator lamaCalculator;
        private readonly IExpertiseStandardizer standardizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CwAggregator"/> class.
        /// </summary>
        /// <param name="standardizer">The standardizer.</param>
        /// <param name="lamaCalculator">The lama calculator.</param>
        public CwAggregator(IExpertiseStandardizer standardizer, ILamaCalculator lamaCalculator)
        {
            this.lamaCalculator = Contract.NotNull(lamaCalculator, "lamaCalculator");
            this.standardizer = Contract.NotNull(standardizer, "standardizer");
        }

        /// <summary>
        /// Aggregates the linguistic information privided in the expertise using the expertone method.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <param name="hierarchy">The hierarchy for the labels in the expertise.</param>
        /// <param name="referenceLevel">The reference level where we shall standarize the expertise.</param>
        /// <returns>
        /// An adjusted interval aggregating the linguistic information provided in the expertise.
        /// </returns>
        Interval IAggregator.AggregateByExpertone(LinguisticExpertise expertise, Hierarchy hierarchy, int referenceLevel)
        {
            Contract.NotNull(expertise, "expertise");
            Contract.NotNull(hierarchy, "hierarchy");

            var standardExpertise = this.standardizer.Standardize(expertise, hierarchy, referenceLevel);
            var expertone = new Expertone<TwoTuple>(standardExpertise);
            var expectedInterval = expertone.GetExpectedValue();
            return expectedInterval;
        }

        /// <summary>
        /// Aggregates the linguistic information privided in the expertise using the LAMA operator.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <param name="hierarchy">The hierarchy for the labels in the expertise.</param>
        /// <param name="referenceLevel">The reference level where we shall standarize the expertise.</param>
        /// <returns>
        /// An adjusted interval aggregating the linguistic information provided in the expertise.
        /// </returns>
        Interval IAggregator.AggregateByLama(LinguisticExpertise expertise, Hierarchy hierarchy, int referenceLevel)
        {
            Contract.NotNull(expertise, "expertise");
            Contract.NotNull(hierarchy, "hierarchy");
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
            var adjustedInterval = new Interval(1, 1);
            var result = interval.LowerBound + (interval.Width * adjustedInterval);
            return result;
        }
    }
}