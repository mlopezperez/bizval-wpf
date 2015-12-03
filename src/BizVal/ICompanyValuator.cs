using System.Collections.Generic;
using BizVal.Model;

namespace BizVal
{
    public interface ICompanyValuator
    {
        Interval Cashflow(IList<Interval> expectedCashflows, IList<Interval> expectedWaccs);
    }
}
