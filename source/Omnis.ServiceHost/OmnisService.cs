namespace Omnis.ServiceHost
{
    using System;

    using Microsoft.Owin.Hosting;

    using Omnis.Infrastructure;

    public class OmnisService
    {
        private IDisposable app;

        public void Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            var options = new StartOptions($"http://+:{AppConfig.ServicePort}")
            {
                ServerFactory = "Microsoft.Owin.Host.HttpListener"
            };

            this.app = WebApp.Start<Startup>(options);
        }

        public void Stop()
        {
            this.app.Dispose();
        }
    }
}