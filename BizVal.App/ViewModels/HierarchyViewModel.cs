using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Primitives;

using BizVal.App.Model;

using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class HierarchyViewModel : PropertyChangedBase, IHierarchy
    {
        private readonly Hierarchy hierarchy;

        private readonly List<string> levelNames;

        public HierarchyViewModel()
        {
            this.hierarchy = new Hierarchy();
            this.levelNames = this.hierarchy.Levels.Select(l => l.Name).ToList();
        }

        public ListViewModel TermSet { get; set; }

        public ListViewModel Hierarchy { get; set; }
    }
}
