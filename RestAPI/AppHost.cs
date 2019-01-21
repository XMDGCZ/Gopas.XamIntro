using Funq;
using RestAPI.APIService;
using ServiceStack;
using System;

namespace RestAPI
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("RestAPI Simple DTO Services", typeof(SimpleDTOService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig {    
            // IndexOutOfRangeException on application /api 
            // HandlerFactoryPath = "api",
            });
            
            //Logs are available at  / requestlogs
            // Plugins.Add(new RequestLogsFeature());
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
        /// <summary>
        /// Bug fix index out of range exception on /api
        /// All routes will use /api by default
        /// </summary>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public override RouteAttribute[] GetRouteAttributes(Type requestType)
        {
            var routes = base.GetRouteAttributes(requestType);
            routes.Each(x => x.Path = "/api" + x.Path);
            return routes;
        }
    }
}
