namespace Lab1
{
    partial class Task2Res
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Task2Res));
            this.pixelRed = new System.Windows.Forms.PictureBox();
            this.pixelBlue = new System.Windows.Forms.PictureBox();
            this.pixelGreen = new System.Windows.Forms.PictureBox();
            this.chartRed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGreen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBlue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pixelRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pixelRed
            // 
            this.pixelRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pixelRed.Location = new System.Drawing.Point(432, 12);
            this.pixelRed.Name = "pixelRed";
            this.pixelRed.Size = new System.Drawing.Size(376, 320);
            this.pixelRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pixelRed.TabIndex = 1;
            this.pixelRed.TabStop = false;
            // 
            // pixelBlue
            // 
            this.pixelBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pixelBlue.Location = new System.Drawing.Point(1247, 12);
            this.pixelBlue.Name = "pixelBlue";
            this.pixelBlue.Size = new System.Drawing.Size(384, 320);
            this.pixelBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pixelBlue.TabIndex = 4;
            this.pixelBlue.TabStop = false;
            this.pixelBlue.Click += new System.EventHandler(this.pixelBlue_Click);
            // 
            // pixelGreen
            // 
            this.pixelGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pixelGreen.Location = new System.Drawing.Point(837, 12);
            this.pixelGreen.Name = "pixelGreen";
            this.pixelGreen.Size = new System.Drawing.Size(384, 320);
            this.pixelGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pixelGreen.TabIndex = 5;
            this.pixelGreen.TabStop = false;
            // 
            // chartRed
            // 
            chartArea4.Name = "ChartArea1";
            this.chartRed.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartRed.Legends.Add(legend4);
            this.chartRed.Location = new System.Drawing.Point(432, 361);
            this.chartRed.Name = "chartRed";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartRed.Series.Add(series4);
            this.chartRed.Size = new System.Drawing.Size(376, 296);
            this.chartRed.TabIndex = 6;
            this.chartRed.Text = "chart1";
            this.chartRed.Click += new System.EventHandler(this.chartRed_Click);
            // 
            // chartGreen
            // 
            chartArea5.Name = "ChartArea1";
            this.chartGreen.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartGreen.Legends.Add(legend5);
            this.chartGreen.Location = new System.Drawing.Point(837, 361);
            this.chartGreen.Name = "chartGreen";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartGreen.Series.Add(series5);
            this.chartGreen.Size = new System.Drawing.Size(384, 296);
            this.chartGreen.TabIndex = 7;
            this.chartGreen.Text = "chart2";
            // 
            // chartBlue
            // 
            chartArea6.Name = "ChartArea1";
            this.chartBlue.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartBlue.Legends.Add(legend6);
            this.chartBlue.Location = new System.Drawing.Point(1247, 361);
            this.chartBlue.Name = "chartBlue";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartBlue.Series.Add(series6);
            this.chartBlue.Size = new System.Drawing.Size(384, 296);
            this.chartBlue.TabIndex = 8;
            this.chartBlue.Text = "chart3";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(395, 320);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(12, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(395, 58);
            this.button1.TabIndex = 10;
            this.button1.Text = "Разделить на каналы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Task2Res
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1671, 717);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.chartBlue);
            this.Controls.Add(this.chartGreen);
            this.Controls.Add(this.chartRed);
            this.Controls.Add(this.pixelGreen);
            this.Controls.Add(this.pixelBlue);
            this.Controls.Add(this.pixelRed);
            this.Name = "Task2Res";
            this.Text = "Task2Res";
            this.Load += new System.EventHandler(this.Task2Res_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pixelRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pixelRed;
        private System.Windows.Forms.PictureBox pixelBlue;
        private System.Windows.Forms.PictureBox pixelGreen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGreen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBlue;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
    }
}