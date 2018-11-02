namespace Omnis.Infrastructure
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Newtonsoft.Json.Serialization;

    using Omnis.Common;
    using Omnis.Common.Owin;

    public class BackendConfiguration
    {
        public static HttpConfiguration CreateHttpConfiguration(RootFactory rootFactory)
        {
            var configuration = new HttpConfiguration
            {
                DependencyResolver = new ApiControllerWithRootFactoryResolver(rootFactory)
            };

            configuration.MapHttpAttributeRoutes();
            configuration.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            configuration.Filters.Add(new ExceptionFilterAttribute());
            configuration.Filters.Add(new LoggingFilterAttribute());
            configuration.EnsureInitialized();

            return configuration;
        }

        public static RootFactory CreateRootFactory(string connectionStringName)
        {
            return new RootFactory(
                new SqlConnectionFactory(connectionStringName));
        }
    }
}