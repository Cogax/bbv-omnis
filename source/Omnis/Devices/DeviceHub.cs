namespace Omnis.Devices
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("devices")]
    public class DeviceHub : Hub
    {
        private static readonly IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<DeviceHub>();

        public static void ReportStatus(string deviceName, string connectionState)
        {
            HubContext.Clients.Group(deviceName).HeartBeat(new HeartBeat(deviceName, connectionState));
        }

        public void Register(string deviceName)
        {
            HubContext.Groups.Add(this.Context.ConnectionId, deviceName);
        }

        public void UnRegister(string deviceName)
        {
            HubContext.Groups.Remove(this.Context.ConnectionId, deviceName);
        }
    }
}