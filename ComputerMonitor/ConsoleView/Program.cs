using System;
using System.Collections.Generic;
using DataLayer;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] arguments)
        {
            var dataManager = new FullDataManager();

            ComputerSummary computerSummary = dataManager.GetComputerSummary();
            List<string> appList = dataManager.GetApplicationList();
            List<string> hardwareList = dataManager.GetHardwareList();

            var computername = dataManager.GetMetric("computername");
            Console.WriteLine($"Computer Name: {computername}");

            var cpuUsage = dataManager.GetMetric("cpuusage");
            Console.WriteLine($"Current CPU usage: {cpuUsage}%");
            Console.ReadLine();
        }
    }
}
