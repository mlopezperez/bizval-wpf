using System;
using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BizVal.ICwCompanyValuator" />
    internal sealed class CwCompanyValuator : ICwCompanyValuator
    {
        private readonly ICompanyValuator companyValuator;
        private readonly IAggregator aggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CwCompanyValuator"/> class.
        /// </summary>
        /// <param name="companyValuator">The company valuator.</param>
        /// <param name="aggregator">The aggregator.</param>
        public CwCompanyValuator(ICompanyValuator companyValuator, IAggregator aggregator)
        {
            this.companyValuator = Contract.NotNull(companyValuator, "companyValuator");
            this.aggregator = Contract.NotNull(aggregator, "aggregator");
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
        public Interval CashflowWithExpertones(IList<LinguisticExpertise> cashflows, IList<LinguisticExpertise> waccs, Hierarchy linguisticHierarchy)
        {
            Contract.NotNull(cashflows, "cashflows");
            Contract.NotNull(waccs, "waccs");
            Contract.NotNull(linguisticHierarchy, "linguisticHierarchy");

            IList<Interval> adjustedCashflows = this.AdjustByExpertones(cashflows, linguisticHierarchy);
            IList<Interval> adjustedWaccs = this.AdjustByExpertones(waccs, linguisticHierarchy);
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
        public Interval CashflowWithLama(IList<LinguisticExpertise> cashflows, IList<LinguisticExpertise> waccs, Hierarchy linguisticHierarchy)
        {
            Contract.NotNull(cashflows, "cashflows");
            Contract.NotNull(waccs, "waccs");
            Contract.NotNull(linguisticHierarchy, "linguisticHierarchy");

            IList<Interval> adjustedCashflows = this.AdjustByLama(cashflows, linguisticHierarchy);
            IList<Interval> adjustedWaccs = this.AdjustByLama(waccs, linguisticHierarchy);
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
        public Interval MixedWithWithExpertones(decimal substantialValue, IList<LinguisticExpertise> benefits, IList<LinguisticExpertise> interests,
            Hierarchy linguisticHierarchy)
        {
            Contract.NotNull(benefits, "benefits");
            Contract.NotNull(interests, "interests");
            Contract.NotNull(linguisticHierarchy, "linguisticHierarchy");

            IList<Interval> adjustedBenefits = this.AdjustByExpertones(benefits, linguisticHierarchy);
            IList<Interval> adjustedInterests = this.AdjustByExpertones(interests, linguisticHierarchy);
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
        public Interval MixedWithWithLama(decimal substantialValue, IList<LinguisticExpertise> benefits, IList<LinguisticExpertise> interests, Hierarchy linguisticHierarchy)
        {
            Contract.NotNull(benefits, "benefits");
            Contract.NotNull(interests, "interests");
            Contract.NotNull(linguisticHierarchy, "linguisticHierarchy");

            IList<Interval> adjustedBenefits = this.AdjustByLama(benefits, linguisticHierarchy);
            IList<Interval> adjustedInterests = this.AdjustByLama(interests, linguisticHierarchy);
            var result = this.companyValuator.MixedAnalysis(substantialValue, adjustedBenefits, adjustedInterests);
            return result;
        }

        private IList<Interval> AdjustByExpertones(IList<LinguisticExpertise> data, Hierarchy hierarchy)
        {
            var referenceLevel = hierarchy.LastOrDefault();
            if (referenceLevel == null)
            {
                throw new AggregateException("Hierarchy does not contains linguistic levels");
            }
            var adjustedData = new List<Interval>();
            foreach (var item in data)
            {
                var adjustedInterval = this.aggregator.AggregateByExpertone(item, hierarchy, referenceLevel.Count);
                adjustedData.Add(adjustedInterval);
            }
            return adjustedData;
        }

        private IList<Interval> AdjustByLama(IList<LinguisticExpertise> data, Hierarchy hierarchy)
        {
            var referenceLevel = hierarchy.LastOrDefault();
            if (referenceLevel == null)
            {
                throw new AggregateException("Hierarchy does not contains linguistic levels");
            }
            var adjustedData = new List<Interval>();
            foreach (var item in data)
            {
                var adjustedInterval = this.aggregator.AggregateByLama(item, hierarchy, referenceLevel.Count);
                adjustedData.Add(adjustedInterval);
            }
            return adjustedData;
        }
    }
}