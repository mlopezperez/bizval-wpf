using System;
using System.Runtime.CompilerServices;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class BindableLabel : PropertyChangedBase
    {
        private int index;
        private string name;
        private decimal lower;
        private decimal upper;
        private decimal medium;

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
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.NotifyOfPropertyChange(() => this.Name);
            }
        }

        public decimal Lower
        {
            get
            {
                return this.lower;
            }
            set
            {
                this.lower = value;
                this.NotifyOfPropertyChange(() => this.Lower);
            }
        }

        public decimal Upper
        {
            get
            {
                return this.upper;
            }
            set
            {
                this.upper = value;
                this.NotifyOfPropertyChange(() => this.Upper);
            }
        }

        public decimal Medium
        {
            get
            {
                return this.medium;
            }
            set
            {
                this.medium = value;
                this.NotifyOfPropertyChange(() => this.Medium);
            }
        }

        public BindableLabel(Label label)
        {
            this.Name = label.Name;
            this.Index = label.Index;

            this.Lower = label.A;
            this.Upper = label.B;
            this.Medium = label.M;
        }
    }
}