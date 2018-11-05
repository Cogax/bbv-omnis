namespace Omnis.Devices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    [Authorize]
    public class DeviceController : ApiControllerWithRootFactory
    {
        private static readonly List<Device> Devices = new List<Device>
        {
            new Device("Device1", "KarlFischer1.png"),
            new Device("Device2", "KarlFischer2.png"),
            new Device("Device3", "KarlFischer3.png"),
        };

        public DeviceController(RootFactory rootFactory) : base(rootFactory)
        {
        }

        [HttpGet]
        [Route("api/v1/devices")]
        public Task<HttpResponseMessage> GetAll()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK, Devices);

            return Task.FromResult(response);
        }

        [HttpGet]
        [Route("api/v1/devices/enabled")]
        public Task<HttpResponseMessage> GetEnabled()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK, Devices.Where(d => d.IsEnabled));

            return Task.FromResult(response);
        }

        [HttpPost]
        [Route("api/v1/{deviceName}/enable")]
        public Task<HttpResponseMessage> Enable(string deviceName)
        {
            Devices.SingleOrDefault(d => d.DeviceName == deviceName)?.Enable();
            var response = this.Request.CreateResponse(HttpStatusCode.OK, Devices);

            return Task.FromResult(response);
        }

        [HttpPost]
        [Route("api/v1/{deviceName}/disable")]
        public Task<HttpResponseMessage> Disable(string deviceName)
        {
            Devices.SingleOrDefault(d => d.DeviceName == deviceName)?.Disable();
            var response = this.Request.CreateResponse(HttpStatusCode.OK, Devices);

            return Task.FromResult(response);
        }
    }
}