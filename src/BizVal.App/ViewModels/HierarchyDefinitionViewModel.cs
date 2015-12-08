using BizVal.App.Interfaces;
using BizVal.Framework;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class HierarchyDefinitionViewModel : PropertyChangedBase, IHierarchyDefinitionViewModel
    {
        public ListViewModel TermSet { get; set; }

        public ListViewModel Levels { get; set; }

        public HierarchyDefinitionViewModel(ListViewModel levels, ListViewModel termSet)
        {
            this.Levels = Contract.NotNull(levels, "levels");
            this.TermSet = Contract.NotNull(termSet, "termSet");

            this.Levels.InputName = "Levels:";
            this.TermSet.InputName = "Terms:";
        }
    }
}
