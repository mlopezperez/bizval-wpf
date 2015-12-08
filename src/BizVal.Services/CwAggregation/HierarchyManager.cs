using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    internal class HierarchyManager : IHierarchyManager
    {
        public Hierarchy GetDefaultHierarchy()
        {
            var hierarchy = new Hierarchy();
            hierarchy.Add(this.GetLabelSet3());
            hierarchy.Add(this.GetLabelSet5());
            return hierarchy;
        }

        private LabelSet GetLabelSet3()
        {
            var result = new LabelSet();
            result.Add(new Label(0, "Poco"));
            result.Add(new Label(1, "Medio"));
            result.Add(new Label(2, "Mucho"));
            return result;
        }

        private LabelSet GetLabelSet5()
        {
            var result = new LabelSet();
            result.Add(new Label(0, "Nada"));
            result.Add(new Label(1, "Poco"));
            result.Add(new Label(2, "Mucho"));
            result.Add(new Label(3, "Algo"));
            result.Add(new Label(4, "Mucho"));
            return result;
        }
    }
}