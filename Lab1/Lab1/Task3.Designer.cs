namespace Lab1
{
    partial class Task3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.h = new System.Windows.Forms.TrackBar();
            this.s = new System.Windows.Forms.TrackBar();
            this.v = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_HUE = new System.Windows.Forms.Label();
            this.label_SAT = new System.Windows.Forms.Label();
            this.label_V = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.save_buttom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(97, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 419);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(734, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(480, 419);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // h
            // 
            this.h.Location = new System.Drawing.Point(137, 479);
            this.h.Maximum = 360;
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(158, 56);
            this.h.TabIndex = 2;
            this.h.Scroll += new System.EventHandler(this.h_Scroll);
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(137, 541);
            this.s.Maximum = 100;
            this.s.Minimum = -100;
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(149, 56);
            this.s.TabIndex = 3;
            this.s.Scroll += new System.EventHandler(this.s_Scroll);
            // 
            // v
            // 
            this.v.Location = new System.Drawing.Point(137, 603);
            this.v.Maximum = 100;
            this.v.Minimum = -100;
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(149, 56);
            this.v.TabIndex = 4;
            this.v.Scroll += new System.EventHandler(this.v_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 553);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Saturation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 613);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Value";
            // 
            // label_HUE
            // 
            this.label_HUE.AutoSize = true;
            this.label_HUE.Location = new System.Drawing.Point(302, 489);
            this.label_HUE.Name = "label_HUE";
            this.label_HUE.Size = new System.Drawing.Size(14, 16);
            this.label_HUE.TabIndex = 8;
            this.label_HUE.Text = "0";
            // 
            // label_SAT
            // 
            this.label_SAT.AutoSize = true;
            this.label_SAT.Location = new System.Drawing.Point(302, 553);
            this.label_SAT.Name = "label_SAT";
            this.label_SAT.Size = new System.Drawing.Size(14, 16);
            this.label_SAT.TabIndex = 9;
            this.label_SAT.Text = "0";
            // 
            // label_V
            // 
            this.label_V.AutoSize = true;
            this.label_V.Location = new System.Drawing.Point(302, 613);
            this.label_V.Name = "label_V";
            this.label_V.Size = new System.Drawing.Size(14, 16);
            this.label_V.TabIndex = 10;
            this.label_V.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 31);
            this.button1.TabIndex = 11;
            this.button1.Text = "TO HSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // save_buttom
            // 
            this.save_buttom.Location = new System.Drawing.Point(1124, 541);
            this.save_buttom.Name = "save_buttom";
            this.save_buttom.Size = new System.Drawing.Size(107, 28);
            this.save_buttom.TabIndex = 12;
            this.save_buttom.Text = "save";
            this.save_buttom.UseVisualStyleBackColor = true;
            this.save_buttom.Click += new System.EventHandler(this.save_buttom_Click);
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 688);
            this.Controls.Add(this.save_buttom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_V);
            this.Controls.Add(this.label_SAT);
            this.Controls.Add(this.label_HUE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.v);
            this.Controls.Add(this.s);
            this.Controls.Add(this.h);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Task3";
            this.Text = "task3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TrackBar h;
        private System.Windows.Forms.TrackBar s;
        private System.Windows.Forms.TrackBar v;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_HUE;
        private System.Windows.Forms.Label label_SAT;
        private System.Windows.Forms.Label label_V;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button save_buttom;
    }
}