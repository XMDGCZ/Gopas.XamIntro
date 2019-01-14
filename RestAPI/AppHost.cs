using Funq;
using RestAPI.ServiceStackFolder;
using ServiceStack;
using ServiceStack.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
               // HandlerFactoryPath = "api",
            });
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
        /// <summary>
        /// Bug fix index out of range exception on /api
        /// </summary>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public override RouteAttribute[] GetRouteAttributes(System.Type requestType)
        {
            var routes = base.GetRouteAttributes(requestType);
            routes.Each(x => x.Path = "/api" + x.Path);
            return routes;
        }
    }
}
