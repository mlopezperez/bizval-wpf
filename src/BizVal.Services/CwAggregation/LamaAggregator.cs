using System;
using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    /// <summary>
    /// Impementation of ILamaAggregator.
    /// </summary>
    /// <seealso cref="BizVal.ILamaAggregator" />
    internal sealed class LamaAggregator : ILamaAggregator
    {
        private readonly ILamaCalculator lamaCalculator;
        private readonly IExpertiseStandardizer standardizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LamaAggregator"/> class.
        /// </summary>
        /// <param name="standardizer">The standardizer.</param>
        /// <param name="lamaCalculator">The lama calculator.</param>
        public LamaAggregator(IExpertiseStandardizer standardizer, ILamaCalculator lamaCalculator)
        {
            this.lamaCalculator = Contract.NotNull(lamaCalculator, "lamaCalculator");
            this.standardizer = Contract.NotNull(standardizer, "standardizer");
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
        Interval ILamaAggregator.AggregateByLama(Expertise expertise, Hierarchy hierarchy, int referenceLevel)
        {
            Contract.NotNull(expertise, "expertise");
            Contract.NotNull(hierarchy, "hierarchy");
            var standardExpertise = this.standardizer.Standardize(expertise, hierarchy, referenceLevel);
            var cardinalities = new TwoTupleCardinalities(standardExpertise);

            Dictionary<TwoTuple, int> lowerCardinalities = cardinalities.Cardinalities.ToDictionary(k => k.Key, v => v.Value.Lower);
            Dictionary<TwoTuple, int> upperCardinalities = cardinalities.Cardinalities.ToDictionary(k => k.Key, v => v.Value.Upper);
            var aggregatedLowerTuple = this.lamaCalculator.LinguisticLama(lowerCardinalities, hierarchy[referenceLevel]);
            var aggregatedUpperTuple = this.lamaCalculator.LinguisticLama(upperCardinalities, hierarchy[referenceLevel]);

            var resultingInterval = this.AdjustInterval(expertise.Interval, aggregatedLowerTuple, aggregatedUpperTuple);

            return resultingInterval;
        }

        private Interval AdjustInterval(Interval interval, TwoTuple aggregatedLowerTuple, TwoTuple aggregatedUpperTuple)
        {
            var lowerTupleFactor = this.GetFactor(aggregatedLowerTuple);
            var upperTupleFactor = this.GetFactor(aggregatedUpperTuple);

            Interval adjustedInterval = lowerTupleFactor < upperTupleFactor ?
                new Interval(lowerTupleFactor, upperTupleFactor) :
                new Interval(upperTupleFactor, lowerTupleFactor);

            var result = interval.LowerBound + (interval.Width * adjustedInterval);
            return result;
        }

        private decimal GetFactor(TwoTuple tuple)
        {
            var set = tuple.Label.LabelSet;
            var beta = set.DeltaInv(tuple);
            decimal k = 1m;
            if (beta < set.G)
            {
                int h = (int)Math.Truncate(beta);
                var sigma = beta - h;
                var membershipTuple1 = new TwoTuple(set[h], 1 - sigma);
                var membershipTuple2 = new TwoTuple(set[h + 1], sigma);
                k = (membershipTuple1.Label.M * membershipTuple1.Alpha) +
                        (membershipTuple2.Label.M * membershipTuple2.Alpha);
            }
            return k;
        }
    }
}