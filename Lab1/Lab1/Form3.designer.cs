namespace WindowsFormsApp1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pixelGreen = new System.Windows.Forms.PictureBox();
            this.pixelBlue = new System.Windows.Forms.PictureBox();
            this.pixelRed = new System.Windows.Forms.PictureBox();
            this.chartRed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGreen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBlue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pixelGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // pixelGreen
            // 
            this.pixelGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pixelGreen.Image = global::WindowsFormsApp1.Properties.Resources.ФРУКТЫ;
            this.pixelGreen.Location = new System.Drawing.Point(412, 12);
            this.pixelGreen.Name = "pixelGreen";
            this.pixelGreen.Size = new System.Drawing.Size(395, 320);
            this.pixelGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pixelGreen.TabIndex = 2;
            this.pixelGreen.TabStop = false;
           
            // 
            // pixelBlue
            // 
            this.pixelBlue.Image = ((System.Drawing.Image)(resources.GetObject("pixelBlue.Image")));
            this.pixelBlue.Location = new System.Drawing.Point(825, 12);
            this.pixelBlue.Name = "pixelBlue";
            this.pixelBlue.Size = new System.Drawing.Size(395, 320);
            this.pixelBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pixelBlue.TabIndex = 1;
            this.pixelBlue.TabStop = false;
  
            // 
            // pixelRed
            // 
            this.pixelRed.Image = ((System.Drawing.Image)(resources.GetObject("pixelRed.Image")));
            this.pixelRed.Location = new System.Drawing.Point(2, 12);
            this.pixelRed.Name = "pixelRed";
            this.pixelRed.Size = new System.Drawing.Size(395, 320);
            this.pixelRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pixelRed.TabIndex = 0;
            this.pixelRed.TabStop = false;
            
            // 
            // chartRed
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRed.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRed.Legends.Add(legend1);
            this.chartRed.Location = new System.Drawing.Point(2, 359);
            this.chartRed.Name = "chartRed";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRed.Series.Add(series1);
            this.chartRed.Size = new System.Drawing.Size(395, 389);
            this.chartRed.TabIndex = 3;
            this.chartRed.Text = "chart1";
            // 
            // chartGreen
            // 
            chartArea2.Name = "ChartArea1";
            this.chartGreen.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartGreen.Legends.Add(legend2);
            this.chartGreen.Location = new System.Drawing.Point(412, 359);
            this.chartGreen.Name = "chartGreen";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartGreen.Series.Add(series2);
            this.chartGreen.Size = new System.Drawing.Size(395, 389);
            this.chartGreen.TabIndex = 4;
            this.chartGreen.Text = "chart2";
     
            // 
            // chartBlue
            // 
            chartArea3.Name = "ChartArea1";
            this.chartBlue.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartBlue.Legends.Add(legend3);
            this.chartBlue.Location = new System.Drawing.Point(825, 359);
            this.chartBlue.Name = "chartBlue";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartBlue.Series.Add(series3);
            this.chartBlue.Size = new System.Drawing.Size(395, 389);
            this.chartBlue.TabIndex = 5;
            this.chartBlue.Text = "chart3";
        
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 873);
            this.Controls.Add(this.chartBlue);
            this.Controls.Add(this.chartGreen);
            this.Controls.Add(this.chartRed);
            this.Controls.Add(this.pixelGreen);
            this.Controls.Add(this.pixelBlue);
            this.Controls.Add(this.pixelRed);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pixelGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBlue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pixelRed;
        private System.Windows.Forms.PictureBox pixelBlue;
        private System.Windows.Forms.PictureBox pixelGreen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGreen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBlue;
    }
}