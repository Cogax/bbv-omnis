namespace Omnis.Devices
{
    using System;
    using System.Threading;

    public class Device
    {
        private Thread runningThread;

        public Device(
            string deviceName,
            string imageName)
        {
            this.DeviceName = deviceName;
            this.ImageName = $"assets/{imageName}";
        }

        public string DeviceName { get; }

        public string ImageName { get; }

        public bool IsEnabled { get; private set; }

        public void Enable()
        {
            this.IsEnabled = true;
            this.runningThread = new Thread(this.Start);
            this.runningThread.Start();
        }

        public void Disable()
        {
            this.IsEnabled = false;
            this.runningThread?.Abort();
        }

        private void Start()
        {
            var rnd = new Random();

            while (Thread.CurrentThread.IsAlive)
            {
                try
                {
                    DeviceHub.ReportStatus(this.DeviceName, rnd.Next(100) > 90 ? "OFFLINE" : "ONLINE");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
                catch (ThreadAbortException)
                {
                }
            }
        }
    }
}