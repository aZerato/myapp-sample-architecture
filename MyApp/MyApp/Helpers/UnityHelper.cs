namespace MyApp.Helpers
{
    using IoC;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Unity Helpers for DI.
    /// </summary>
    public static class UnityHelper
    {
        #region ----- Fields -----

        /// <summary>
        /// IoC unity container.
        /// </summary>
        private static readonly IoCUnityContainer _unityContainer = new IoCUnityContainer();

        #endregion

        #region ----- Properties -----

        /// <summary>
        /// Gets the static instance of the unity IoC container.
        /// </summary>
        public static IUnityContainer Container
        {
            get { return _unityContainer; }
        }

        #endregion

        #region ----- Methods -----

        /// <summary>
        /// DI container initialization.
        /// </summary>
        public static void Initialize()
        {
            _unityContainer.Initialize();
        }

        /// <summary>
        /// Resolve injection dependency.
        /// </summary>
        /// <typeparam name="Type">Type of instance or resolve to create (interface).</typeparam>
        /// <param name="parameters">Parameters values to inject to constructor.</param>
        /// <returns>Injected type.</returns>
        public static Type Resolve<Type>(params ResolverOverride[] parameters)
        {
            return _unityContainer.Resolve<Type>(parameters);
        }

        #endregion
    }
}