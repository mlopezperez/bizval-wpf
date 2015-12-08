using System.Linq;
using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class HierarchyDefinitionViewModel : Screen, IHierarchyDefinitionViewModel
    {
        private BindableLabelSet selectedSet;
        private IObservableCollection<BindableLabelSet> levels;

        public IObservableCollection<BindableLabelSet> Levels
        {
            get
            {
                return this.levels;
            }
            set
            {
                this.levels = value;
                this.NotifyOfPropertyChange(() => this.Levels);
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

        public HierarchyDefinitionViewModel(BindableHierarchy bindableHierarchy)
        {
            this.Levels = bindableHierarchy.Levels;
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
