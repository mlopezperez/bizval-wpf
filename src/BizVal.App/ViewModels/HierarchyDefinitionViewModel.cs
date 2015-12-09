using BizVal.App.Interfaces;
using BizVal.App.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class HierarchyDefinitionViewModel : Screen, IHierarchyDefinitionViewModel
    {
        private BindableLabelSet selectedSet;
        private BindableHierarchy bindableHierarchy;

        public BindableHierarchy Hierarchy
        {
            get
            {
                return this.bindableHierarchy;
            }
            set
            {
                this.bindableHierarchy = value;
                this.NotifyOfPropertyChange(() => this.Hierarchy);
            }
        }


        public BindableLabelSet SelectedSet
        {
            get
            {
                return this.selectedSet;
            }
            set
            {
                this.selectedSet = value;
                this.NotifyOfPropertyChange(() => this.SelectedSet);
            }
        }

        public HierarchyDefinitionViewModel(IHierarchyManager hierarchyManager)
        {
            var hierarchy = hierarchyManager.GetCurrentHierarchy();
            this.Hierarchy = new BindableHierarchy(hierarchy);
        }

        public void AddSet()
        {
            int i = 0;
        }

        public void Cancel()
        {
            this.TryClose(false);
        }
    }
}
