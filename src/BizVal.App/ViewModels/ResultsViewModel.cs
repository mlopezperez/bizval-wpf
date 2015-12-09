using System;
using System.Linq;
using BizVal.App.Events;
using BizVal.App.Model;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ResultsViewModel : Screen, IHandle<CashflowCalculationEvent>
    {
        private const string IntervalPattern = "[{0:0.00}, {1:0.00}]";
        private readonly ICompanyValuator companyValuator;
        private readonly ICwCompanyValuator cwCompanyValuator;
        private readonly IEventAggregator eventAggregator;
        private BindableInterval cashflowResult;

        public string CashflowResult
        {
            get
            {
                if (this.CashflowInterval != null)
                {
                    return string.Format(IntervalPattern, this.CashflowInterval.LowerBound,
                        this.CashflowInterval.UpperBound);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public BindableInterval CashflowInterval
        {
            get { return this.cashflowResult; }
            set
            {
                this.cashflowResult = value;
                this.NotifyOfPropertyChange(() => this.CashflowInterval);
                this.NotifyOfPropertyChange(() => this.CashflowResult);
            }
        }

        public ResultsViewModel(ICompanyValuator companyValuator, ICwCompanyValuator cwCompanyValuator, IEventAggregator eventAggregator)
        {
            this.companyValuator = companyValuator;
            this.cwCompanyValuator = cwCompanyValuator;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.Subscribe(this);
        }

        public void Handle(CashflowCalculationEvent message)
        {
            try
            {
                this.CalculateCashflow(message);
                // this.CalculateAdjustedCashflow(message);
            }
            catch (ValuationException ex)
            {
                this.eventAggregator.PublishOnUIThread(new CashflowCalculationErrorEvent(ex.Message));
            }
            catch (AggregateException ex)
            {
                this.eventAggregator.PublishOnUIThread(new CashflowCalculationErrorEvent(ex.Message));
            }
        }

        private void CalculateAdjustedCashflow(CashflowCalculationEvent message)
        {
            throw new NotImplementedException();
        }

        private void CalculateCashflow(CashflowCalculationEvent message)
        {
            var cashflowIntervals =
                message.Cashflows.Select(i => new Interval(i.Interval.LowerBound, i.Interval.UpperBound)).ToList();
            var waccIntervals =
                message.Waccs.Select(i => new Interval(i.Interval.LowerBound, i.Interval.UpperBound)).ToList();
            var result = this.companyValuator.Cashflow(cashflowIntervals, waccIntervals);
            this.CashflowInterval = new BindableInterval()
            {
                LowerBound = result.LowerBound,
                UpperBound = result.UpperBound
            };
        }
    }


}
