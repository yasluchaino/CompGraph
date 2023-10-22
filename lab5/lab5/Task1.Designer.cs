namespace lab5
{
    partial class Task1
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
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.treeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(758, 651);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(801, 24);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(253, 54);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.Text = "Нарисовать";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // treeBtn
            // 
            this.treeBtn.Location = new System.Drawing.Point(801, 128);
            this.treeBtn.Name = "treeBtn";
            this.treeBtn.Size = new System.Drawing.Size(253, 54);
            this.treeBtn.TabIndex = 3;
            this.treeBtn.Text = "Нарисовать дерево";
            this.treeBtn.UseVisualStyleBackColor = true;
            this.treeBtn.Click += new System.EventHandler(this.treeBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(776, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 346);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 687);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeBtn);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Task1";
            this.Text = "Task1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button treeBtn;
        private System.Windows.Forms.Label label1;
    }
}