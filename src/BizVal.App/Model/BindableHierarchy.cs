using System.Linq;
using System.Runtime.CompilerServices;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class BindableHierarchy : PropertyChangedBase
    {
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

        public BindableHierarchy(Hierarchy hierarchy)
        {
            var hLevels = hierarchy.Select(i => new BindableLabelSet(i));
            this.Levels = new BindableCollection<BindableLabelSet>(hLevels);
        }
    }
}
