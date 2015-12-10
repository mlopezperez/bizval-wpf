using System.Collections.Generic;
using BizVal.Model;

namespace BizVal
{
    /// <summary>
    /// Interface defining methods to valuate companies using linguistic information.
    /// </summary>
    public interface ICwCompanyValuator
    {
        /// <summary>
        /// Valuates a company using the discounted cashflow method,
        /// aggregating the linguistic information provided using the Expertones method.
        /// </summary>
        /// <param name="cashflows">The cashflows.</param>
        /// <param name="waccs">The waccs.</param>
        /// <param name="linguisticHierarchy">The linguistic hierarchy.</param>
        /// <returns>An interval containing the probable value of the company.</returns>
        Interval CashflowWithExpertones(
            IList<Expertise> cashflows,
            IList<Expertise> waccs,
            Hierarchy linguisticHierarchy);

        /// <summary>
        /// Valuates a company using the discounted cashflow method,
        /// aggregating the linguistic information provided using the LAMA operator.
        /// </summary>
        /// <param name="cashflows">The cashflows.</param>
        /// <param name="waccs">The waccs.</param>
        /// <param name="linguisticHierarchy">The linguistic hierarchy.</param>
        /// <returns>An interval containing the probable value of the company.</returns>
        Interval CashflowWithLama(
            IList<Expertise> cashflows,
            IList<Expertise> waccs,
            Hierarchy linguisticHierarchy);

        /// <summary>
        /// Valuates a company using the mixed analysis method,
        /// aggregating the linguistic information provided using the Expertones method.
        /// </summary>
        /// <param name="substantialValue">The substantial value.</param>
        /// <param name="benefits">The benefits.</param>
        /// <param name="interests">The interests.</param>
        /// <param name="linguisticHierarchy">The linguistic hierarchy.</param>
        /// <returns>An interval containing the probable value of the company.</returns>
        Interval MixedWithWithExpertones(
            decimal substantialValue,
            IList<Expertise> benefits,
            IList<Expertise> interests,
            Hierarchy linguisticHierarchy);

        /// <summary>
        /// Valuates a company using the mixed analysis method,
        /// aggregating the linguistic information provided using the LAMA operator.
        /// </summary>
        /// <param name="substantialValue">The substantial value.</param>
        /// <param name="benefits">The benefits.</param>
        /// <param name="interests">The interests.</param>
        /// <param name="linguisticHierarchy">The linguistic hierarchy.</param>
        /// <returns>An interval containing the probable value of the company.</returns>
        Interval MixedWithWithLama(
            decimal substantialValue,
            IList<Expertise> benefits,
            IList<Expertise> interests,
            Hierarchy linguisticHierarchy);
    }
}
