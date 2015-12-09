using System.Linq;
using BizVal.App.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class SliderViewModel : PropertyChangedBase
    {
        private int lowerValue;
        private int upperValue;
        private BindableLabelSet currentSet;
        private string expertName;
        public IObservableCollection<BindableLabelSet> Sets { get; private set; }

        public BindableLabelSet CurrentSet
        {
            get
            {
                return this.currentSet;
            }
            set
            {
                this.currentSet = value;
                this.NotifyOfPropertyChange(() => this.CurrentSet);
                this.NotifyOfPropertyChange(() => this.MaxValue);
                this.NotifyOfPropertyChange(() => this.LowerLabel);
                this.NotifyOfPropertyChange(() => this.UpperLabel);
            }
        }

        public string UpperLabel
        {
            get
            {
                return this.CurrentSet.Terms[this.UpperBoundValue].Name;
            }
        }

        public string LowerLabel
        {
            get
            {
                return this.CurrentSet.Terms[this.LowerBoundValue].Name;
            }
        }

        public int LowerBoundValue
        {
            get
            {
                return this.lowerValue;
            }
            set
            {
                this.lowerValue = value;
                this.NotifyOfPropertyChange(() => this.LowerBoundValue);
                this.NotifyOfPropertyChange(() => this.LowerLabel);
            }
        }

        public int UpperBoundValue
        {
            get
            {
                return this.upperValue;
            }
            set
            {
                this.upperValue = value;
                this.NotifyOfPropertyChange(() => this.UpperBoundValue);
                this.NotifyOfPropertyChange(() => this.UpperLabel);
            }
        }

        public string ExpertName
        {
            get { return this.expertName; }
            set
            {
                this.expertName = value;
                this.NotifyOfPropertyChange(() => this.ExpertName);
            }
        }

        public int MaxValue
        {
            get { return this.CurrentSet.Terms.Count - 1; }
        }

        public SliderViewModel(BindableHierarchy bindableHierarchy, string expertName)
        {
            this.Sets = bindableHierarchy.Levels;
            this.CurrentSet = this.Sets.First();
            this.ExpertName = expertName;
        }
    }
}
