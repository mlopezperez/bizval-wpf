using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    /// <summary>
    /// Implementation of a standardizer for linguistic expertise.
    /// </summary>
    /// <seealso cref="BizVal.Services.IExpertiseStandardizer" />
    internal sealed class ExpertiseStandardizer : IExpertiseStandardizer
    {
        /// <summary>
        /// Standardizes the specified expertise.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <param name="hierarchy"></param>
        /// <param name="level"></param>
        /// <returns>A standarized expertise.</returns>
        LinguisticExpertise IExpertiseStandardizer.Standardize(LinguisticExpertise expertise, Hierarchy hierarchy, int level)
        {
            Contract.NotNull(expertise, "expertise");
            Contract.NotNull(hierarchy, "hierarchy");

            var result = new LinguisticExpertise(expertise.Interval);
            foreach (var item in expertise.Cardinalities)
            {
                var standarTuple = hierarchy.Translate(item.Key, level);
                result.Cardinalities.Add(standarTuple, item.Value);
            }
            return result;
        }
    }
}