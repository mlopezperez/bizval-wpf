using System.Collections.Generic;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services
{
    internal class CompanyValuator : ICompanyValuator
    {
        Interval ICompanyValuator.Cashflow(IList<Interval> expectedCashflows, IList<Interval> expectedWaccs)
        {
            Contract.NotNull(expectedCashflows, "expectedCashflows");
            Contract.NotNull(expectedWaccs, "expectedWaccs");
            if (expectedCashflows.Count != expectedWaccs.Count)
            {
                throw new ValuationException("Number of expected cashflow intervals mismatches number of expected WACCs intervals.");
            }

            Interval result = new Interval();
            for (int i = 0; i < expectedWaccs.Count; i++)
            {
                result = result + (expectedCashflows[i] / this.GetCashflowDivisor(expectedWaccs, i));

            }
            return result;
        }

        public Interval MixedAnalysis(float substantialValue, IList<Interval> expectedBenefits, IList<Interval> expectedInterests)
        {
            Contract.NotNull(expectedBenefits, "expectedBenefits;");
            Contract.NotNull(expectedInterests, "expectedInterests");
            if (expectedBenefits.Count != expectedInterests.Count)
            {
                throw new ValuationException("Number of expected benefits intervals is different than number of expected interest intervals");
            }

            var adjustedBenefits = this.GetAdjustedBenefits(expectedBenefits, expectedInterests);
            var adjustedInterests = this.GetAdjustedInterests(expectedInterests);

            var result = (substantialValue + adjustedBenefits) / (1 + adjustedInterests);
            return result;
        }

        private Interval GetAdjustedInterests(IList<Interval> expectedInterests)
        {
            Interval result = new Interval(0, 0);
            for (int i = 0; i < expectedInterests.Count; i++)
            {
                result = result + (expectedInterests[i] * this.GetISubN(expectedInterests, i));
            }

            return result;
        }

        private Interval GetAdjustedBenefits(IList<Interval> expectedBenefits, IList<Interval> expectedInterests)
        {
            Interval result = new Interval(0, 0);
            for (int i = 0; i < expectedBenefits.Count; i++)
            {
                result = result + (expectedBenefits[i] * this.GetISubN(expectedInterests, i));
            }

            return result;
        }

        private Interval GetISubN(IList<Interval> expectedInterests, int n)
        {
            var result = new Interval(1, 1);
            for (int i = 0; i <= n; i++)
            {
                result = result * (1 / (1 + expectedInterests[i]));
            }

            return result;
        }



        private Interval GetCashflowDivisor(IList<Interval> expectedWaccs, int i)
        {
            Interval result = new Interval(1, 1);
            for (int j = 0; j <= i; j++)
            {
                result = result * (1 + expectedWaccs[j]);
            }
            return result;
        }
    }
}
