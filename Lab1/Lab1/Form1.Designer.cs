namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.task1 = new System.Windows.Forms.Button();
            this.task3 = new System.Windows.Forms.Button();
            this.task2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // task1
            // 
            this.task1.Location = new System.Drawing.Point(9, 87);
            this.task1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.task1.Name = "task1";
            this.task1.Size = new System.Drawing.Size(116, 47);
            this.task1.TabIndex = 0;
            this.task1.Text = "Задание 1";
            this.task1.UseVisualStyleBackColor = true;
            this.task1.Click += new System.EventHandler(this.task1_Click_1);
            // 
            // task3
            // 
            this.task3.Location = new System.Drawing.Point(315, 87);
            this.task3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.task3.Name = "task3";
            this.task3.Size = new System.Drawing.Size(116, 47);
            this.task3.TabIndex = 1;
            this.task3.Text = "Задание 3";
            this.task3.UseVisualStyleBackColor = true;
            this.task3.Click += new System.EventHandler(this.task3_Click);
            // 
            // task2
            // 
            this.task2.Location = new System.Drawing.Point(165, 87);
            this.task2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.task2.Name = "task2";
            this.task2.Size = new System.Drawing.Size(116, 47);
            this.task2.TabIndex = 2;
            this.task2.Text = "Задание 2";
            this.task2.UseVisualStyleBackColor = true;
            this.task2.Click += new System.EventHandler(this.task2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 280);
            this.Controls.Add(this.task2);
            this.Controls.Add(this.task3);
            this.Controls.Add(this.task1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button task1;
        private System.Windows.Forms.Button task3;
        private System.Windows.Forms.Button task2;
    }
}

