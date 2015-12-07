using BizVal.Framework.DependencyInjection;
using BizVal.Services.CwAggregation;
using BizVal.Services.Valuation;

namespace BizVal.Services.Module
{
    public class BizValModule : IModule
    {
        public void Configure(IContainer container)
        {
            container.RegisterType<ICompanyValuator, CompanyValuator>(LifeTimeManagerType.ContainerControlled);

            container.RegisterType<IExpertiseStandardizer, ExpertiseStandardizer>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<ICwAggregator, CwAggregator>(LifeTimeManagerType.ContainerControlled);
            container.RegisterType<ILamaCalculator, LamaCalculator>(LifeTimeManagerType.ContainerControlled);
        }
    }
}
