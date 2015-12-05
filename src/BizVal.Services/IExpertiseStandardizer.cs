using BizVal.Model;

namespace BizVal.Services
{
    interface IExpertiseStandardizer
    {
        /// <summary>
        /// Standardizes the specified expertise.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        /// <returns>A standarized expertise.</returns>
        LinguisticExpertise Standardize(LinguisticExpertise expertise);
    }
}
