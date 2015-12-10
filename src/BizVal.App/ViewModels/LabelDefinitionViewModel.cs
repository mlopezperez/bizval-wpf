using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizVal.App.Model;
using Caliburn.Micro;
using Microsoft.Win32;

namespace BizVal.App.ViewModels
{
    internal class LabelDefinitionViewModel : Screen
    {
        private readonly BindableLabel label;
        private decimal lower;
        private decimal upper;
        private decimal medium;

        public string LabelName { get; set; }

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
                this.NotifyOfPropertyChange(() => this.CanSave);
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
                this.NotifyOfPropertyChange(() => this.CanSave);
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
                this.NotifyOfPropertyChange(() => this.CanSave);
            }
        }

        public LabelDefinitionViewModel(BindableLabel label)
        {
            this.label = label;
            this.Lower = label.Lower;
            this.Upper = label.Upper;
            this.Medium = label.Medium;
            this.LabelName = label.Name;
            this.DisplayName = "Define Label";
        }

        public bool CanSave
        {
            get { return (this.Lower <= this.Medium) && (this.Medium <= this.Upper); }
        }

        public void Save()
        {
            this.label.Lower = this.Lower;
            this.label.Upper = this.Upper;
            this.label.Medium = this.Medium;
            this.TryClose(true);
        }

        public void Cancel()
        {
            this.TryClose(false);
        }
    }
}
