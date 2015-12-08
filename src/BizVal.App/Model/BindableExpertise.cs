using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class BindableExpertise
    {
        public BindableInterval Interval { get; set; }
        public BindableCollection<Opinion> Opinions { get; set; }

        public BindableExpertise(BindableInterval interval)
        {
            this.Interval = interval;
            this.Opinions = new BindableCollection<Opinion>();
        }
    }
}
    