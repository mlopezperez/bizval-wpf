using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class BindableInterval : PropertyChangedBase
    {
        private decimal lowerBound;
        private decimal upperBound;
        private decimal width;

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
                this.NotifyOfPropertyChange(() => this.Width);
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
                this.NotifyOfPropertyChange(() => this.Width);
            }
        }

        public string Width
        {
            get
            {
                var val = this.upperBound - this.lowerBound;
                return val.ToString("N2");
            }

        }

        public BindableInterval()
        {
        }

        public BindableInterval(Interval interval)
        {
            Contract.NotNull(interval, "interval");
            this.LowerBound = interval.LowerBound;
            this.upperBound = interval.UpperBound;
        }
    }
}
