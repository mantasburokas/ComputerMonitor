using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;

namespace DataLayer
{
    public class FullDataManager : DataManager
    {
        public override ComputerSummary GetComputerSummary()
        {
            ComputerSummary computerSummary = new ComputerSummary
            {
                Name = GetMetric("computername"),
                User = GetMetric("username"),
                Cpu = GetMetric("cpuname"),
                Ram = int.Parse(GetMetric("ramcapacity")),
                VideoCard = GetMetric("vganame"),
                Ip = IPAddress.Parse(GetMetric("ip")),
                CpuUsage = int.Parse(GetMetric("cpuusage")),
                RamUsage = Convert.ToInt32(double.Parse(GetMetric("ramusage"))),
                AvailableDiskSpaceGb = int.Parse(GetMetric("availablediskspace")),
                AverageDiskQueueLength = int.Parse(GetMetric("averagediskqueuelength"))
            };

            return computerSummary;
        }

        public override List<string> GetApplicationList()
        {
            return GetPropertyValuesList("Win32_Product", "Name");
        }

        private List<string> GetPropertyValuesList(string wmiClassName, string propertyName)
        {
            List<string> propertyNames = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + wmiClassName);
            foreach (ManagementObject managementObject in searcher.Get().Cast<ManagementObject>())
            {
                if (managementObject[propertyName] != null)
                {
                    propertyNames.Add(managementObject[propertyName].ToString());
                }
            }

            return propertyNames;
        }

        public override List<string> GetHardwareList()
        {
            return GetPropertyValuesList("Win32_PnPEntity", "Name");
        }
    }
}
