namespace Omnis.ServiceHost
{
    using Topshelf;

    public class Program
    {
        private const string ServiceName = "bbv.OmnisService";

        public static void Main(string[] args)
        {
            HostFactory.Run(configure =>
            {
                configure.RunAsNetworkService();

                configure.Service<OmnisService>(service =>
                {
                    service.ConstructUsing(s => new OmnisService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                configure.RunAsLocalSystem();
                configure.SetServiceName(ServiceName);
                configure.SetDisplayName(ServiceName);
                configure.SetDescription(ServiceName);
            });
        }
    }
}
