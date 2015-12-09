using System.Collections.Generic;
using BizVal.App.Model;

namespace BizVal.App.Events
{
    public sealed class CashflowCalculationEvent
    {
        public IList<BindableExpertise> Cashflows { get; set; }
        public IList<BindableExpertise> Waccs { get; set; } 
    }
}
