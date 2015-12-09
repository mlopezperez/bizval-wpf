using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    internal class HierarchyManager : IHierarchyManager
    {
        private Hierarchy currentHierarchy;

        Hierarchy IHierarchyManager.GetCurrentHierarchy()
        {
            if (this.currentHierarchy == null)
            {
                this.currentHierarchy = new Hierarchy();
                this.currentHierarchy.Add(this.GetLabelSet3());
                this.currentHierarchy.Add(this.GetLabelSet5());
            }

            return this.currentHierarchy;
        }

        void IHierarchyManager.SaveHierarchy(Hierarchy modifiedHierarchy)
        {
            this.currentHierarchy = modifiedHierarchy;
        }

        private LabelSet GetLabelSet3()
        {
            var result = new LabelSet("3-Labels");
            result.Add(new Label(0, "Poco"));
            result.Add(new Label(1, "Medio"));
            result.Add(new Label(2, "Mucho"));
            return result;
        }

        private LabelSet GetLabelSet5()
        {
            var result = new LabelSet("5-Labels");
            result.Add(new Label(0, "Nada"));
            result.Add(new Label(1, "Poco"));
            result.Add(new Label(2, "Medio"));
            result.Add(new Label(3, "Bastante"));
            result.Add(new Label(4, "Mucho"));
            return result;
        }
    }
}