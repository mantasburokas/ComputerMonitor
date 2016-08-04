using System;
using DataLayer;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] arguments)
        {
            var dataManager = new FullDataManager();

            var computername = dataManager.GetMetric("computername");
            Console.WriteLine($"Computer Name: {computername}");

            var cpuUsage = dataManager.GetMetric("cpuusage");
            Console.WriteLine($"Current CPU usage: {cpuUsage}%");
            Console.ReadLine();
        }
    }
}
