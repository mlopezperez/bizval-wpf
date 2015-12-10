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
            result.Add(new Label(0, "Poco", 0, 0, 0.5m));
            result.Add(new Label(1, "Medio", 0, 0.5m, 1));
            result.Add(new Label(2, "Mucho", 0.5m, 1, 1));
            return result;
        }

        private LabelSet GetLabelSet5()
        {
            var result = new LabelSet("5-Labels");
            result.Add(new Label(0, "Nada", 0, 0, 0.25m));
            result.Add(new Label(1, "Poco", 0, 0.25m, 0.50m));
            result.Add(new Label(2, "Medio", 0.25m, 0.50m, 0.75m));
            result.Add(new Label(3, "Bastante", 0.50m, 0.75m, 1));
            result.Add(new Label(4, "Mucho", 0.75m, 1, 1));
            return result;
        }
    }
}