namespace PG.Consumer.Base.DependencyResolution.Resolvers
{
    using System.Web.Http.Dependencies;

    // Adapted from: 
    //  http://jockstothecore.com/to-the-controller-and-back-part-3-di-and-multitenancy/
    //  http://www.seanholmesby.com/safe-dependency-injection-for-mvc-and-webapi-within-sitecore/
    public class ChainedWebApiResolver : ChainedWebApiDependencyScope, IDependencyResolver
    {
        public ChainedWebApiResolver(IDependencyResolver newResolver, IDependencyResolver currentResolver)
            : base(newResolver, currentResolver)
        {
            this.newResolver = newResolver;
            this.fallbackResolver = currentResolver;
        }

        public IDependencyScope BeginScope()
        {
            return new ChainedWebApiDependencyScope(newResolver, fallbackResolver);
        }
    }
}
