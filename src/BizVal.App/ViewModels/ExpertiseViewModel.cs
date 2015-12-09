using BizVal.App.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ExpertiseViewModel
    {
        private const string ExpertNamePattern = "Expert {0}";
        private readonly BindableHierarchy hierarchy;
        public IObservableCollection<SliderViewModel> Sliders { get; set; }

        public ExpertiseViewModel(BindableHierarchy hierarchy)
        {
            this.hierarchy = hierarchy;
            this.Sliders = new BindableCollection<SliderViewModel>();
            this.Sliders.Add(
                new SliderViewModel(
                    hierarchy, 
                    string.Format(ExpertNamePattern, this.Sliders.Count+1)));
        }

        public void Add()
        {
            var vm = new SliderViewModel(
                this.hierarchy,
                string.Format(ExpertNamePattern, this.Sliders.Count+1));
            this.Sliders.Add(vm);
        }
    }
}