namespace MyApp.IoC
{
    using CrossCutting;
    using Data;
    using Data.Core;
    using Domain.Core;
    using Domain.SampleModule.Aggregates;
    using Domain.SampleModule.Services;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// DI container.
    /// </summary>
    public class IoCUnityContainer : UnityContainer
    {
        public IoCUnityContainer()
        {
        }

        /// <summary>
        /// Initialize Unity container.
        /// </summary>
        public void Initialize()
        {
            // https://msdn.microsoft.com/en-us/library/ff647854.aspx : about the LifeTime manager.

            // Domain Layer.
            this.RegisterType<IBasicSampleService, BasicSampleService>();
            this.RegisterType<ISecondaryBasicSampleService, SecondaryBasicSampleService>();

            // Data Layer.
            this.RegisterType<IUnitOfWork, UnitOfWorkContext>();
            this.RegisterType<IRepository<SampleData>, Repository<SampleData>>();

            // Infrastructure Layer.
            this.RegisterType<ICacheManager, CacheManager>(new ContainerControlledLifetimeManager());
        }
    }
}
