﻿namespace NorthwindWebAPIServices
{
    using System.Web;
    using System.Web.Http;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.RegisterRoutes);
            GlobalConfiguration.Configure(WebApiConfig.RegisterDependencyResolver);
        }
    }
}
