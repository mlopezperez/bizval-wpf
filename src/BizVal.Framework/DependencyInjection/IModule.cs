namespace BizVal.Framework.DependencyInjection
{
    /// <summary>
    /// Interface to implement modularity in $Qumram$ applications.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Configures the specified container, registering all types needed by the module.
        /// </summary>
        /// <param name="container">The dependency injection container.</param>
        void Configure(IContainer container);
    }
}
