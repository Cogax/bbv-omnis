namespace Omnis.Devices
{
    using System;

    public class HeartBeat
    {
        public HeartBeat(string deviceName, string connectionState)
        {
            this.DeviceName = deviceName;
            this.ConnectionState = connectionState;
            this.TimeStamp = DateTime.Now;
        }

        public string DeviceName { get; }

        public string ConnectionState { get; }

        public DateTime TimeStamp { get; }
    }
}