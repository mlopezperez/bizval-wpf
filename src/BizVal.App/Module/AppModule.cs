using BizVal.App.Interfaces;
using BizVal.App.ViewModels;
using BizVal.Framework.DependencyInjection;
using Caliburn.Micro;

namespace BizVal.App.Module
{
    class AppModule : IModule
    {
        public void Configure(IContainer container)
        {
            container.RegisterType<IWindowManager, WindowManager>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<IEventAggregator, EventAggregator>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<IShell, ShellViewModel>(LifeTimeManagerType.PerResolveLifetime);
        }
    }
}
