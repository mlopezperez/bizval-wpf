
using Microsoft.Practices.Unity;

namespace BizVal.Framework.DependencyInjection
{
    public interface ILifeTimeManagerFactory
    {
        LifetimeManager CreateLifeTimeManager(LifeTimeManagerType type);
    }
}
