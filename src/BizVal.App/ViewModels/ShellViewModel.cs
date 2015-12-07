using System.Collections.Generic;
using System.Windows.Documents;
using BizVal.App.Interfaces;
using BizVal.App.Model;

namespace BizVal.App.ViewModels
{
    using System.Collections.ObjectModel;

    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        private readonly ObservableCollection<SliderViewModel> sliders = new ObservableCollection<SliderViewModel>();

        public ShellViewModel()
        {
            this.sliders.Add(new SliderViewModel());
            this.sliders.Add(new SliderViewModel());
            this.sliders.Add(new SliderViewModel());
        }

        public ObservableCollection<SliderViewModel> Sliders
        {
            get
            {
                return this.sliders;
            }
        }

        public HierarchyDefinitionViewModel Hierarchy
        {
            get
            {
                return new HierarchyDefinitionViewModel(new Hierarchy());
            }
        }

      
    }
}