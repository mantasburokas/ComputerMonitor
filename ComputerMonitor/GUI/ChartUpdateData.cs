using System;
using System.Windows.Forms.DataVisualization.Charting;
using DataLayer;

namespace GUI
{
    public class ChartUpdateData : EventArgs
    {

        public Chart Chart { get; set; }
        public string SeriesName { get; set; }
        public ComputerProperties ComputerProperty { get; set; }
        public string Time { get; set; }
    }
}
