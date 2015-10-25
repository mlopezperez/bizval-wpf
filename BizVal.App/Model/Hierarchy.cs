namespace BizVal.App.Model
{
    using System.Collections.Generic;

    public class Hierarchy
    {
        public string Name { get; set; }

        public IList<TermSet> TermSets { get; set; }
    }
}
