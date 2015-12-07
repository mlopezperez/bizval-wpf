namespace BizVal.Framework.DependencyInjection
{
    public enum LifeTimeManagerType
    {
        ContainerControlled,
        HierarchicalLifetime,
        PerResolveLifetime,
        ExternallyControlledLifetime,
        PerThreadLifetime,
        TransientLifetime,
    }
}
