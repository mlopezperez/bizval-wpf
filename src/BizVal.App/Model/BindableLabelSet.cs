using System.Linq;
using System.Windows.Markup;
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

        public void UpLabel(BindableLabel label)
        {
            var currentIndex = this.Labels.IndexOf(label);
            if (currentIndex > 0)
            {
                var previousLabel = this.Labels[currentIndex - 1];
                this.Labels[currentIndex] = previousLabel;
                this.Labels[currentIndex - 1] = label;
                this.NotifyOfPropertyChange(() => this.Labels);
                label.Index = currentIndex - 1;
                previousLabel.Index = currentIndex;
            }
        }

        public void DownLabel(BindableLabel label)
        {
            var currentIndex = this.Labels.IndexOf(label);
            if (currentIndex < this.Labels.Count - 1)
            {
                var nextLabel = this.Labels[currentIndex + 1];
                this.Labels[currentIndex] = nextLabel;
                this.Labels[currentIndex + 1] = label;
                label.Index = currentIndex + 1;
                nextLabel.Index = currentIndex;
            }
        }
    }
}