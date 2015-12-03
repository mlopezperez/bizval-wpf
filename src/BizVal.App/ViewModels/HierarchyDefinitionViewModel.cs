using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BizVal.App.Model;

using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class HierarchyDefinitionViewModel : PropertyChangedBase
    {
        private readonly Hierarchy hierarchy;

        public HierarchyDefinitionViewModel(Hierarchy hierarchy)
        {
            this.hierarchy = hierarchy;
        }

        public ListViewModel TermSet
        {
            get
            {
                return new ListViewModel("New term:", new List<string>());
            }
        }

        public ListViewModel Hierarchy
        {
            get
            {
                return new ListViewModel("New Set Name:", new List<string>());
            }
        }
    }
}
