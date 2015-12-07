using System.Collections.Generic;
using BizVal.Model;

namespace BizVal
{
    /// <summary>
    /// Interface defining methods to valuate companies.
    /// </summary>
    public interface ICompanyValuator
    {
        /// <summary>
        /// Calcualates a company value using the discounted cashflow method.
        /// </summary>
        /// <param name="expectedCashflows">The expected cashflows.</param>
        /// <param name="expectedWaccs">The expected waccs.</param>
        /// <returns>An interval with the possible value of the company.</returns>
        Interval Cashflow(IList<Interval> expectedCashflows, IList<Interval> expectedWaccs);

        /// <summary>
        /// Calcualates a company value using the mixed analysis method.
        /// </summary>
        /// <param name="substantialValue">The substantial value.</param>
        /// <param name="expectedBenefits">The expected benefits.</param>
        /// <param name="expectedInterests">The expected interests.</param>
        /// <returns>An interval with the possible value of the company.</returns>
        Interval MixedAnalysis(decimal substantialValue, IList<Interval> expectedBenefits, IList<Interval> expectedInterests);
    }
}
