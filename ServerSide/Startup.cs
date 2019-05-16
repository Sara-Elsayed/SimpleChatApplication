using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;


[assembly: OwinStartup(typeof(ServerSide.Startup))]

namespace ServerSide
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", config =>
            {
                config.UseCors(CorsOptions.AllowAll);
                config.RunSignalR();
            });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
