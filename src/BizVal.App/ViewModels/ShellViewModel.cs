using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ShellViewModel : IShell
    {
        private readonly IWindowManager windowManager;

        public CashflowViewModel Cashflow { get; set; }

        public MixedAnalysisViewModel MixedAnalysis { get; set; }

        //public ExpertiseViewModel Expertise { get; set; }

        //private readonly Hierarchy hierarchy;

        public ShellViewModel(
            IWindowManager windowManager,
            //IHierarchyManager hierarchyManager,
            CashflowViewModel casflowViewModel,
            MixedAnalysisViewModel mixedAnalysisViewModel)
        {
            this.windowManager = Contract.NotNull(windowManager, "windowManager");
            //Contract.NotNull(hierarchyManager, "hierarchyManager");

            //this.hierarchy = hierarchyManager.GetDefaultHierarchy();

            this.Cashflow = Contract.NotNull(casflowViewModel, "casflowViewModel");
            this.MixedAnalysis = Contract.NotNull(mixedAnalysisViewModel, "mixedAnalysisViewModel");
            //this.Expertise = new ExpertiseViewModel(new BindableHierarchy(this.hierarchy));
        }

        public void DefineHierarchy()
        {
            //var bindableHierarchy = new BindableHierarchy(this.hierarchy);
            //var vm = new HierarchyDefinitionViewModel(bindableHierarchy);
            //this.windowManager.ShowDialog(vm);
        }
    }
}