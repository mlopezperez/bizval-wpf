using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    /// <summary>
    /// Impementation of IExpertoneAggregator.
    /// </summary>
    /// <seealso cref="BizVal.IExpertoneAggregator" />
    internal sealed class ExpertoneAggregator : IExpertoneAggregator
    {
        private readonly IExpertiseStandardizer standardizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LamaAggregator" /> class.
        /// </summary>
        /// <param name="standardizer">The standardizer.</param>
        public ExpertoneAggregator(IExpertiseStandardizer standardizer)
        {
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
        Interval IExpertoneAggregator.AggregateByExpertone(Expertise expertise, Hierarchy hierarchy, int referenceLevel)
        {
            Contract.NotNull(expertise, "expertise");
            Contract.NotNull(hierarchy, "hierarchy");

            var standardExpertise = this.standardizer.Standardize(expertise, hierarchy, referenceLevel);
            TwoTupleCardinalities cardinalities = new TwoTupleCardinalities(standardExpertise);

            var expertone = new Expertone<TwoTuple>(cardinalities);
            var expectedInterval = expertone.GetExpectedValue();
            return expectedInterval;
        }

      
    }
}