namespace Playground.Base.Pipelines
{
    using SimpleInjector.Integration.Web.Mvc;
    using Sitecore.Pipelines;
    using System.Web.Http;
    using DependencyResolution;
    using PG.Consumer.Base.DependencyResolution.Resolvers;
    using Services;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.WebApi;
    using Sitecore.Mvc.Helpers;


    public class RegisterIoC
    {
        // should either replace Sitecore's InitializeControllerFactory pipeline, or come after depending on sitecore version.  For 8.0 and lower, replace, for 8.1 and higher, patch after.  
        // initializes a chain of controller factories with SimpleInjector as a dependency resolver
        public void Process(PipelineArgs args)
        {
            var x = new TypeHelper();

            var container = GetDependencyContainer();

            // register container with MVC
            System.Web.Mvc.IDependencyResolver chainedMvcResolver =
                new ChainedMvcResolver(new SimpleInjectorDependencyResolver(container),
                    System.Web.Mvc.DependencyResolver.Current);
            System.Web.Mvc.DependencyResolver.SetResolver(chainedMvcResolver);

            System.Web.Http.Dependencies.IDependencyResolver chainedWebApiResolver =
                new ChainedWebApiResolver(new SimpleInjectorWebApiDependencyResolver(container),
                    GlobalConfiguration.Configuration.DependencyResolver);
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = chainedWebApiResolver;
        }

        private SimpleInjector.Container GetDependencyContainer()
        {
            var container = new SimpleInjector.Container();

            container.Options.ConstructorResolutionBehavior = new SimplestConstructorBehavior();
            container.Register(typeof(IExampleService), typeof(ExampleService), new WebRequestLifestyle());

            return container;
        }
    }
}
