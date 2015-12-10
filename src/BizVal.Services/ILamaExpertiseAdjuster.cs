using System.Collections.Generic;
using BizVal.Model;

namespace BizVal.Services
{
    internal interface ILamaExpertiseAdjuster
    {
        IList<Interval> AdjustByLama(IList<Expertise> data, Hierarchy hierarchy);
    }
}
