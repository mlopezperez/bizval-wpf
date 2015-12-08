using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class Interval : PropertyChangedBase
    {
        private decimal lowerBound;
        private decimal upperBound;

        public decimal LowerBound
        {
            get
            {
                return this.lowerBound;
            }
            set
            {
                this.lowerBound = value;
                this.NotifyOfPropertyChange(() => this.LowerBound);
            }
        }

        public decimal UpperBound
        {
            get
            {
                return this.upperBound;
            }
            set
            {
                this.upperBound = value;
                this.NotifyOfPropertyChange(() => this.UpperBound);
            }
        }
    }
}
