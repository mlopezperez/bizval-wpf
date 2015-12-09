using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ShellViewModel : IShell
    {
        private readonly HierarchyDefinitionViewModel hierarchyDefinitionViewModel;
        private readonly IWindowManager windowManager;

        public CashflowViewModel Cashflow { get; set; }

        public MixedAnalysisViewModel MixedAnalysis { get; set; }

        //public ExpertiseViewModel Expertise { get; set; }

        //private readonly Hierarchy hierarchy;

        public ShellViewModel(
            IWindowManager windowManager,
            HierarchyDefinitionViewModel hierarchyDefinitionViewModel,
            CashflowViewModel casflowViewModel,
            MixedAnalysisViewModel mixedAnalysisViewModel)
        {
            this.hierarchyDefinitionViewModel = hierarchyDefinitionViewModel;
            this.windowManager = Contract.NotNull(windowManager, "windowManager");

            this.Cashflow = Contract.NotNull(casflowViewModel, "casflowViewModel");
            this.MixedAnalysis = Contract.NotNull(mixedAnalysisViewModel, "mixedAnalysisViewModel");
        }

        public void DefineHierarchy()
        {
            this.windowManager.ShowDialog(this.hierarchyDefinitionViewModel);
        }
    }
}