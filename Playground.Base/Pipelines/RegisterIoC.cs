namespace Playground.Base.Pipelines
{
    using SimpleInjector.Integration.Web.Mvc;
    using Sitecore.Pipelines;
    using DependencyResolution;


    public class RegisterIoC
    {
        // should either replace Sitecore's InitializeControllerFactory pipeline, or come after depending on sitecore version.  For 8.0 and lower, replace, for 8.1 and higher, patch after.  
        // initializes a chain of controller factories with SimpleInjector as a dependency resolver
        public void Process(PipelineArgs args)
        {
            var container = GetDependencyContainer();

            // register container with MVC
            System.Web.Mvc.IDependencyResolver chainedMvcResolver =
                new ChainedMvcResolver(new SimpleInjectorDependencyResolver(container),
                    System.Web.Mvc.DependencyResolver.Current);
            System.Web.Mvc.DependencyResolver.SetResolver(chainedMvcResolver);
        }

        private SimpleInjector.Container GetDependencyContainer()
        {
            var container = new SimpleInjector.Container();

            return container;
        }
    }
}
