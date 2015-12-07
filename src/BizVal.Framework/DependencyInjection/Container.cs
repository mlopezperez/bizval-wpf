using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace BizVal.Framework.DependencyInjection
{
    public class Container : IContainer
    {
        private readonly IUnityContainer container;

        private readonly ILifeTimeManagerFactory lifeTimeManagerFactory;

        public Container(ILifeTimeManagerFactory lifeTimeManagerFactory)
            : this(lifeTimeManagerFactory, new UnityContainer())
        {
        }

        private Container(ILifeTimeManagerFactory lifeTimeManagerFactory, IUnityContainer container)
        {
            this.lifeTimeManagerFactory = Contract.NotNull(lifeTimeManagerFactory, "lifeTimeManagerFactory");
            this.container = Contract.NotNull(container, "container");
        }

        public void RegisterTypeIf<TFrom, TTo>(LifeTimeManagerType lifetimeManagerType) where TTo : TFrom
        {
            if (!this.container.IsRegistered<TFrom>())
            {
                var lifeTimeManager = this.lifeTimeManagerFactory.CreateLifeTimeManager(lifetimeManagerType);
                this.container.RegisterType<TFrom, TTo>(lifeTimeManager);
            }
        }

        public void RegisterType<TFrom, TTo>(LifeTimeManagerType lifetimeManagerType) where TTo : TFrom
        {
            var lifeTimeManager = this.lifeTimeManagerFactory.CreateLifeTimeManager(lifetimeManagerType);
            this.container.RegisterType<TFrom, TTo>(lifeTimeManager);
        }

        public void RegisterInstance<TInterface>(TInterface instance, LifeTimeManagerType lifetimeManagerType)
        {
            var lifeTimeManager = this.lifeTimeManagerFactory.CreateLifeTimeManager(lifetimeManagerType);
            this.container.RegisterInstance(instance, lifeTimeManager);
        }

        public void RegisterType<TFrom, TTo>(LifeTimeManagerType lifetimeManagerType, List<object> constructorParameters) where TTo : TFrom
        {
            var lifeTimeManager = this.lifeTimeManagerFactory.CreateLifeTimeManager(lifetimeManagerType);

            var injectionConstructor = new InjectionConstructor(constructorParameters.ToArray());

            var injectionMembers = new InjectionMember[] { injectionConstructor };

            this.container.RegisterType<TFrom, TTo>(lifeTimeManager, injectionMembers);
        }

        public void RegisterType<TType>(List<string> propertiesToInject)
        {
            var injectionProperties = new List<InjectionMember>();

            foreach (var property in propertiesToInject)
            {
                injectionProperties.Add(new InjectionProperty(property));
            }

            this.container.RegisterType<TType>(injectionProperties.ToArray());
        }

        public bool IsRegistered<TInterface>()
        {
            var result = this.container.IsRegistered<TInterface>();
            return result;
        }

        public bool IsRegistered(Type type)
        {
            var result = this.container.IsRegistered(type);
            return result;
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            var result = this.container.Resolve(typeof(TInterface)) as TInterface;
            return result;
        }

        public object Resolve(Type serviceType)
        {
            var result = this.container.Resolve(serviceType);
            return result;
        }

        public void RegisterTypeWithInjectionFactory<TInterface>(Func<IUnityContainer, Type, string, object> factoryFunction)
        {
            this.container.RegisterType<TInterface>(new InjectionFactory(factoryFunction));
        }

        public IContainer CreateChildContainer()
        {
            var childContainer = this.container.CreateChildContainer();
            var result = new Container(this.lifeTimeManagerFactory, childContainer);
            return result;
        }

        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            var result = this.container.ResolveAll(serviceType);
            return result;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
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

        public object BuildUp(Type type, object existing)
        {
            return this.container.BuildUp(type, existing);
        }

        public void ConfigureModule(IModule module)
        {
            Contract.NotNull(module, "module");

            module.Configure(this);
        }
    }
}
