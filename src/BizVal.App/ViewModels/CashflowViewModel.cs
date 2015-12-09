using System;
using BizVal.App.Events;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class CashflowViewModel : Screen, IHandle<DataChangedEvent>, IHandle<CashflowCalculationErrorEvent>
    {
        private readonly IEventAggregator eventAggregator;
        private string errorMessage;
        private const string CashflowDataName = "Expected Cashflow:";
        private const string WaccDataName = "Expected Wacc:";

        public IntervalListViewModel CashflowData { get; set; }
        public IntervalListViewModel WaccData { get; set; }

        public string ErrorMessage
        {
            get { return this.errorMessage; }
            set { this.errorMessage = value; this.NotifyOfPropertyChange(() => this.ErrorMessage); }
        }

        public CashflowViewModel(IntervalListViewModel cashflowData, IntervalListViewModel waccData, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.CashflowData = cashflowData;
            this.WaccData = waccData;

            this.CashflowData.InputName = CashflowDataName;
            this.WaccData.InputName = WaccDataName;
        }

        public void Handle(DataChangedEvent message)
        {
            var cashflowEvent = new CashflowCalculationEvent()
            {
                Cashflows = this.CashflowData.Values,
                Waccs = this.WaccData.Values,
            };

            this.ErrorMessage = string.Empty;
            this.eventAggregator.PublishOnUIThread(cashflowEvent);
        }

        protected override void OnActivate()
        {
            this.eventAggregator.Subscribe(this);
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            this.eventAggregator.Unsubscribe(this);
            base.OnDeactivate(close);
        }

        public void Handle(CashflowCalculationErrorEvent message)
        {
            this.ErrorMessage = message.Error;
        }
    }
}