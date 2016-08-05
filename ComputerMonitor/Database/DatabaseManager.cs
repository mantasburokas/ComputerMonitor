using System;
using System.Collections.ObjectModel;
using System.Linq;
using DataLayer;

namespace Database
{
    public class DatabaseManager
    {

        private DataManager dataManager = new FullDataManager();

        public DatabaseManager()
        {
            using (MetricsContext context = new MetricsContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void AddComputer(object sender, EventArgs e)
        {
            using (MetricsContext context = new MetricsContext())
            {
                string computerName = dataManager.GetMetric(ComputerProperties.ComputerName.ToString());

                if (context.ComputerDetails.FirstOrDefault(c => string.Equals(c.Name, computerName)) == null)
                {
                    ComputerDetail computerDetails = new ComputerDetail()
                    {
                        Name = computerName,
                        User = dataManager.GetMetric(ComputerProperties.UserName.ToString()),
                        Cpu = dataManager.GetMetric(ComputerProperties.CpuName.ToString()),
                        Ram = int.Parse(dataManager.GetMetric(ComputerProperties.RamCapacity.ToString())),
                        VideoCard = dataManager.GetMetric(ComputerProperties.VgaName.ToString()),
                        Ip = dataManager.GetMetric(ComputerProperties.Ip.ToString())
                    };
                    context.ComputerDetails.Add(computerDetails);
                }

                context.SaveChanges();
            }
        }

        public void AddUsageData(object sender, EventArgs e)
        {
            using (MetricsContext context = new MetricsContext())
            {
                string computerName = dataManager.GetMetric(ComputerProperties.ComputerName.ToString());
                ComputerDetail computerDetail =
                    context.ComputerDetails.FirstOrDefault(c => string.Equals(c.Name, computerName));

                if (computerDetail != null)
                {
                    UsageData usageData = new UsageData()
                    {
                        CpuUsage = int.Parse(dataManager.GetMetric(ComputerProperties.CpuUsage.ToString())),
                        RamUsage =
                            Convert.ToInt32(double.Parse(dataManager.GetMetric(ComputerProperties.RamUsage.ToString()))),
                        AvailableDiskSpaceGb =
                            int.Parse(dataManager.GetMetric(ComputerProperties.AvailableDiskSpace.ToString())),
                        AverageDiskQueueLength =
                            int.Parse(dataManager.GetMetric(ComputerProperties.AverageDiskQueueLength.ToString())),
                        Time = DateTime.Now
                    };

                    if (computerDetail.UsageDataCollection == null)
                    {
                        computerDetail.UsageDataCollection = new Collection<UsageData>() { usageData };
                    }
                    else
                    {
                        computerDetail.UsageDataCollection.Add(usageData);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
