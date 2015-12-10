using System.Collections.Generic;
using BizVal.Model;

namespace BizVal.Services
{
    internal interface IExpertoneExpertiseAdjuster
    {
        IList<Interval> AdjustByExpertones(IList<Expertise> data, Hierarchy hierarchy);
    }
}