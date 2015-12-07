using System;
using System.Collections.Generic;
using BizVal.App.Interfaces;
using BizVal.App.Module;
using BizVal.Framework.DependencyInjection;
using Caliburn.Micro;

namespace BizVal.App
{
    public class AppBootstrapper : BootstrapperBase, IDisposable
    {
        private IContainer container;

        public AppBootstrapper()
        {
            this.Initialize();
        }

        protected override void Configure()
        {
            this.container = new Container(new LifeTimeManagerFactory());

            var appModule = new AppModule();
            appModule.Configure(this.container);
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = this.container.Resolve(service);
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