using System;
using BizVal.App.Events;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class CashflowViewModel : Screen, IHandle<DataChangedEvent>, IHandle<CashflowCalculationErrorEvent>, IHandle<HierarchyChangedEvent>
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

            this.eventAggregator.Subscribe(this);
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
       
        public void Handle(CashflowCalculationErrorEvent message)
        {
            this.ErrorMessage = message.Error;
        }

        public void Handle(HierarchyChangedEvent message)
        {
            this.CashflowData.Values.Clear();
            this.WaccData.Values.Clear();
        }
    }
}