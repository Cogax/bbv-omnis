namespace Omnis.ServiceHost
{
    using froko.Owin.Security.Jwt;

    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Cors;

    using Omnis.Infrastructure;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOauthWithJwtTokens();

            var rootFactory = BackendConfiguration.CreateRootFactory("Omnis");
            var backEndHttpConfiguration = BackendConfiguration.CreateHttpConfiguration(rootFactory);

            app.UseWebApi(backEndHttpConfiguration);
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR(new HubConfiguration()
                {
                    EnableDetailedErrors = true,
                    EnableJavaScriptProxies = true
                });
            });
        }
    }
}