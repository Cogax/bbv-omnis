namespace Omnis.Values
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class ValuesController : ApiControllerWithRootFactory
    {
        public ValuesController(RootFactory rootFactory) : base(rootFactory)
        {
        }

        [Authorize]
        [Route("api/v1/values")]
        public Task<HttpResponseMessage> Get()
        {
            var content = new[] { 1, 2, 3 };
            var response = this.Request.CreateResponse(HttpStatusCode.OK, content);

            return Task.FromResult(response);
        }
    }
}