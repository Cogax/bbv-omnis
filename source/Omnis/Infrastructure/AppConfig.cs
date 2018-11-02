namespace Omnis.Infrastructure
{
    using System.Configuration;

    public static class AppConfig
    {
        public static int ServicePort => int.Parse(ConfigurationManager.AppSettings.Get("ServicePort"));
    }
}