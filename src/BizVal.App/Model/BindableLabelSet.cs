using System.Linq;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class BindableLabelSet : PropertyChangedBase
    {
        private string setName;
        private IObservableCollection<BindableLabel> labels;

        public string SetName
        {
            get
            {
                return this.setName;
            }
            set
            {
                this.setName = value;
                this.NotifyOfPropertyChange(() => this.SetName);
            }
        }

        public IObservableCollection<BindableLabel> Labels
        {
            get { return this.labels; }
            set
            {
                this.labels = value;
                this.NotifyOfPropertyChange(() => this.Labels);
            }
        }

        public BindableLabelSet(LabelSet labelSet)
        {
            var set = labelSet.Select(i => new BindableLabel(i));
            this.SetName = labelSet.Name;
            this.Labels = new BindableCollection<BindableLabel>(set);
        }
    }
}