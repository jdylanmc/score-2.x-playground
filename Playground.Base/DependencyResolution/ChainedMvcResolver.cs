namespace Playground.Base.DependencyResolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    // Adapted from: 
    //  http://jockstothecore.com/to-the-controller-and-back-part-3-di-and-multitenancy/
    //  http://www.seanholmesby.com/safe-dependency-injection-for-mvc-and-webapi-within-sitecore/
    public class ChainedMvcResolver : IDependencyResolver
    {
        IDependencyResolver _fallbackResolver;
        IDependencyResolver _newResolver;

        public ChainedMvcResolver(IDependencyResolver newResolver, IDependencyResolver fallbackResolver)
        {
            _newResolver = newResolver;
            _fallbackResolver = fallbackResolver;
        }

        public object GetService(Type serviceType)
        {
            object result = null;

            result = _newResolver.GetService(serviceType);
            if (result != null)
            {
                return result;
            }

            return _fallbackResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> result = Enumerable.Empty<object>();

            result = _newResolver.GetServices(serviceType);
            if (result.Any())
            {
                return result;
            }

            return _fallbackResolver.GetServices(serviceType);
        }
    }
}