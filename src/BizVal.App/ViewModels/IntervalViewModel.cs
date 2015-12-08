using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    internal sealed class IntervalViewModel : Screen, IIntervalViewModel
    {
        private readonly IWindowManager windowManager;
        private readonly IntervalWithOpinions intervalWithOpinions;

        public decimal LowerBound { get; set; }

        public decimal UpperBound { get; set; }

        public IntervalViewModel(IWindowManager windowManager, IntervalWithOpinions intervalWithOpinions)
        {
            this.windowManager = Contract.NotNull(windowManager, "windowManager");
            this.intervalWithOpinions = Contract.NotNull(intervalWithOpinions, "intervalWithOpinions");


            this.LowerBound = intervalWithOpinions.Interval.LowerBound;
            this.UpperBound = intervalWithOpinions.Interval.UpperBound;

        }

        public void Save()
        {
            this.intervalWithOpinions.Interval.LowerBound = this.LowerBound;
            this.intervalWithOpinions.Interval.UpperBound = this.UpperBound;
            this.TryClose(true);
        }

        public void Cancel()
        {
            this.TryClose(false);
        }

        public void Expertise()
        {
            //var vm = new ExpertiseViewModel(this.expertise.);
            //this.windowManager.ShowDialog(vm);
        }
    }
}
