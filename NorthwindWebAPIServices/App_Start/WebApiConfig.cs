
namespace NorthwindWebAPIServices
{
    using System.Web.Http;
    using Microsoft.Practices.Unity;
    using NorthwindWebAPIServices.Infrastructure;
    using NorthwindWebAPIServices.Models;

    public static class WebApiConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        public static void RegisterDependencyResolver(HttpConfiguration config)
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IProductsRepository, ProductsRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(unityContainer);
        }
    }
}
