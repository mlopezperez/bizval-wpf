using System.Collections.Generic;

namespace BizVal.Model
{
    public class Expertise
    {
        public Interval Interval { get; set; }
        public IList<Opinion> Opinions { get; set; }

        public Expertise(Interval interval)
        {
            this.Interval = interval;
            this.Opinions = new List<Opinion>();
        }
    }
}
