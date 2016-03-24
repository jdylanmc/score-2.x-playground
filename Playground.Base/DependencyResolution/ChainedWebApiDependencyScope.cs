namespace PG.Consumer.Base.DependencyResolution.Resolvers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    // Adapted from: 
    //  http://jockstothecore.com/to-the-controller-and-back-part-3-di-and-multitenancy/
    //  http://www.seanholmesby.com/safe-dependency-injection-for-mvc-and-webapi-within-sitecore/
    public class ChainedWebApiDependencyScope : IDependencyScope
    {
        protected IDependencyResolver fallbackResolver;
        protected IDependencyResolver newResolver;

        public ChainedWebApiDependencyScope(IDependencyResolver newResolver, IDependencyResolver fallbackResolver)
        {
            this.newResolver = newResolver;
            this.fallbackResolver = fallbackResolver;
        }

        public object GetService(Type serviceType)
        {
            object result = null;

            result = newResolver.GetService(serviceType);
            if (result != null)
            {
                return result;
            }

            return fallbackResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> result = Enumerable.Empty<object>();
            result = newResolver.GetServices(serviceType);
            if (result.Any())
            {
                return result;
            }

            return fallbackResolver.GetServices(serviceType);
        }

        public void Dispose()
        {
            try
            {
                newResolver.Dispose();
            }
            catch
            {
            }

            try
            {
                fallbackResolver.Dispose();
            }
            catch
            {
            }
        }
    }
}