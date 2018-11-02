namespace Omnis.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    public sealed class ApiControllerWithRootFactoryResolver : IDependencyResolver
    {
        private readonly RootFactory rootFactory;

        public ApiControllerWithRootFactoryResolver(RootFactory rootFactory)
        {
            this.rootFactory = rootFactory;
        }

        public void Dispose()
        {
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (typeof(ApiControllerWithRootFactory).IsAssignableFrom(serviceType))
            {
                return Activator.CreateInstance(serviceType, this.rootFactory);
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }
}