using BizVal.Model;

namespace BizVal.Services
{
    /// <summary>
    /// Interface defining methods to standardize an expertise to a given label set.
    /// </summary>
    internal interface IExpertiseStandardizer
    {
        /// <summary>
        /// Standardizes the specified expertise.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <param name="hierarchy"></param>
        /// <param name="level"></param>
        /// <returns>A standarized expertise.</returns>
        Expertise Standardize(Expertise expertise, Hierarchy hierarchy, int level);
    }
}
