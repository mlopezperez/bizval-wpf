using System.Linq;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class BindableLabelSet : PropertyChangedBase
    {
        private readonly LabelSet labelSet;

        public string SetName
        {
            get
            {
                return this.labelSet.Name;
            }
            set
            {
                this.labelSet.Name = value;
                this.NotifyOfPropertyChange(() => this.SetName);
            }
        }

        public IObservableCollection<BindableLabel> Terms
        {
            get
            {
                var labels = this.labelSet.Select(i => new BindableLabel(i));
                return new BindableCollection<BindableLabel>(labels);
            }
        }

        public BindableLabelSet(LabelSet labelSet)
        {
            this.labelSet = labelSet;
        }
    }
}