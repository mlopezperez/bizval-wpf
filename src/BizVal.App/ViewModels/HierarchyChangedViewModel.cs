using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class HierarchyChangedViewModel : Screen
    {
        public HierarchyChangedViewModel()
        {
            this.DisplayName = "Warning!!";
        }

        public void Accept()
        {
            this.TryClose(true);
        }

        public void Cancel()
        {
            this.TryClose(false);
        }
    }
}
