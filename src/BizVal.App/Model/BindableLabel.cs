using System.Runtime.CompilerServices;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class BindableLabel : PropertyChangedBase
    {
        private int index;
        private string name;

        public int Index
        {
            get { return this.index; }
            set
            {
                this.index = value;
                this.NotifyOfPropertyChange(() => this.Index);
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.NotifyOfPropertyChange(() => this.Name);
            }
        }

        public BindableLabel(Label label)
        {
            this.Name = label.Name;
            this.Index = label.Index;
        }
    }
}