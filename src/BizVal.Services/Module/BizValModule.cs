using BizVal.Framework.DependencyInjection;
using BizVal.Services.CwAggregation;
using BizVal.Services.Valuation;

namespace BizVal.Services.Module
{
    /// <summary>
    /// Dependency injection module for the BizVal services. 
    /// </summary>
    /// <seealso cref="BizVal.Framework.DependencyInjection.IModule" />
    public class BizValModule : IModule
    {
        /// <summary>
        /// Configures the specified container, registering all types needed by the module.
        /// </summary>
        /// <param name="container">The dependency injection container.</param>
        public void Configure(IContainer container)
        {
            container.RegisterType<ICompanyValuator, CompanyValuator>(LifeTimeManagerType.ContainerControlled);

            container.RegisterType<IExpertiseStandardizer, ExpertiseStandardizer>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<IAggregator, CwAggregator>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<ILamaCalculator, LamaCalculator>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<ICwCompanyValuator, CwCompanyValuator>(LifeTimeManagerType.ContainerControlled);
        }
    }
}
