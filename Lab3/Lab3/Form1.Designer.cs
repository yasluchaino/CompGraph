namespace Lab3
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
            this.task_2_click = new System.Windows.Forms.Button();
            this.task_3_click = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // task_2_click
            // 
            this.task_2_click.Location = new System.Drawing.Point(261, 122);
            this.task_2_click.Name = "task_2_click";
            this.task_2_click.Size = new System.Drawing.Size(174, 59);
            this.task_2_click.TabIndex = 1;
            this.task_2_click.Text = "Задание 2";
            this.task_2_click.UseVisualStyleBackColor = true;
            this.task_2_click.Click += new System.EventHandler(this.task_2_click_Click);
            // 
            // task_3_click
            // 
            this.task_3_click.Location = new System.Drawing.Point(490, 122);
            this.task_3_click.Name = "task_3_click";
            this.task_3_click.Size = new System.Drawing.Size(174, 59);
            this.task_3_click.TabIndex = 2;
            this.task_3_click.Text = "Задание 3";
            this.task_3_click.UseVisualStyleBackColor = true;
            this.task_3_click.Click += new System.EventHandler(this.task_3_click_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 59);
            this.button1.TabIndex = 3;
            this.button1.Text = "Задание 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 329);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.task_3_click);
            this.Controls.Add(this.task_2_click);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button task_2_click;
        private System.Windows.Forms.Button task_3_click;
        private System.Windows.Forms.Button button1;
    }
}

