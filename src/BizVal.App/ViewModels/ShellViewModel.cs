using BizVal.App.Interfaces;
using System.Collections.ObjectModel;

namespace BizVal.App.ViewModels
{
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        private readonly ObservableCollection<SliderViewModel> sliders = new ObservableCollection<SliderViewModel>();

        public ShellViewModel(HierarchyDefinitionViewModel hierarchyDefinition)
        {
            this.HierarchyDefinition = hierarchyDefinition;
        }
       
        public HierarchyDefinitionViewModel HierarchyDefinition { get; set; }
    }
}