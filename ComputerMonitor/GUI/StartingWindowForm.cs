using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataLayer;

namespace GUI
{
    public partial class StartingWindowForm : Form
    {
        private const string CpuUsageSeriesName = "CPU usage";
        private const string RamUsageSeriesName = "RAM usage";
        private const string FreeDiskSpaceSeriesName = "Free Disk Space";
        private const string AvgDiskQueueLengthSeriesName = "Avg. Disk Queue Length";

        private bool exit;
        private Thread componentsUpdater;

        public event EventHandler<ComputerSummaryLabelData> ComputerMonitoringBegan;
        public event EventHandler<ChartUpdateData> TimeToRefreshChartDataPassed;

        public StartingWindowForm()
        {
            InitializeComponent();
            ConfigureCharts();

            new GuiComponentsUpdater(this);
        }

        private void ConfigureCharts()
        {
            cpuRamUsageChart.Series.Clear();
            freeDiskSpaceChart.Series.Clear();
            avgDiskQueueLengthChart.Series.Clear();

            AddSeriesToChart(cpuRamUsageChart, CpuUsageSeriesName, "%", "Time", Color.Green);
            AddSeriesToChart(cpuRamUsageChart, RamUsageSeriesName, "%", "Time", Color.Red);
            AddSeriesToChart(freeDiskSpaceChart, FreeDiskSpaceSeriesName, "GB", "Time", Color.Blue);
            AddSeriesToChart(avgDiskQueueLengthChart, AvgDiskQueueLengthSeriesName, "Requests", "Time", Color.Cyan);
        }

        private void AddSeriesToChart(Chart chart, string seriesName, string yAxisTitle, string xAxisTitle, Color color)
        {
            chart.ChartAreas[0].AxisY.Title = yAxisTitle;
            chart.ChartAreas[0].AxisX.Title = xAxisTitle;

            Series series = new Series
            {
                Name = seriesName,
                Color = color,
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Line
            };

            chart.Series.Add(series);
            chart.Invalidate();
        }

        private void BeginComputerMonitoringButton_Click(object sender, EventArgs e)
        {
            beginComputerMonitoringButton.Enabled = false;

            componentsUpdater = new Thread(o =>
            {
                FireSetComputerSummaryLabelsEvent(computerNameValueLabel, ComputerProperties.ComputerName);
                FireSetComputerSummaryLabelsEvent(usernameValueLabel, ComputerProperties.UserName);
                FireSetComputerSummaryLabelsEvent(cpuNameValueLabel, ComputerProperties.CpuName);
                FireSetComputerSummaryLabelsEvent(ramCapacityValueLabel, ComputerProperties.RamCapacity);
                FireSetComputerSummaryLabelsEvent(vgaNameValueLabel, ComputerProperties.VgaName);
                FireSetComputerSummaryLabelsEvent(ipAddressValueLabel, ComputerProperties.Ip);

                while (!exit)
                {
                    PopulateCharts();
                    Thread.Sleep(1000);
                }
            });

            componentsUpdater.Start();
        }

        private void FireSetComputerSummaryLabelsEvent(Label label, ComputerProperties computerProperty)
        {
            ComputerSummaryLabelData labelData = new ComputerSummaryLabelData()
            {
                Label = label,
                ComputerProperty = computerProperty
            };

            ComputerMonitoringBegan(this, labelData);
        }

        private void PopulateCharts()
        {
            string time = DateTime.Now.ToString("HH:mm:ss");

            FireUpdateChartEvent(cpuRamUsageChart, CpuUsageSeriesName, ComputerProperties.CpuUsage, time);
            FireUpdateChartEvent(cpuRamUsageChart, RamUsageSeriesName, ComputerProperties.RamUsage, time);
            FireUpdateChartEvent(freeDiskSpaceChart, FreeDiskSpaceSeriesName,
                ComputerProperties.AvailableDiskSpace, time);
            FireUpdateChartEvent(avgDiskQueueLengthChart, AvgDiskQueueLengthSeriesName,
                ComputerProperties.AverageDiskQueueLength, time);
        }

        private void FireUpdateChartEvent(Chart chart, string seriesName, ComputerProperties computerProperty, string time)
        {
            ChartUpdateData usageData = new ChartUpdateData()
            {
                Chart = chart,
                SeriesName = seriesName,
                ComputerProperty = computerProperty,
                Time = time
            };

            TimeToRefreshChartDataPassed(this, usageData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            exit = true;
            componentsUpdater?.Join();
        }
    }
}
