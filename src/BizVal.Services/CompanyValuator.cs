using System.Collections.Generic;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services
{
    internal class CompanyValuator : ICompanyValuator
    {
        public Interval Cashflow(List<Interval> expectedCashflows, List<Interval> expectedWaccs)
        {
            Contract.NotNull(expectedCashflows, "expectedCashflows");
            Contract.NotNull(expectedWaccs, "expectedWaccs");
            if (expectedCashflows.Count != expectedWaccs.Count)
            {
                throw new ValuationException("Number of expected cashflow intervals mismatches number of expected WACCs intervals.");
            }
            return null;
        }
    }
}
