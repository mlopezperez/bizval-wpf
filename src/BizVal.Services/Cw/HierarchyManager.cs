using BizVal.Model;

namespace BizVal.Services.Cw
{
    internal class HierarchyManager : IHierarchyManager
    {
        private Hierarchy currentHierarchy;

        Hierarchy IHierarchyManager.GetCurrentHierarchy()
        {
            if (this.currentHierarchy == null)
            {
                this.currentHierarchy = new Hierarchy();
               
                this.currentHierarchy.Add(this.GetLabelSet5());
                this.currentHierarchy.Add(this.GetLabelSet7());
                this.currentHierarchy.Add(this.GetLabelSet9());
            }

            return this.currentHierarchy;
        }

        void IHierarchyManager.SaveHierarchy(Hierarchy modifiedHierarchy)
        {
            this.currentHierarchy = modifiedHierarchy;
        }

        private LabelSet GetLabelSet9()
        {
            var result = new LabelSet("9-Labels");
            result.Add(new Label(0, "Nada", 0, 0, 0.125m));
            result.Add(new Label(1, "Casi nada", 0, 0.125m, 0.250m));
            result.Add(new Label(2, "Muy poco", 0.125m, 0.250m, 0.375m));
            result.Add(new Label(3, "Poco", 0.250m, 0.375m, 0.5m));
            result.Add(new Label(4, "Medio", 0.375m, 0.5m, 0.625m));
            result.Add(new Label(5, "Bastante", 0.5m, 0.625m, 0.750m));
            result.Add(new Label(6, "Mucho", 0.625m, 0.750m, 0.875m));
            result.Add(new Label(7, "Casi todo", 0.750m, 0.875m, 1m));
            result.Add(new Label(8, "Todo", 0.875m, 1m, 1m));
            return result;
        }

        private LabelSet GetLabelSet7()
        {
            var result = new LabelSet("7-Labels");
            result.Add(new Label(0, "Nada", 0, 0, 0.17m));
            result.Add(new Label(1, "Casi nada", 0, 0.17m, 0.33m));
            result.Add(new Label(2, "Poco", 0.17m, 0.33m, 0.5m));
            result.Add(new Label(3, "Medio", 0.33m, 0.5m, 0.67m));
            result.Add(new Label(4, "Bastante", 0.5m, 0.67m, 0.83m));
            result.Add(new Label(5, "Mucho", 0.67m, 0.83m, 1m));
            result.Add(new Label(6, "Todo", 0.83m, 1m, 1m));
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