using Funq;
using RestAPI.ServiceStackFolder;
using ServiceStack;
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
            SetConfig(new HostConfig { HandlerFactoryPath = "api" });
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
    }
}
