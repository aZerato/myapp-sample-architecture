namespace MyApp.IoC
{
    using Microsoft.Practices.Unity;
    using CrossCutting;
    using Domain.SampleModule.Services;

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


            // Infrastructure Layer.
            this.RegisterType<ICacheManager, CacheManager>(new ContainerControlledLifetimeManager());
        }
    }
}
