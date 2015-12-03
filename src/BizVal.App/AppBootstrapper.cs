namespace BizVal.App
{
    using BizVal.App.ViewModels;
    using Caliburn.Micro;
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;

    public class AppBootstrapper : BootstrapperBase, IDisposable
    {
        private IUnityContainer container;

        public AppBootstrapper()
        {
            this.Initialize();
        }

        protected override void Configure()
        {
            this.container = new UnityContainer();

            this.container.RegisterType<IWindowManager, WindowManager>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IShell, ShellViewModel>(new PerResolveLifetimeManager());
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = this.container.Resolve(service, key);
            if (instance != null)
            {
                return instance;
            }

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return this.container.ResolveAll(service);
        }

        protected override void BuildUp(object instance)
        {
            this.container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            this.DisplayRootViewFor<IShell>();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.container != null)
                {
                    this.container.Dispose();
                }
            }
        }
    }
}