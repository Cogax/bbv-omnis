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
            var options = new StartOptions(string.Format("http://+:{0}", AppConfig.ServicePort))
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