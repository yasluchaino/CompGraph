
namespace Lab6
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonTranslite = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonMirror = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBoxAxis = new System.Windows.Forms.ComboBox();
            this.axonometric_button = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.perpective_button = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.angleRotate = new System.Windows.Forms.TextBox();
            this.xRotate = new System.Windows.Forms.RadioButton();
            this.zRotate = new System.Windows.Forms.RadioButton();
            this.yRotate = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 609);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonTranslite
            // 
            this.buttonTranslite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTranslite.Location = new System.Drawing.Point(824, 179);
            this.buttonTranslite.Name = "buttonTranslite";
            this.buttonTranslite.Size = new System.Drawing.Size(138, 48);
            this.buttonTranslite.TabIndex = 2;
            this.buttonTranslite.Text = "Сместить";
            this.buttonTranslite.UseVisualStyleBackColor = true;
            this.buttonTranslite.Click += new System.EventHandler(this.buttonTranslite_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(973, 188);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(1054, 188);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 30);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(1135, 188);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 30);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(968, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1049, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1130, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "z";
            // 
            // buttonMirror
            // 
            this.buttonMirror.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMirror.Location = new System.Drawing.Point(837, 554);
            this.buttonMirror.Name = "buttonMirror";
            this.buttonMirror.Size = new System.Drawing.Size(138, 67);
            this.buttonMirror.TabIndex = 12;
            this.buttonMirror.Text = "Отразить";
            this.buttonMirror.UseVisualStyleBackColor = true;
            this.buttonMirror.Click += new System.EventHandler(this.buttonMirror_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(1048, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 25);
            this.label20.TabIndex = 21;
            // 
            // comboBoxAxis
            // 
            this.comboBoxAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAxis.FormattingEnabled = true;
            this.comboBoxAxis.Items.AddRange(new object[] {
            "по XY",
            "по XZ",
            "по YZ"});
            this.comboBoxAxis.Location = new System.Drawing.Point(1004, 588);
            this.comboBoxAxis.Name = "comboBoxAxis";
            this.comboBoxAxis.Size = new System.Drawing.Size(154, 33);
            this.comboBoxAxis.TabIndex = 23;
            this.comboBoxAxis.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // axonometric_button
            // 
            this.axonometric_button.AutoSize = true;
            this.axonometric_button.Location = new System.Drawing.Point(16, 12);
            this.axonometric_button.Name = "axonometric_button";
            this.axonometric_button.Size = new System.Drawing.Size(160, 20);
            this.axonometric_button.TabIndex = 0;
            this.axonometric_button.TabStop = true;
            this.axonometric_button.Text = "Аксонометрическая";
            this.axonometric_button.UseVisualStyleBackColor = true;
            this.axonometric_button.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.perpective_button);
            this.groupBox1.Controls.Add(this.axonometric_button);
            this.groupBox1.Location = new System.Drawing.Point(1071, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 75);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // perpective_button
            // 
            this.perpective_button.AutoSize = true;
            this.perpective_button.Location = new System.Drawing.Point(16, 39);
            this.perpective_button.Name = "perpective_button";
            this.perpective_button.Size = new System.Drawing.Size(130, 20);
            this.perpective_button.TabIndex = 1;
            this.perpective_button.TabStop = true;
            this.perpective_button.Text = "Перспективная";
            this.perpective_button.UseVisualStyleBackColor = true;
            this.perpective_button.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(837, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Куб";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(837, 63);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Тетраэдр";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(837, 89);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(84, 20);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Октаэдр";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(824, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 45);
            this.button1.TabIndex = 27;
            this.button1.Text = "Повернуть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // angleRotate
            // 
            this.angleRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.angleRotate.Location = new System.Drawing.Point(1135, 255);
            this.angleRotate.Name = "angleRotate";
            this.angleRotate.Size = new System.Drawing.Size(75, 30);
            this.angleRotate.TabIndex = 31;
            this.angleRotate.Text = "0";
            // 
            // xRotate
            // 
            this.xRotate.AutoSize = true;
            this.xRotate.Location = new System.Drawing.Point(13, 14);
            this.xRotate.Name = "xRotate";
            this.xRotate.Size = new System.Drawing.Size(36, 20);
            this.xRotate.TabIndex = 28;
            this.xRotate.TabStop = true;
            this.xRotate.Text = "X";
            this.xRotate.UseVisualStyleBackColor = true;
            // 
            // zRotate
            // 
            this.zRotate.AutoSize = true;
            this.zRotate.Location = new System.Drawing.Point(117, 14);
            this.zRotate.Name = "zRotate";
            this.zRotate.Size = new System.Drawing.Size(36, 20);
            this.zRotate.TabIndex = 29;
            this.zRotate.TabStop = true;
            this.zRotate.Text = "Z";
            this.zRotate.UseVisualStyleBackColor = true;
            // 
            // yRotate
            // 
            this.yRotate.AutoSize = true;
            this.yRotate.Location = new System.Drawing.Point(65, 14);
            this.yRotate.Name = "yRotate";
            this.yRotate.Size = new System.Drawing.Size(37, 20);
            this.yRotate.TabIndex = 30;
            this.yRotate.TabStop = true;
            this.yRotate.Text = "Y";
            this.yRotate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.yRotate);
            this.groupBox2.Controls.Add(this.zRotate);
            this.groupBox2.Controls.Add(this.xRotate);
            this.groupBox2.Location = new System.Drawing.Point(968, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 43);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 633);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.angleRotate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.comboBoxAxis);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.buttonMirror);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonTranslite);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonTranslite;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMirror;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBoxAxis;
        private System.Windows.Forms.RadioButton axonometric_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton perpective_button;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox angleRotate;
        private System.Windows.Forms.RadioButton xRotate;
        private System.Windows.Forms.RadioButton zRotate;
        private System.Windows.Forms.RadioButton yRotate;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

