using Caliburn.Micro;

namespace BizVal.App.Model
{
    public class IntervalWithOpinions
    {
        public Interval Interval { get; set; }
        public BindableCollection<Opinion> Opinions { get; set; }

        public IntervalWithOpinions(Interval interval)
        {
            this.Interval = interval;
            this.Opinions = new BindableCollection<Opinion>();
        }
    }
}
