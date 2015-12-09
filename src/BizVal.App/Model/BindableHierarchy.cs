using System.Linq;
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
            var sets = hierarchy.Select(i => new BindableLabelSet(i));
            this.Levels = new BindableCollection<BindableLabelSet>(sets);
        }

        public void UpLevel(BindableLabelSet set)
        {
            var currentIndex = this.Levels.IndexOf(set);
            if (currentIndex > 0)
            {
                var previousLevel = this.Levels[currentIndex - 1];
                this.Levels[currentIndex] = previousLevel;
                this.Levels[currentIndex - 1] = set;
                this.NotifyOfPropertyChange(() => this.Levels);
            }
        }

        public void DownLevel(BindableLabelSet set)
        {
            var currentIndex = this.Levels.IndexOf(set);
            if (currentIndex < this.Levels.Count - 1)
            {
                var nextLevel = this.Levels[currentIndex + 1];
                this.Levels[currentIndex] = nextLevel;
                this.Levels[currentIndex + 1] = set;
            }
        }
    }
}
