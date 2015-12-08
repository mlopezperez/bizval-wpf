using BizVal.App.Interfaces;
using BizVal.App.ViewModels;
using BizVal.Framework.DependencyInjection;
using Caliburn.Micro;

namespace BizVal.App.Module
{
    internal sealed class AppModule : IModule
    {
        public void Configure(IContainer container)
        {
            container.RegisterType<IWindowManager, WindowManager>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<IEventAggregator, EventAggregator>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<IShell, ShellViewModel>(LifeTimeManagerType.PerResolveLifetime);
            container.RegisterType<IListViewModel, ListViewModel>(LifeTimeManagerType.TransientLifetime);
            container.RegisterType<IHierarchyDefinitionViewModel, HierarchyDefinitionViewModel>(LifeTimeManagerType.TransientLifetime);
            container.RegisterType<IIntervalListViewModel, IntervalListViewModel>(LifeTimeManagerType.TransientLifetime);
        }
    }
}
