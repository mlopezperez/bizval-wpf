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
                result = result + (expectedCashflows[i] / this.GetDivisor(expectedWaccs, i));

            }
            return result;
        }

        private Interval GetDivisor(IList<Interval> expectedWaccs, int i)
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
