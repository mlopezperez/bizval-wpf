using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class BindableLabel : PropertyChangedBase
    {
        private readonly Label label;

        public int Index
        {
            get
            {
                return this.label.Index;
            }
            set
            {
                this.label.Index = value;
                this.NotifyOfPropertyChange(() => this.Index);
            }
        }

        public string Name
        {
            get
            {
                return this.label.Name;
            }
            set
            {
                this.label.Name = value;
                this.NotifyOfPropertyChange(() => this.Name);
            }
        }

        public BindableLabel(Label label)
        {
            this.label = label;
        }
    }
}