using System;
using System.Windows.Forms;
using DataLayer;

namespace GUI
{
    public class ComputerSummaryLabelData : EventArgs
    {

        public Label Label { get; set; }
        public ComputerProperties ComputerProperty { get; set; }
    }
}
