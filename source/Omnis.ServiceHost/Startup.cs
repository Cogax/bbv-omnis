namespace Omnis.ServiceHost
{
    using froko.Owin.Security.Jwt;

    using Microsoft.Owin.Cors;

    using Omnis.Infrastructure;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            log4net.Config.XmlConfigurator.Configure();

            app.UseOauthWithJwtTokens();
            app.UseCors(CorsOptions.AllowAll);

            var rootFactory = BackendConfiguration.CreateRootFactory("Omnis");
            var backEndHttpConfiguration = BackendConfiguration.CreateHttpConfiguration(rootFactory);
            app.UseWebApi(backEndHttpConfiguration);
        }
    }
}