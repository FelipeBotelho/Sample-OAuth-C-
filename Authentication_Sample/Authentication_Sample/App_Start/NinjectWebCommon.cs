[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Authentication_Sample.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Authentication_Sample.App_Start.NinjectWebCommon), "Stop")]

namespace Authentication_Sample.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.WebApi;
    using System.Web.Http;
    using System.Security.Principal;
    using Authentication_Sample.Security;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static T CreateInstance<T>()
        {
            return bootstrapper.Kernel.Get<T>();
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x => x.FromAssembliesMatching("Authentication_Sample.*.dll").SelectAllClasses().BindDefaultInterface());

            kernel.Bind<IPrincipal>().ToMethod((context) =>
            {
                if (HttpContext.Current == null || HttpContext.Current.User == null)
                    return new UnauthorizedUserPrincipal();

                return HttpContext.Current.User;
            }).InRequestScope();
        }        
    }
}
