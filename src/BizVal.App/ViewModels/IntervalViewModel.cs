using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    internal sealed class IntervalViewModel : Screen, IIntervalViewModel
    {
        private readonly IHierarchyManager hierarchyManager;
        private readonly IWindowManager windowManager;
        private readonly BindableExpertise expertise;

        public decimal LowerBound
        {
            get
            {
                return this.expertise.Interval.LowerBound;
            }
            set
            {
                this.expertise.Interval.LowerBound = value;
                this.NotifyOfPropertyChange(() => this.LowerBound);
            }
        }

        public decimal UpperBound
        {
            get
            {
                return this.expertise.Interval.UpperBound;
            }
            set
            {
                this.expertise.Interval.UpperBound = value;
                this.NotifyOfPropertyChange(() => this.UpperBound);
            }
        }

        public IntervalViewModel(IWindowManager windowManager, BindableExpertise intervalWithOpinions, IHierarchyManager hierarchyManager)
        {
            this.hierarchyManager = hierarchyManager;
            this.windowManager = Contract.NotNull(windowManager, "windowManager");
            this.expertise = Contract.NotNull(intervalWithOpinions, "intervalWithOpinions");

            this.LowerBound = intervalWithOpinions.Interval.LowerBound;
            this.UpperBound = intervalWithOpinions.Interval.UpperBound;

        }

        public void Save()
        {
            this.expertise.Interval.LowerBound = this.LowerBound;
            this.expertise.Interval.UpperBound = this.UpperBound;
            this.TryClose(true);
        }

        public void Cancel()
        {
            this.TryClose(false);
        }

        public void Expertise()
        {
            var vm = new ExpertiseViewModel(this.hierarchyManager, this.expertise);
            this.windowManager.ShowDialog(vm);
        }
    }
}
