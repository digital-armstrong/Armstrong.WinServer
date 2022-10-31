using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Armstrong.WinServer.Classes
{
    public static class ComPortHelper
    {
        public static string GetSerialPortName()
        {
            const string OVEN_AC4_PNPID = "VID_1555&PID_0004";
            const string OVEN_AC4M_PNPID = "VID_10C4&PID_EA60";

            var devices = GetConnectionDevice();

            return devices
                .Where(x => x.DeviceId.Contains(OVEN_AC4M_PNPID) || x.DeviceId.Contains(OVEN_AC4_PNPID))
                .Select(x => x.Device)
                .FirstOrDefault();
        }

        private static List<ComDevice> GetConnectionDevice()
        {
            var deviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_SerialPort");
            var devices = new List<ComDevice>();

            foreach (var serialDevice in deviceSearcher.Get())
            {
                var device = new ComDevice
                {
                    Device = serialDevice.Properties["DeviceID"].Value.ToString(),
                    DeviceId = serialDevice.Properties["PNPDeviceID"].Value.ToString()
                };
                devices.Add(device);
            }
            return devices;
        }
    }

    public class ComDevice
    {
        public string Device { get; set; }
        public string DeviceId { get; set; }
    }
}