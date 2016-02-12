namespace NorthwindWebAPIServices.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using Microsoft.Practices.Unity;

    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = this.container.CreateChildContainer();
            return new UnityResolver(childContainer);
        }
    }
}