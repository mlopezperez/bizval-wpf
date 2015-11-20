namespace BizVal.App.Model
{
    using System.Collections.Generic;

    public class HierarchyLevel
    {
        public string Name { get; set; }

        public IList<string> Terms { get; private set; }

        public HierarchyLevel()
        {
            this.Terms = new List<string>();
        }

        public bool AddTerm(string term)
        {
            this.Terms.Add(term);
            return true;
        }
    }
}