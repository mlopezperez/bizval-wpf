using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace BizVal.Framework.DependencyInjection
{
    public interface IContainer : IDisposable
    {
        void RegisterType<TFrom, TTo>(LifeTimeManagerType lifetimeManagerType) where TTo : TFrom;

        void RegisterTypeIf<TFrom, TTo>(LifeTimeManagerType lifetimeManagerType) where TTo : TFrom;

        void RegisterType<TFrom, TTo>(LifeTimeManagerType lifetimeManagerType, List<object> constructorParameters) where TTo : TFrom;

        void RegisterInstance<TInterface>(TInterface instance, LifeTimeManagerType lifetimeManagerType);

        void RegisterType<TType>(List<string> propertiesToInject);

        void RegisterTypeWithInjectionFactory<TInterface>(Func<IUnityContainer, Type, string, object> factoryFunction);

        bool IsRegistered<TInterface>();

        bool IsRegistered(Type type);

        TInterface Resolve<TInterface>() where TInterface : class;

        object Resolve(Type serviceType);

        IContainer CreateChildContainer();

        IEnumerable<object> ResolveAll(Type serviceType);

        object BuildUp(Type type, object existing);


    }
}
