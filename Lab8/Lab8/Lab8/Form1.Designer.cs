namespace Lab8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.rotatex = new System.Windows.Forms.TextBox();
            this.rotatey = new System.Windows.Forms.TextBox();
            this.rotatez = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonTranslite = new System.Windows.Forms.Button();
            this.rotate = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.x1_text = new System.Windows.Forms.TextBox();
            this.y1_text = new System.Windows.Forms.TextBox();
            this.z1_text = new System.Windows.Forms.TextBox();
            this.x2_text = new System.Windows.Forms.TextBox();
            this.y2_text = new System.Windows.Forms.TextBox();
            this.z2_text = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.xScale = new System.Windows.Forms.TextBox();
            this.yScale = new System.Windows.Forms.TextBox();
            this.zScale = new System.Windows.Forms.TextBox();
            this.angle_text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonMirror = new System.Windows.Forms.Button();
            this.comboBoxAxis = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.light_x = new System.Windows.Forms.TextBox();
            this.light_y = new System.Windows.Forms.TextBox();
            this.light_z = new System.Windows.Forms.TextBox();
            this.colorRed = new System.Windows.Forms.TextBox();
            this.colorGreen = new System.Windows.Forms.TextBox();
            this.colorBlue = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1427, 450);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(147, 36);
            this.button7.TabIndex = 159;
            this.button7.Text = "Построить фигуру";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1431, 128);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 149);
            this.textBox1.TabIndex = 158;
            this.textBox1.Text = "130;250;0\r\n80;200;0\r\n80;160;0\r\n140;140;0\r\n140;100;0\r\n80;60;0";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Отсечение нелицевых граней",
            "Алгоритм Z-буфера",
            "Освещение Фонга"});
            this.comboBox5.Location = new System.Drawing.Point(1436, 59);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(160, 24);
            this.comboBox5.TabIndex = 139;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1424, 36);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(202, 16);
            this.label25.TabIndex = 138;
            this.label25.Text = "Отсечение нелицевых граней";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(466, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(888, 796);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 136;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(339, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(263, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(176, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1428, 293);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(160, 16);
            this.label15.TabIndex = 165;
            this.label15.Text = "Количество разбиений";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1431, 327);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 166;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(1433, 368);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(98, 16);
            this.label34.TabIndex = 167;
            this.label34.Text = "Ось вращения";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1436, 405);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 168;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox10.Location = new System.Drawing.Point(179, 175);
            this.textBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(75, 30);
            this.textBox10.TabIndex = 175;
            this.textBox10.Text = "0";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox7.Location = new System.Drawing.Point(260, 175);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(75, 30);
            this.textBox7.TabIndex = 176;
            this.textBox7.Text = "0";
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox8.Location = new System.Drawing.Point(341, 175);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(75, 30);
            this.textBox8.TabIndex = 177;
            this.textBox8.Text = "0";
            // 
            // rotatex
            // 
            this.rotatex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotatex.Location = new System.Drawing.Point(178, 244);
            this.rotatex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rotatex.Name = "rotatex";
            this.rotatex.Size = new System.Drawing.Size(75, 30);
            this.rotatex.TabIndex = 178;
            this.rotatex.Text = "0";
            // 
            // rotatey
            // 
            this.rotatey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotatey.Location = new System.Drawing.Point(259, 244);
            this.rotatey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rotatey.Name = "rotatey";
            this.rotatey.Size = new System.Drawing.Size(75, 30);
            this.rotatey.TabIndex = 179;
            this.rotatey.Text = "0";
            this.rotatey.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // rotatez
            // 
            this.rotatez.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotatez.Location = new System.Drawing.Point(340, 244);
            this.rotatez.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rotatez.Name = "rotatez";
            this.rotatez.Size = new System.Drawing.Size(75, 30);
            this.rotatez.TabIndex = 180;
            this.rotatez.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(180, 217);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 25);
            this.label7.TabIndex = 181;
            this.label7.Text = "x";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(260, 217);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 25);
            this.label8.TabIndex = 182;
            this.label8.Text = "y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(339, 217);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 25);
            this.label9.TabIndex = 183;
            this.label9.Text = "z";
            // 
            // buttonTranslite
            // 
            this.buttonTranslite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTranslite.Location = new System.Drawing.Point(18, 166);
            this.buttonTranslite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTranslite.Name = "buttonTranslite";
            this.buttonTranslite.Size = new System.Drawing.Size(139, 48);
            this.buttonTranslite.TabIndex = 184;
            this.buttonTranslite.Text = "Сместить";
            this.buttonTranslite.UseVisualStyleBackColor = true;
            this.buttonTranslite.Click += new System.EventHandler(this.buttonTranslite_Click);
            // 
            // rotate
            // 
            this.rotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotate.Location = new System.Drawing.Point(18, 236);
            this.rotate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(139, 46);
            this.rotate.TabIndex = 185;
            this.rotate.Text = "Повернуть";
            this.rotate.UseVisualStyleBackColor = true;
            this.rotate.Click += new System.EventHandler(this.rotate_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(18, 304);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 46);
            this.button3.TabIndex = 186;
            this.button3.Text = "Повернуть";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // x1_text
            // 
            this.x1_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x1_text.Location = new System.Drawing.Point(178, 320);
            this.x1_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.x1_text.Name = "x1_text";
            this.x1_text.Size = new System.Drawing.Size(75, 30);
            this.x1_text.TabIndex = 187;
            this.x1_text.Text = "0";
            // 
            // y1_text
            // 
            this.y1_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.y1_text.Location = new System.Drawing.Point(259, 320);
            this.y1_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.y1_text.Name = "y1_text";
            this.y1_text.Size = new System.Drawing.Size(75, 30);
            this.y1_text.TabIndex = 188;
            this.y1_text.Text = "0";
            // 
            // z1_text
            // 
            this.z1_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.z1_text.Location = new System.Drawing.Point(340, 320);
            this.z1_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.z1_text.Name = "z1_text";
            this.z1_text.Size = new System.Drawing.Size(75, 30);
            this.z1_text.TabIndex = 189;
            this.z1_text.Text = "0";
            // 
            // x2_text
            // 
            this.x2_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x2_text.Location = new System.Drawing.Point(178, 386);
            this.x2_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.x2_text.Name = "x2_text";
            this.x2_text.Size = new System.Drawing.Size(75, 30);
            this.x2_text.TabIndex = 190;
            this.x2_text.Text = "0";
            // 
            // y2_text
            // 
            this.y2_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.y2_text.Location = new System.Drawing.Point(259, 386);
            this.y2_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.y2_text.Name = "y2_text";
            this.y2_text.Size = new System.Drawing.Size(75, 30);
            this.y2_text.TabIndex = 191;
            this.y2_text.Text = "0";
            // 
            // z2_text
            // 
            this.z2_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.z2_text.Location = new System.Drawing.Point(340, 386);
            this.z2_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.z2_text.Name = "z2_text";
            this.z2_text.Size = new System.Drawing.Size(75, 30);
            this.z2_text.TabIndex = 192;
            this.z2_text.Text = "0";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(18, 463);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(139, 60);
            this.button5.TabIndex = 193;
            this.button5.Text = "Масштабировать ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // xScale
            // 
            this.xScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xScale.Location = new System.Drawing.Point(179, 488);
            this.xScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xScale.Name = "xScale";
            this.xScale.Size = new System.Drawing.Size(75, 30);
            this.xScale.TabIndex = 194;
            this.xScale.Text = "1";
            // 
            // yScale
            // 
            this.yScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yScale.Location = new System.Drawing.Point(259, 488);
            this.yScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yScale.Name = "yScale";
            this.yScale.Size = new System.Drawing.Size(75, 30);
            this.yScale.TabIndex = 195;
            this.yScale.Text = "1";
            // 
            // zScale
            // 
            this.zScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zScale.Location = new System.Drawing.Point(340, 488);
            this.zScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zScale.Name = "zScale";
            this.zScale.Size = new System.Drawing.Size(75, 30);
            this.zScale.TabIndex = 196;
            this.zScale.Text = "1";
            // 
            // angle_text
            // 
            this.angle_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.angle_text.Location = new System.Drawing.Point(82, 387);
            this.angle_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.angle_text.Name = "angle_text";
            this.angle_text.Size = new System.Drawing.Size(75, 30);
            this.angle_text.TabIndex = 197;
            this.angle_text.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(176, 293);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 198;
            this.label4.Text = "x1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(180, 359);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 25);
            this.label6.TabIndex = 199;
            this.label6.Text = "x2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(260, 359);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 25);
            this.label10.TabIndex = 200;
            this.label10.Text = "y2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(260, 293);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 25);
            this.label11.TabIndex = 201;
            this.label11.Text = "y1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(339, 293);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 25);
            this.label12.TabIndex = 202;
            this.label12.Text = "z1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(339, 359);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 25);
            this.label13.TabIndex = 203;
            this.label13.Text = "z2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(180, 461);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 25);
            this.label16.TabIndex = 204;
            this.label16.Text = "x";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(260, 461);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 25);
            this.label18.TabIndex = 205;
            this.label18.Text = "y";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(339, 461);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 25);
            this.label19.TabIndex = 206;
            this.label19.Text = "z";
            // 
            // buttonMirror
            // 
            this.buttonMirror.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMirror.Location = new System.Drawing.Point(18, 564);
            this.buttonMirror.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMirror.Name = "buttonMirror";
            this.buttonMirror.Size = new System.Drawing.Size(139, 66);
            this.buttonMirror.TabIndex = 210;
            this.buttonMirror.Text = "Отразить";
            this.buttonMirror.UseVisualStyleBackColor = true;
            this.buttonMirror.Click += new System.EventHandler(this.buttonMirror_Click);
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
            this.comboBoxAxis.Location = new System.Drawing.Point(178, 581);
            this.comboBoxAxis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAxis.Name = "comboBoxAxis";
            this.comboBoxAxis.Size = new System.Drawing.Size(153, 33);
            this.comboBoxAxis.TabIndex = 211;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1709, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 16);
            this.label14.TabIndex = 212;
            this.label14.Text = "Источник освещения:";
            // 
            // light_x
            // 
            this.light_x.Location = new System.Drawing.Point(1695, 86);
            this.light_x.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.light_x.Name = "light_x";
            this.light_x.Size = new System.Drawing.Size(57, 22);
            this.light_x.TabIndex = 213;
            this.light_x.Text = "0";
            // 
            // light_y
            // 
            this.light_y.Location = new System.Drawing.Point(1758, 86);
            this.light_y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.light_y.Name = "light_y";
            this.light_y.Size = new System.Drawing.Size(57, 22);
            this.light_y.TabIndex = 214;
            this.light_y.Text = "0";
            // 
            // light_z
            // 
            this.light_z.Location = new System.Drawing.Point(1821, 86);
            this.light_z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.light_z.Name = "light_z";
            this.light_z.Size = new System.Drawing.Size(57, 22);
            this.light_z.TabIndex = 215;
            this.light_z.Text = "300";
            // 
            // colorRed
            // 
            this.colorRed.Location = new System.Drawing.Point(1695, 166);
            this.colorRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorRed.Name = "colorRed";
            this.colorRed.Size = new System.Drawing.Size(57, 22);
            this.colorRed.TabIndex = 216;
            this.colorRed.Text = "0";
            // 
            // colorGreen
            // 
            this.colorGreen.Location = new System.Drawing.Point(1758, 166);
            this.colorGreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorGreen.Name = "colorGreen";
            this.colorGreen.Size = new System.Drawing.Size(57, 22);
            this.colorGreen.TabIndex = 217;
            this.colorGreen.Text = "0";
            // 
            // colorBlue
            // 
            this.colorBlue.Location = new System.Drawing.Point(1821, 166);
            this.colorBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorBlue.Name = "colorBlue";
            this.colorBlue.Size = new System.Drawing.Size(57, 22);
            this.colorBlue.TabIndex = 218;
            this.colorBlue.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1709, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 16);
            this.label17.TabIndex = 219;
            this.label17.Text = "Цвет";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 54);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 20);
            this.radioButton1.TabIndex = 220;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Куб";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 80);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 20);
            this.radioButton2.TabIndex = 221;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Тетраэдр";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(12, 106);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(84, 20);
            this.radioButton3.TabIndex = 222;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Октаэдр";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "x + y",
            "Cos(x)",
            "Sin(x)"});
            this.comboBox1.Location = new System.Drawing.Point(1729, 379);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 223;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1726, 359);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(110, 16);
            this.label23.TabIndex = 224;
            this.label23.Text = "Выбор функции";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1729, 420);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 28);
            this.button1.TabIndex = 225;
            this.button1.Text = "Нарисовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1922, 844);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.colorBlue);
            this.Controls.Add(this.colorGreen);
            this.Controls.Add(this.colorRed);
            this.Controls.Add(this.light_z);
            this.Controls.Add(this.light_y);
            this.Controls.Add(this.light_x);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBoxAxis);
            this.Controls.Add(this.buttonMirror);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.angle_text);
            this.Controls.Add(this.zScale);
            this.Controls.Add(this.yScale);
            this.Controls.Add(this.xScale);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.z2_text);
            this.Controls.Add(this.y2_text);
            this.Controls.Add(this.x2_text);
            this.Controls.Add(this.z1_text);
            this.Controls.Add(this.y1_text);
            this.Controls.Add(this.x1_text);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.rotate);
            this.Controls.Add(this.buttonTranslite);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rotatez);
            this.Controls.Add(this.rotatey);
            this.Controls.Add(this.rotatex);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox rotatex;
        private System.Windows.Forms.TextBox rotatey;
        private System.Windows.Forms.TextBox rotatez;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonTranslite;
        private System.Windows.Forms.Button rotate;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox x1_text;
        private System.Windows.Forms.TextBox y1_text;
        private System.Windows.Forms.TextBox z1_text;
        private System.Windows.Forms.TextBox x2_text;
        private System.Windows.Forms.TextBox y2_text;
        private System.Windows.Forms.TextBox z2_text;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox xScale;
        private System.Windows.Forms.TextBox yScale;
        private System.Windows.Forms.TextBox zScale;
        private System.Windows.Forms.TextBox angle_text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonMirror;
        private System.Windows.Forms.ComboBox comboBoxAxis;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox light_x;
        private System.Windows.Forms.TextBox light_y;
        private System.Windows.Forms.TextBox light_z;
        private System.Windows.Forms.TextBox colorRed;
        private System.Windows.Forms.TextBox colorGreen;
        private System.Windows.Forms.TextBox colorBlue;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button1;
    }
}

