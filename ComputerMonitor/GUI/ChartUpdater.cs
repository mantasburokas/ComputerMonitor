using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataLayer;

namespace GUI
{
    class ChartUpdater
    {

        private StartingWindowForm startingWindow;

        delegate void UpdateChartCallback(ChartUpdateData e);

        public ChartUpdater(StartingWindowForm startingWindow)
        {
            this.startingWindow = startingWindow;
            this.startingWindow.UpdateChartsEvent += UpdateChartListener;
        }

        private void UpdateChartListener(object sender, ChartUpdateData e)
        {
            UpdateChart(e);
        }

        private void UpdateChart(ChartUpdateData e)
        {
            try
            {
                if (e.Chart.InvokeRequired)
                {
                    startingWindow.Invoke(new UpdateChartCallback(UpdateChart), e);
                }
                else
                {
                    Series series = e.Chart.Series.FindByName(e.SeriesName);
                    series.Points.AddXY(e.Time, new FullDataManager().GetMetric(e.ComputerProperty.ToString()));

                    if (series.Points.Count > 5)
                    {
                        series.Points.RemoveAt(0);
                    }

                    e.Chart.Invalidate();
                }
            }
            catch (NullReferenceException ex)
            {
                Console.Write(ex.Message);
                Environment.Exit(100);
            }
        }
    }
}