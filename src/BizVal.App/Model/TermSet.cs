namespace BizVal.App.Model
{
    using System.Collections.Generic;

    public class TermSet
    {
        public string Name { get; set; }

        public IList<string> Terms { get; set; }
    }
}