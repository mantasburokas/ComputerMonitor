using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    partial class StartingWindowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.titleLabel = new System.Windows.Forms.Label();
            this.beginComputerMonitoringButton = new System.Windows.Forms.Button();
            this.computerNameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.cpuNameLabel = new System.Windows.Forms.Label();
            this.ramCapacityLabel = new System.Windows.Forms.Label();
            this.vgaNameLabel = new System.Windows.Forms.Label();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.computerNameValueLabel = new System.Windows.Forms.Label();
            this.usernameValueLabel = new System.Windows.Forms.Label();
            this.cpuNameValueLabel = new System.Windows.Forms.Label();
            this.ramCapacityValueLabel = new System.Windows.Forms.Label();
            this.vgaNameValueLabel = new System.Windows.Forms.Label();
            this.ipAddressValueLabel = new System.Windows.Forms.Label();
            this.computerSummaryLabel = new System.Windows.Forms.Label();
            this.freeSpaceAvgQLengthLabel = new System.Windows.Forms.Label();
            this.freeDiskSpaceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.avgDiskQueueLengthChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cpuRamUsageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cpuRamUsageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.freeDiskSpaceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avgDiskQueueLengthChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuRamUsageChart)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.titleLabel.Location = new System.Drawing.Point(378, 50);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(443, 31);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Ultimate Computer Information Tool";
            // 
            // beginComputerMonitoringButton
            // 
            this.beginComputerMonitoringButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.beginComputerMonitoringButton.Location = new System.Drawing.Point(100, 125);
            this.beginComputerMonitoringButton.Name = "beginComputerMonitoringButton";
            this.beginComputerMonitoringButton.Size = new System.Drawing.Size(500, 30);
            this.beginComputerMonitoringButton.TabIndex = 1;
            this.beginComputerMonitoringButton.Text = "Begin Computer Monitoring";
            this.beginComputerMonitoringButton.UseVisualStyleBackColor = true;
            this.beginComputerMonitoringButton.Click += new System.EventHandler(this.BeginComputerMonitoringButton_Click);
            // 
            // computerNameLabel
            // 
            this.computerNameLabel.AutoSize = true;
            this.computerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.computerNameLabel.Location = new System.Drawing.Point(96, 251);
            this.computerNameLabel.Name = "computerNameLabel";
            this.computerNameLabel.Size = new System.Drawing.Size(127, 20);
            this.computerNameLabel.TabIndex = 2;
            this.computerNameLabel.Text = "Computer name:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameLabel.Location = new System.Drawing.Point(96, 281);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(87, 20);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // cpuNameLabel
            // 
            this.cpuNameLabel.AutoSize = true;
            this.cpuNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cpuNameLabel.Location = new System.Drawing.Point(96, 311);
            this.cpuNameLabel.Name = "cpuNameLabel";
            this.cpuNameLabel.Size = new System.Drawing.Size(46, 20);
            this.cpuNameLabel.TabIndex = 4;
            this.cpuNameLabel.Text = "CPU:";
            // 
            // ramCapacityLabel
            // 
            this.ramCapacityLabel.AutoSize = true;
            this.ramCapacityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ramCapacityLabel.Location = new System.Drawing.Point(96, 341);
            this.ramCapacityLabel.Name = "ramCapacityLabel";
            this.ramCapacityLabel.Size = new System.Drawing.Size(87, 20);
            this.ramCapacityLabel.TabIndex = 5;
            this.ramCapacityLabel.Text = "RAM (GB):";
            // 
            // vgaNameLabel
            // 
            this.vgaNameLabel.AutoSize = true;
            this.vgaNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vgaNameLabel.Location = new System.Drawing.Point(96, 371);
            this.vgaNameLabel.Name = "vgaNameLabel";
            this.vgaNameLabel.Size = new System.Drawing.Size(92, 20);
            this.vgaNameLabel.TabIndex = 6;
            this.vgaNameLabel.Text = "VGA name:";
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ipAddressLabel.Location = new System.Drawing.Point(96, 401);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(89, 20);
            this.ipAddressLabel.TabIndex = 7;
            this.ipAddressLabel.Text = "IP address:";
            // 
            // computerNameValueLabel
            // 
            this.computerNameValueLabel.AutoEllipsis = true;
            this.computerNameValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.computerNameValueLabel.Location = new System.Drawing.Point(244, 251);
            this.computerNameValueLabel.Name = "computerNameValueLabel";
            this.computerNameValueLabel.Size = new System.Drawing.Size(356, 20);
            this.computerNameValueLabel.TabIndex = 8;
            // 
            // usernameValueLabel
            // 
            this.usernameValueLabel.AutoEllipsis = true;
            this.usernameValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameValueLabel.Location = new System.Drawing.Point(244, 281);
            this.usernameValueLabel.Name = "usernameValueLabel";
            this.usernameValueLabel.Size = new System.Drawing.Size(356, 20);
            this.usernameValueLabel.TabIndex = 9;
            // 
            // cpuNameValueLabel
            // 
            this.cpuNameValueLabel.AutoEllipsis = true;
            this.cpuNameValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cpuNameValueLabel.Location = new System.Drawing.Point(244, 311);
            this.cpuNameValueLabel.Name = "cpuNameValueLabel";
            this.cpuNameValueLabel.Size = new System.Drawing.Size(356, 20);
            this.cpuNameValueLabel.TabIndex = 10;
            // 
            // ramCapacityValueLabel
            // 
            this.ramCapacityValueLabel.AutoEllipsis = true;
            this.ramCapacityValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ramCapacityValueLabel.Location = new System.Drawing.Point(244, 341);
            this.ramCapacityValueLabel.Name = "ramCapacityValueLabel";
            this.ramCapacityValueLabel.Size = new System.Drawing.Size(356, 20);
            this.ramCapacityValueLabel.TabIndex = 11;
            // 
            // vgaNameValueLabel
            // 
            this.vgaNameValueLabel.AutoEllipsis = true;
            this.vgaNameValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vgaNameValueLabel.Location = new System.Drawing.Point(244, 371);
            this.vgaNameValueLabel.Name = "vgaNameValueLabel";
            this.vgaNameValueLabel.Size = new System.Drawing.Size(356, 20);
            this.vgaNameValueLabel.TabIndex = 12;
            // 
            // ipAddressValueLabel
            // 
            this.ipAddressValueLabel.AutoEllipsis = true;
            this.ipAddressValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ipAddressValueLabel.Location = new System.Drawing.Point(244, 401);
            this.ipAddressValueLabel.Name = "ipAddressValueLabel";
            this.ipAddressValueLabel.Size = new System.Drawing.Size(356, 20);
            this.ipAddressValueLabel.TabIndex = 13;
            // 
            // computerSummaryLabel
            // 
            this.computerSummaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.computerSummaryLabel.Location = new System.Drawing.Point(96, 196);
            this.computerSummaryLabel.Name = "computerSummaryLabel";
            this.computerSummaryLabel.Size = new System.Drawing.Size(504, 27);
            this.computerSummaryLabel.TabIndex = 15;
            this.computerSummaryLabel.Text = "Computer Summary";
            this.computerSummaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // freeSpaceAvgQLengthLabel
            // 
            this.freeSpaceAvgQLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.freeSpaceAvgQLengthLabel.Location = new System.Drawing.Point(645, 125);
            this.freeSpaceAvgQLengthLabel.Name = "freeSpaceAvgQLengthLabel";
            this.freeSpaceAvgQLengthLabel.Size = new System.Drawing.Size(455, 30);
            this.freeSpaceAvgQLengthLabel.TabIndex = 16;
            this.freeSpaceAvgQLengthLabel.Text = "Free Space/Avg. Disk Queue Length ";
            this.freeSpaceAvgQLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // freeDiskSpaceChart
            // 
            chartArea1.Name = "ChartArea1";
            this.freeDiskSpaceChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.freeDiskSpaceChart.Legends.Add(legend1);
            this.freeDiskSpaceChart.Location = new System.Drawing.Point(650, 196);
            this.freeDiskSpaceChart.Name = "freeDiskSpaceChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.freeDiskSpaceChart.Series.Add(series1);
            this.freeDiskSpaceChart.Size = new System.Drawing.Size(450, 300);
            this.freeDiskSpaceChart.TabIndex = 17;
            this.freeDiskSpaceChart.Text = "Free Disk Space";
            // 
            // avgDiskQueueLengthChart
            // 
            chartArea2.Name = "ChartArea1";
            this.avgDiskQueueLengthChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.avgDiskQueueLengthChart.Legends.Add(legend2);
            this.avgDiskQueueLengthChart.Location = new System.Drawing.Point(650, 530);
            this.avgDiskQueueLengthChart.Name = "avgDiskQueueLengthChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.avgDiskQueueLengthChart.Series.Add(series2);
            this.avgDiskQueueLengthChart.Size = new System.Drawing.Size(450, 300);
            this.avgDiskQueueLengthChart.TabIndex = 18;
            this.avgDiskQueueLengthChart.Text = "Avg. Disk Queue Length";
            // 
            // cpuRamUsageChart
            // 
            chartArea3.Name = "ChartArea1";
            this.cpuRamUsageChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.cpuRamUsageChart.Legends.Add(legend3);
            this.cpuRamUsageChart.Location = new System.Drawing.Point(100, 530);
            this.cpuRamUsageChart.Name = "cpuRamUsageChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.cpuRamUsageChart.Series.Add(series3);
            this.cpuRamUsageChart.Size = new System.Drawing.Size(500, 300);
            this.cpuRamUsageChart.TabIndex = 19;
            this.cpuRamUsageChart.Text = "CPU/RAM Usage";
            // 
            // cpuRamUsageLabel
            // 
            this.cpuRamUsageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.cpuRamUsageLabel.Location = new System.Drawing.Point(94, 465);
            this.cpuRamUsageLabel.Name = "cpuRamUsageLabel";
            this.cpuRamUsageLabel.Size = new System.Drawing.Size(506, 31);
            this.cpuRamUsageLabel.TabIndex = 20;
            this.cpuRamUsageLabel.Text = "CPU/RAM Usage";
            this.cpuRamUsageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartingWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 893);
            this.Controls.Add(this.cpuRamUsageLabel);
            this.Controls.Add(this.cpuRamUsageChart);
            this.Controls.Add(this.avgDiskQueueLengthChart);
            this.Controls.Add(this.freeDiskSpaceChart);
            this.Controls.Add(this.freeSpaceAvgQLengthLabel);
            this.Controls.Add(this.computerSummaryLabel);
            this.Controls.Add(this.ipAddressValueLabel);
            this.Controls.Add(this.vgaNameValueLabel);
            this.Controls.Add(this.ramCapacityValueLabel);
            this.Controls.Add(this.cpuNameValueLabel);
            this.Controls.Add(this.usernameValueLabel);
            this.Controls.Add(this.computerNameValueLabel);
            this.Controls.Add(this.ipAddressLabel);
            this.Controls.Add(this.vgaNameLabel);
            this.Controls.Add(this.ramCapacityLabel);
            this.Controls.Add(this.cpuNameLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.computerNameLabel);
            this.Controls.Add(this.beginComputerMonitoringButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "StartingWindowForm";
            this.Text = "Ultimate Computer Information Tool";
            ((System.ComponentModel.ISupportInitialize)(this.freeDiskSpaceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avgDiskQueueLengthChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuRamUsageChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label titleLabel;
        private Button beginComputerMonitoringButton;
        private Label computerNameLabel;
        private Label usernameLabel;
        private Label cpuNameLabel;
        private Label ramCapacityLabel;
        private Label vgaNameLabel;
        private Label ipAddressLabel;
        private Label computerNameValueLabel;
        private Label usernameValueLabel;
        private Label cpuNameValueLabel;
        private Label ramCapacityValueLabel;
        private Label vgaNameValueLabel;
        private Label ipAddressValueLabel;
        private Label computerSummaryLabel;
        private Label freeSpaceAvgQLengthLabel;
        private Chart freeDiskSpaceChart;
        private Chart avgDiskQueueLengthChart;
        private Chart cpuRamUsageChart;
        private Label cpuRamUsageLabel;
    }
}

