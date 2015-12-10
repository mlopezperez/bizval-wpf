using System;
using System.Collections.Generic;
using System.Linq;
using BizVal.App.Events;
using BizVal.App.Model;
using BizVal.Model;
using Caliburn.Micro;
using Opinion = BizVal.Model.Opinion;

namespace BizVal.App.ViewModels
{
    public class ResultsViewModel : Screen, IHandle<CashflowCalculationEvent>
    {
        private const string IntervalPattern = "[{0:0.00}, {1:0.00}]";
        private readonly ICompanyValuator companyValuator;
        private readonly ICwCompanyValuator cwCompanyValuator;
        private readonly IEventAggregator eventAggregator;
        private readonly IHierarchyManager hierarchyManager;
        private BindableInterval cashflowResult;
        private BindableInterval cashflowLamaResult;
        private BindableInterval cashflowExpResult;

        public string CashflowResult
        {
            get
            {
                if (this.CashflowInterval != null)
                {
                    return string.Format(IntervalPattern, this.CashflowInterval.LowerBound,
                        this.CashflowInterval.UpperBound);
                }
                return string.Empty;
            }
        }

        public string CashflowLamaResult
        {
            get
            {
                if (this.CashflowLamaInterval != null)
                {
                    return string.Format(IntervalPattern, this.CashflowLamaInterval.LowerBound,
                        this.CashflowLamaInterval.UpperBound);
                }
                return string.Empty;

            }
        }

        public string CashflowExpResult
        {
            get
            {
                if (this.CashflowExpInterval != null)
                {
                    return string.Format(IntervalPattern, this.CashflowExpInterval.LowerBound,
                        this.CashflowExpInterval.UpperBound);
                }
                return string.Empty;

            }
        }

        public BindableInterval CashflowExpInterval
        {
            get { return this.cashflowExpResult; }
            set
            {
                this.cashflowExpResult = value;
                this.NotifyOfPropertyChange(() => this.CashflowExpInterval);
                this.NotifyOfPropertyChange(() => this.CashflowExpResult);
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


        public BindableInterval CashflowLamaInterval
        {
            get { return this.cashflowLamaResult; }
            set
            {
                this.cashflowLamaResult = value;
                this.NotifyOfPropertyChange(() => this.CashflowLamaInterval);
                this.NotifyOfPropertyChange(() => this.CashflowLamaResult);
            }
        }

        public ResultsViewModel(ICompanyValuator companyValuator, ICwCompanyValuator cwCompanyValuator, IEventAggregator eventAggregator, IHierarchyManager hierarchyManager)
        {
            this.companyValuator = companyValuator;
            this.cwCompanyValuator = cwCompanyValuator;
            this.eventAggregator = eventAggregator;
            this.hierarchyManager = hierarchyManager;

            this.eventAggregator.Subscribe(this);
        }

        public void Handle(CashflowCalculationEvent message)
        {
            try
            {
                this.CalculateCashflow(message);
                this.CalculateAdjustedCashflowByLama(message);
                this.CalculateAdjustedCashflowByExpertones(message);
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

        private void CalculateAdjustedCashflowByLama(CashflowCalculationEvent message)
        {
            var cashflowExpertises = this.GetExpertises(message.Cashflows);
            var waccExpertises = this.GetExpertises(message.Waccs);
            var result = this.cwCompanyValuator.CashflowWithLama(cashflowExpertises, waccExpertises, this.hierarchyManager.GetCurrentHierarchy());
            this.CashflowLamaInterval = new BindableInterval(result);
        }

        private void CalculateAdjustedCashflowByExpertones(CashflowCalculationEvent message)
        {
            var cashflowExpertises = this.GetExpertises(message.Cashflows);
            var waccExpertises = this.GetExpertises(message.Waccs);
            var result = this.cwCompanyValuator.CashflowWithExpertones(cashflowExpertises, waccExpertises, this.hierarchyManager.GetCurrentHierarchy());
            this.CashflowExpInterval = new BindableInterval(result);
        }

        private IList<Expertise> GetExpertises(IList<BindableExpertise> cashflows)
        {
            var result = new List<Expertise>();
            var hierachy = this.hierarchyManager.GetCurrentHierarchy();
            foreach (var item in cashflows)
            {
                var interval = new Interval(item.Interval.LowerBound, item.Interval.UpperBound);
                var linguisticExpertise = new Expertise(interval);
                foreach (var opinion in item.Opinions)
                {
                    var lowerLabel = hierachy[opinion.LabelSet][opinion.LowerBoundLabel.Index];
                    var upperLabel = hierachy[opinion.LabelSet][opinion.UpperBoundLabel.Index];

                    linguisticExpertise.Opinions.Add(new Opinion(lowerLabel.Theta(), upperLabel.Theta()));
                }
                result.Add(linguisticExpertise);
            }
            return result;
        }

        private void CalculateCashflow(CashflowCalculationEvent message)
        {
            var cashflowIntervals =
                message.Cashflows.Select(i => new Interval(i.Interval.LowerBound, i.Interval.UpperBound)).ToList();
            var waccIntervals =
                message.Waccs.Select(i => new Interval(i.Interval.LowerBound, i.Interval.UpperBound)).ToList();
            var result = this.companyValuator.Cashflow(cashflowIntervals, waccIntervals);
            this.CashflowInterval = new BindableInterval(result);
        }
    }


}
