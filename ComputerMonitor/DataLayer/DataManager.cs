using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;

namespace DataLayer
{
    public abstract class DataManager
    {
        private const int BytesInGb = 1000000000;
        private const int BytesInKb = 1000000;

        public virtual string GetMetric(string type)
        {
            string metricValue = "";

            switch ((ComputerProperties) Enum.Parse(typeof(ComputerProperties), type, true))
            {
                case ComputerProperties.ComputerName:
                    metricValue = Environment.MachineName;
                    break;
                case ComputerProperties.UserName:
                    metricValue = Environment.UserName;
                    break;
                case ComputerProperties.CpuName:
                    metricValue = GetPropertyValue("Win32_Processor", "name");
                    break;
                case ComputerProperties.RamCapacity:
                    metricValue = GetPropertyValueAdded("Win32_PhysicalMemory", "capacity")/BytesInGb + "";
                    break;
                case ComputerProperties.VgaName:
                    metricValue = GetPropertyValue("Win32_VideoController", "name");
                    break;
                case ComputerProperties.Ip:
                    IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            metricValue = ip.ToString();
                        }
                    }
                    break;
                case ComputerProperties.CpuUsage:
                    metricValue = GetPropertyValue("Win32_PerfFormattedData_PerfOS_Processor", "PercentProcessorTime");
                    break;
                case ComputerProperties.RamUsage:
                    double freeMemory = int.Parse(GetPropertyValue("Win32_OperatingSystem", "FreePhysicalMemory")) /
                        Convert.ToDouble(BytesInKb);

                    int availableMemory = int.Parse(GetMetric("ramcapacity"));
                    double usedMemory = availableMemory - freeMemory;

                    metricValue = usedMemory*100/availableMemory + "";
                    break;
                case ComputerProperties.AvailableDiskSpace:
                    metricValue = GetPropertyValueAdded("Win32_Volume", "FreeSpace") / BytesInGb + "";
                    break;
                case ComputerProperties.AverageDiskQueueLength:
                    metricValue = GetPropertyValueAdded("Win32_PerfFormattedData_PerfDisk_PhysicalDisk", "AvgDiskQueueLength") + "";
                    break;
            }

            return metricValue;
        }

        private string GetPropertyValue(string wmiClassName, string propertyName)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + wmiClassName);

            string value = null;
            foreach (ManagementObject managementObject in searcher.Get().Cast<ManagementObject>())
            {
                if (managementObject[propertyName] != null)
                {
                    value = managementObject[propertyName].ToString();
                }
            }

            return value;
        }

        private long GetPropertyValueAdded(string wmiClassName, string propertyName)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + wmiClassName);
            long value = 0;
            foreach (ManagementObject managementObject in searcher.Get().Cast<ManagementObject>())
            {
                if (managementObject[propertyName] != null)
                {
                    value += long.Parse(managementObject[propertyName].ToString());
                }
            }
            return value;
        }

        public abstract ComputerSummary GetComputerSummary();
        public abstract List<string> GetApplicationList();
        public abstract List<string> GetHardwareList();
    }
}
