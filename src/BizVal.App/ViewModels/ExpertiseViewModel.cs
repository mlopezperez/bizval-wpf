using System.Linq;
using BizVal.App.Model;
using BizVal.Framework;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ExpertiseViewModel : Screen
    {
        private readonly BindableExpertise expertise;
        private const string IntervalPattern = "Interval: [{0:0.00}, {1:0.00}]";
        private const string ExpertNamePattern = "Expert {0}";
        private readonly BindableHierarchy hierarchy;
        private string interval;

        public IObservableCollection<SliderViewModel> Sliders { get; set; }

        public string Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                this.interval = value;
                this.NotifyOfPropertyChange(() => this.Interval);
            }
        }

        public ExpertiseViewModel(IHierarchyManager hierarchyManager, BindableExpertise expertise)
        {
            this.expertise = expertise;
            Contract.NotNull(hierarchyManager, "hierarchyManager");
            this.Sliders = new BindableCollection<SliderViewModel>();

            this.hierarchy = new BindableHierarchy(hierarchyManager.GetCurrentHierarchy());
            this.LoadExpertise();

            this.Interval = string.Format(IntervalPattern, expertise.Interval.LowerBound, expertise.Interval.UpperBound);
        }

        private void LoadExpertise()
        {
            foreach (var opinion in this.expertise.Opinions)
            {
                this.LoadOpinion(opinion);
            }
        }

        public void LoadOpinion(Opinion opinion)
        {
            var vm = new SliderViewModel(this.hierarchy, string.Format(ExpertNamePattern, this.Sliders.Count + 1));
            vm.CurrentSet = hierarchy.Levels.SingleOrDefault(l => l.Labels.Count == opinion.LabelSet);
            vm.LowerBoundValue = opinion.LowerBoundLabel.Index;
            vm.UpperBoundValue = opinion.UpperBoundLabel.Index;
            this.Sliders.Add(vm);
        }

        public void Save()
        {
            this.SaveOpinionsToExpertise();
            this.TryClose(true);
        }

        private void SaveOpinionsToExpertise()
        {
            this.expertise.Opinions.Clear();
            foreach (var vm in this.Sliders)
            {
                var opinion = new Opinion()
                {
                    LabelSet = vm.CurrentSet.Labels.Count,
                    LowerBoundLabel = vm.CurrentSet.Labels[vm.LowerBoundValue],
                    UpperBoundLabel = vm.CurrentSet.Labels[vm.UpperBoundValue],
                };

                this.expertise.Opinions.Add(opinion);
            }
        }

        public void Cancel()
        {
            this.TryClose(false);
        }

        public void Add()
        {
            var vm = new SliderViewModel(this.hierarchy, string.Format(ExpertNamePattern, this.Sliders.Count + 1));
            this.Sliders.Add(vm);
        }

        public void Delete()
        {
            var selected = this.Sliders.Where(vm => vm.Selected).ToList();
            this.Sliders.RemoveRange(selected);
        }
    }
}