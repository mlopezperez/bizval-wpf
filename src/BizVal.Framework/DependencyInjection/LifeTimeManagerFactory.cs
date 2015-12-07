using Microsoft.Practices.Unity;

namespace BizVal.Framework.DependencyInjection
{
    public class LifeTimeManagerFactory : ILifeTimeManagerFactory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Clients are responsibles for dispose the object.")]
        public LifetimeManager CreateLifeTimeManager(LifeTimeManagerType type)
        {
            LifetimeManager result = null;
            switch (type)
            {
                case LifeTimeManagerType.ContainerControlled:
                    result = new ContainerControlledLifetimeManager();
                    break;
                case LifeTimeManagerType.HierarchicalLifetime:
                    result = new HierarchicalLifetimeManager();
                    break;
                case LifeTimeManagerType.PerResolveLifetime:
                    result = new PerResolveLifetimeManager();
                    break;
                case LifeTimeManagerType.ExternallyControlledLifetime:
                    result = new ExternallyControlledLifetimeManager();
                    break;
                case LifeTimeManagerType.PerThreadLifetime:
                    result = new PerThreadLifetimeManager();
                    break;
                case LifeTimeManagerType.TransientLifetime:
                    result = new TransientLifetimeManager();
                    break;
            }

            return result;
        }
    }
}
