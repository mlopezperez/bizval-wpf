using BizVal.App.Interfaces;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    internal sealed class IntervalViewModel : Screen, IIntervalViewModel
    {
        private readonly LinguisticExpertise expertise;
        private readonly IWindowManager windowManager;
        public decimal LowerBound { get; set; }

        public decimal UpperBound { get; set; }

        public IntervalViewModel(LinguisticExpertise expertise, IWindowManager windowManager)
        {
            this.expertise = expertise;
            this.windowManager = windowManager;
        }

        public void Save()
        {
            this.TryClose();
        }

        public void Cancel()
        {
            this.TryClose();
        }

        public void Expertise()
        {
            //var vm = new ExpertiseViewModel(this.expertise.);
            //this.windowManager.ShowDialog(vm);
        }
    }
}
