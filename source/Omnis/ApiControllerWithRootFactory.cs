namespace Omnis
{
    using System.Web.Http;

    public abstract class ApiControllerWithRootFactory : ApiController
    {
        private readonly RootFactory rootFactory;

        protected ApiControllerWithRootFactory(RootFactory rootFactory)
        {
            this.rootFactory = rootFactory;
        }

        protected PerRequestFactory PerRequestFactory => this.rootFactory.CreatePerRequestFactory();
    }
}