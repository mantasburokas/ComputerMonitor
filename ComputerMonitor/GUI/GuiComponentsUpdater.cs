using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Database;
using DataLayer;

namespace GUI
{
    class GuiComponentsUpdater
    {

        private DataManager dataManager = new FullDataManager();

        private StartingWindowForm startingWindow;

        delegate void SetLabelTextCallback(string value, Label label);
        delegate void UpdateChartCallback(ChartUpdateData e);

        public GuiComponentsUpdater(StartingWindowForm startingWindow)
        {
            this.startingWindow = startingWindow;
            this.startingWindow.TimeToRefreshChartDataPassed += UpdateChartListener;
            this.startingWindow.ComputerMonitoringBegan += SetComputerSummaryLabelsListener;

            DatabaseManager databaseManager = new DatabaseManager();
            this.startingWindow.ComputerMonitoringBegan += databaseManager.AddComputer;
            this.startingWindow.TimeToRefreshChartDataPassed += databaseManager.AddUsageData;
        }

        private void SetComputerSummaryLabelsListener(object sender, ComputerSummaryLabelData e)
        {
            SetComputerSummaryLabels(e);
        }

        private void SetComputerSummaryLabels(ComputerSummaryLabelData e)
        {
            SetText(dataManager.GetMetric(e.ComputerProperty.ToString()), e.Label);
        }

        private void SetText(string text, Label label)
        {
            if (label.InvokeRequired)
            {
                startingWindow.Invoke(new SetLabelTextCallback(SetText), text, label);
            }
            else
            {
                label.Text = text;
            }
        }

        private void UpdateChartListener(object sender, ChartUpdateData e)
        {
            UpdateChart(e);
        }

        private void UpdateChart(ChartUpdateData e)
        {
            if (e.Chart.InvokeRequired)
            {
                startingWindow.Invoke(new UpdateChartCallback(UpdateChart), e);
            }
            else
            {
                Series series = e.Chart.Series.FindByName(e.SeriesName);
                series.Points.AddXY(e.Time, dataManager.GetMetric(e.ComputerProperty.ToString()));

                if (series.Points.Count > 5)
                {
                    series.Points.RemoveAt(0);
                }

                e.Chart.Invalidate();
            }
        }
    }
}