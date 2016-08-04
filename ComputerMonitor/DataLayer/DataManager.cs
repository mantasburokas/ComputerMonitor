using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace DataLayer
{
    public abstract class DataManager
    {
        public virtual string GetMetric(string type)
        {
            var value = "";
            switch (type.ToLower())
            {
                   
                case "cpuusage":
                    var searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
                    foreach (var obj in searcher.Get().Cast<ManagementObject>())
                    {
                        value = obj["PercentProcessorTime"].ToString();
                        break;
                    }
                    break;

                case "computername":
                    value = Environment.MachineName;
                    break;
                default:
                    value = "";
                    break;

            }

            return value;
        }

        public abstract ComputerSummary GetComputerSummary();
        public abstract List<string> GetApplicationList();
        public abstract List<string> GetHardwareList();
    }
}
