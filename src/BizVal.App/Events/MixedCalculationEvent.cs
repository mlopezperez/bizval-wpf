using System.Collections.Generic;
using BizVal.App.Model;

namespace BizVal.App.Events
{
    public class MixedCalculationEvent
    {
        public decimal SubstantialValue { get; set; }
        public IList<BindableExpertise> Benefits { get; set; }
        public IList<BindableExpertise> Interests { get; set; }
    }
}