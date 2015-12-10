using System;
using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services
{
    /// <summary>
    /// Implementation of ICwCompanyValuator.
    /// </summary>
    /// <seealso cref="BizVal.ICwCompanyValuator" />
    internal sealed class CwCompanyValuator : ICwCompanyValuator
    {
        private readonly IExpertoneExpertiseAdjuster expertoneExpertiseAdjuster;
        private readonly ILamaExpertiseAdjuster lamaExpertiseAdjuster;
        private readonly ICompanyValuator companyValuator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CwCompanyValuator"/> class.
        /// </summary>
        /// <param name="companyValuator">The company valuator.</param>
        /// <param name="lamaExpertiseAdjuster"></param>
        /// <param name="expertoneExpertiseAdjuster"></param>
        public CwCompanyValuator(ICompanyValuator companyValuator, ILamaExpertiseAdjuster lamaExpertiseAdjuster, IExpertoneExpertiseAdjuster expertoneExpertiseAdjuster)
        {
            this.expertoneExpertiseAdjuster = Contract.NotNull(expertoneExpertiseAdjuster, "expertoneExpertiseAdjuster");
            this.lamaExpertiseAdjuster = Contract.NotNull(lamaExpertiseAdjuster, "lamaExpertiseAdjuster");
            this.companyValuator = Contract.NotNull(companyValuator, "companyValuator");
        }

        /// <summary>
        /// Valuates a company using the discounted cashflow method,
        /// aggregating the linguistic information provided using the Expertones method.
        /// </summary>
        /// <param name="cashflows">The cashflows.</param>
        /// <param name="waccs">The waccs.</param>
        /// <param name="linguisticHierarchy">The linguistic hierarchy.</param>
        /// <returns>
        /// An interval containing the probable value of the company.
        /// </returns>
        public Interval CashflowWithExpertones(IList<Expertise> cashflows, IList<Expertise> waccs, Hierarchy linguisticHierarchy)
        {
            Contract.NotNull(cashflows, "cashflows");
            Contract.NotNull(waccs, "waccs");
            Contract.NotNull(linguisticHierarchy, "linguisticHierarchy");

            IList<Interval> adjustedCashflows = this.expertoneExpertiseAdjuster.AdjustByExpertones(cashflows, linguisticHierarchy);
            IList<Interval> adjustedWaccs = this.expertoneExpertiseAdjuster.AdjustByExpertones(waccs, linguisticHierarchy);
            var result = this.companyValuator.Cashflow(adjustedCashflows, adjustedWaccs);
            return result;
        }

        /// <summary>
        /// Valuates a company using the discounted cashflow method,
        /// aggregating the linguistic information provided using the LAMA operator.
        /// </summary>
        /// <param name="cashflows">The cashflows.</param>
        /// <param name="waccs">The waccs.</param>
        /// <param name="linguisticHierarchy">The linguistic hierarchy.</param>
        /// <returns>
        /// An interval containing the probable value of the company.
        /// </returns>
        public Interval CashflowWithLama(IList<Expertise> cashflows, IList<Expertise> waccs, Hierarchy linguisticHierarchy)
        {
            Contract.NotNull(cashflows, "cashflows");
            Contract.NotNull(waccs, "waccs");
            Contract.NotNull(linguisticHierarchy, "linguisticHierarchy");

            IList<Interval> adjustedCashflows = this.lamaExpertiseAdjuster.AdjustByLama(cashflows, linguisticHierarchy) ;
            IList<Interval> adjustedWaccs = this.lamaExpertiseAdjuster.AdjustByLama(waccs, linguisticHierarchy);
            var result = this.companyValuator.Cashflow(adjustedCashflows, adjustedWaccs);
            return result;
        }

        /// <summary>
        /// Valuates a company using the mixed analysis method,
        /// aggregating the linguistic information provided using the Expertones method.
        /// </summary>
        /// <param name="substantialValue">The substantial value.</param>
        /// <param name="benefits">The benefits.</param>
        /// <param name="interests">The interests.</param>
        /// <param name="linguisticHierarchy">The linguistic hierarchy.</param>
        /// <returns>
        /// An interval containing the probable value of the company.
        /// </returns>
        public Interval MixedWithWithExpertones(decimal substantialValue, IList<Expertise> benefits, IList<Expertise> interests,
            Hierarchy linguisticHierarchy)
        {
            Contract.NotNull(benefits, "benefits");
            Contract.NotNull(interests, "interests");
            Contract.NotNull(linguisticHierarchy, "linguisticHierarchy");

            IList<Interval> adjustedBenefits = this.expertoneExpertiseAdjuster.AdjustByExpertones(benefits, linguisticHierarchy);
            IList<Interval> adjustedInterests = this.expertoneExpertiseAdjuster.AdjustByExpertones(interests, linguisticHierarchy);
            var result = this.companyValuator.MixedAnalysis(substantialValue, adjustedBenefits, adjustedInterests);
            return result;
        }

        /// <summary>
        /// Valuates a company using the mixed analysis method,
        /// aggregating the linguistic information provided using the LAMA operator.
        /// </summary>
        /// <param name="substantialValue">The substantial value.</param>
        /// <param name="benefits">The benefits.</param>
        /// <param name="interests">The interests.</param>
        /// <param name="linguisticHierarchy">The linguistic hierarchy.</param>
        /// <returns>
        /// An interval containing the probable value of the company.
        /// </returns>
        public Interval MixedWithWithLama(decimal substantialValue, IList<Expertise> benefits, IList<Expertise> interests, Hierarchy linguisticHierarchy)
        {
            Contract.NotNull(benefits, "benefits");
            Contract.NotNull(interests, "interests");
            Contract.NotNull(linguisticHierarchy, "linguisticHierarchy");

            IList<Interval> adjustedBenefits = this.lamaExpertiseAdjuster.AdjustByLama(benefits, linguisticHierarchy);
            IList<Interval> adjustedInterests = this.lamaExpertiseAdjuster.AdjustByLama(interests, linguisticHierarchy);
            var result = this.companyValuator.MixedAnalysis(substantialValue, adjustedBenefits, adjustedInterests);
            return result;
        }
    }
}