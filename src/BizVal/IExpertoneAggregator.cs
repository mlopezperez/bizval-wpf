using BizVal.Model;

namespace BizVal
{
    public interface IExpertoneAggregator
    { 
        /// <summary>
        /// Aggregates the linguistic information privided in the expertise using the expertone method.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <param name="hierarchy">The hierarchy for the labels in the expertise.</param>
        /// <param name="referenceLevel">The reference level where we shall standarize the expertise.</param>
        /// <returns>
        /// An adjusted interval aggregating the linguistic information provided in the expertise.
        /// </returns>
        Interval AggregateByExpertone(Expertise expertise, Hierarchy hierarchy, int referenceLevel);

    }
}