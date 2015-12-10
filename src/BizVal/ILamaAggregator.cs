using BizVal.Model;

namespace BizVal
{
    /// <summary>
    /// Interface defining methods to aggregate linguistic information.
    /// </summary>
    public interface ILamaAggregator
    {
        /// <summary>
        /// Aggregates the linguistic information privided in the expertise using the LAMA operator.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <param name="hierarchy">The hierarchy for the labels in the expertise.</param>
        /// <param name="referenceLevel">The reference level where we shall standarize the expertise.</param>
        /// <returns>
        /// An adjusted interval aggregating the linguistic information provided in the expertise.
        /// </returns>
        Interval AggregateByLama(Expertise expertise, Hierarchy hierarchy, int referenceLevel);
    }
}
