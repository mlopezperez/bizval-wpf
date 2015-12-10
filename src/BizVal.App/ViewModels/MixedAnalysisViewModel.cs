using System;
using BizVal.App.Events;
using BizVal.Framework;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class MixedAnalysisViewModel : PropertyChangedBase, IHandle<DataChangedEvent>, IHandle<MixedCalculationErrorEvent>, IHandle<HierarchyChangedEvent>
    {
        private readonly IEventAggregator eventAggregator;
        private string errorMessage;
        private const string ExpectedInterestInputName = "Expected Interests:";
        private const string ExpectedBenefitsInputName = "Expected Benefits:";

        public IntervalListViewModel ExpectedBenefits { get; set; }
        public IntervalListViewModel ExpectedInterests { get; set; }
        public float SubstantialValue { get; set; }

        public string ErrorMessage
        {
            get { return this.errorMessage; }
            set
            {
                this.errorMessage = value;
                this.NotifyOfPropertyChange(() => this.ErrorMessage);
            }
        }

        public MixedAnalysisViewModel(IntervalListViewModel expectedBenefits, IntervalListViewModel expectedInterests, IEventAggregator eventAggregator)
        {
            this.eventAggregator = Contract.NotNull(eventAggregator, "eventAggregator");
            this.ExpectedBenefits = Contract.NotNull(expectedBenefits, "expectedBenefits");
            this.ExpectedInterests = Contract.NotNull(expectedInterests, "expectedInterests");

            this.ExpectedInterests.InputName = ExpectedInterestInputName;
            this.ExpectedBenefits.InputName = ExpectedBenefitsInputName;

            this.eventAggregator.Subscribe(this);
        }

        public void Handle(DataChangedEvent message)
        {
            var mixedEvent = new MixedCalculationEvent()
            {
                Benefits = this.ExpectedBenefits.Values,
                Interests = this.ExpectedInterests.Values,
                SubstantialValue = Convert.ToDecimal(this.SubstantialValue),
            };

            this.ErrorMessage = string.Empty;
            this.eventAggregator.PublishOnUIThread(mixedEvent);
        }

        public void Handle(MixedCalculationErrorEvent message)
        {
            this.ErrorMessage = message.Error;
        }

        public void Handle(HierarchyChangedEvent message)
        {

        }
    }
}