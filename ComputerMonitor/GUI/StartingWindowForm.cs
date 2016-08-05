using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
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

        private readonly DataManager dataManager = new FullDataManager();

        private Thread chartUpdaterThread;

        delegate void SetLabelTextCallback(string value, Label label);

        public event EventHandler<ChartUpdateData> UpdateChartsEvent;

        public StartingWindowForm()
        {
            InitializeComponent();
            ConfigureCharts();
            new ChartUpdater(this);
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

        private void showComputerSummaryButton_Click(object sender, EventArgs e)
        {
            showComputerSummaryButton.Enabled = false;
            PopulateCharts();

            ComputerSummary computerSummary;
            chartUpdaterThread = new Thread(o =>
            {
                computerSummary = dataManager.GetComputerSummary();

                SetText(computerSummary.Name, computerNameValueLabel);
                SetText(computerSummary.User, usernameValueLabel);
                SetText(computerSummary.Cpu, cpuNameValueLabel);
                SetText(computerSummary.Ram + " GB", ramCapacityValueLabel);
                SetText(computerSummary.VideoCard, vgaNameValueLabel);
                SetText(computerSummary.Ip.ToString(), ipAddressValueLabel);
            });

            chartUpdaterThread.Start();
        }

        private void PopulateCharts()
        {
            new Thread(() =>
            {
                while (!exit)
                {
                    Console.WriteLine("working");

                    string time = DateTime.Now.ToString("HH:mm:ss");

                    FireUpdateChartEvents(cpuRamUsageChart, CpuUsageSeriesName, ComputerProperties.CpuUsage, time);
                    FireUpdateChartEvents(cpuRamUsageChart, RamUsageSeriesName, ComputerProperties.RamUsage, time);
                    FireUpdateChartEvents(freeDiskSpaceChart, FreeDiskSpaceSeriesName, 
                        ComputerProperties.AvailableDiskSpace, time);
                    FireUpdateChartEvents(avgDiskQueueLengthChart, AvgDiskQueueLengthSeriesName, 
                        ComputerProperties.AverageDiskQueueLength, time);

                    Thread.Sleep(1000);
                }
            }).Start();
        }

        private void FireUpdateChartEvents(Chart chart, string seriesName, ComputerProperties computerProperty, string time)
        {
            ChartUpdateData usageData = new ChartUpdateData()
            {
                Chart = chart,
                SeriesName = seriesName,
                ComputerProperty = computerProperty,
                Time = time
            };

            UpdateChartsEvent(this, usageData);
        }

        private void SetText(string text, Label label)
        {
            if (label.InvokeRequired)
            {
                Invoke(new SetLabelTextCallback(SetText), text, label);
            }
            else
            {
                label.Text = text;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            exit = true;
            base.OnFormClosing(e);
        }
    }
}
