﻿using System.Collections.Generic;
using BizVal.Model;

namespace BizVal
{
    public interface ICompanyValuator
    {
        Interval Cashflow(IList<Interval> expectedCashflows, IList<Interval> expectedWaccs);
        Interval MixedAnalysis(float substantialValue, IList<Interval> expectedBenefits, IList<Interval> expectedInterests);
    }
}
