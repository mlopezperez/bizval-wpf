using BizVal.Framework;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class MixedAnalysisViewModel : PropertyChangedBase
    {
        private const string ExpectedInterestInputName = "Expected interests:";
        private const string ExpectedBenefitsInputName = "Expected interests:";

        public IntervalListViewModel ExpectedBenefits { get; set; }
        public IntervalListViewModel ExpectedInterests { get; set; }
        public float SubstantialValue { get; set; }

        public MixedAnalysisViewModel(IntervalListViewModel expectedBenefits, IntervalListViewModel expectedInterests)
        {
            this.ExpectedBenefits = Contract.NotNull(expectedBenefits, "expectedBenefits");
            this.ExpectedInterests = Contract.NotNull(expectedInterests, "expectedInterests");

            this.ExpectedInterests.InputName = ExpectedInterestInputName;
            this.ExpectedBenefits.InputName = ExpectedBenefitsInputName;
        }
    }
}