using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.IO.Ports;

namespace Toolbox.Acquisition
{
    public class SerialFunctions
    {
        /// <summary>
        /// Get the available friendly serial devices names
        /// </summary>
        /// <returns>List with the description</returns>
        public static List<string> GetFriendlyPortNames()
        {
            // This piece of code was adapted from threads:
            // stackoverflow.com/questions/12813151/
            // forum.arduino.cc/index.php?topic=454685.0

            List<ManagementObject> listObj = new List<ManagementObject>();
            List<string> AvailablePorts = new List<string>();
            string[] portNames = SerialPort.GetPortNames();
            try
            {
                // get only devices that are working properly."
                string query = "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                listObj = searcher.Get().Cast<ManagementObject>().ToList();
                searcher.Dispose(); // I'm not sure if the garbage collector handles this automatically
            }
            catch
            {
                return null;
            }

            foreach (ManagementObject obj in listObj)
            {
                object captionObj = obj["Caption"];
                if (captionObj != null)
                {
                    string caption = captionObj.ToString();
                    if (caption.Contains("(COM"))
                    {
                        AvailablePorts.Add(caption);
                    }
                }
            }
            AvailablePorts.Sort((a, b) => string.Compare(a, b));
            return AvailablePorts;
        }
    }
}
