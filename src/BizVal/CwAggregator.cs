using BizVal.Model;

namespace BizVal
{
    internal class CwAggregator : ICwAggregator
    {
        /// <summary>
        /// Aggregates the linguistic information privided in the expertise using the expertone method.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <returns>
        /// An adjusted interval aggregating the linguistic information provided in the expertise.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Interval ICwAggregator.AggregateByExpertone(LinguisticExpertise expertise)
        {
            throw new System.NotImplementedException();
        }
    }
}