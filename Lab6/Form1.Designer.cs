
namespace Lab6
{
    partial class Form1
    {
        /// <summary>
        /// ������������ ���������� ������������.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ���������� ��� ������������ �������.
        /// </summary>
        /// <param name="disposing">�������, ���� ����������� ������ ������ ���� ������; ����� �����.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region ���, ������������� ��������� ������������� ���� Windows

        /// <summary>
        /// ��������� ����� ��� ��������� ������������ � �� ��������� 
        /// ���������� ����� ������ � ������� ��������� ����.
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
            this.rotate = new System.Windows.Forms.Button();
            this.rotate_around_line = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.z1_text = new System.Windows.Forms.TextBox();
            this.y1_text = new System.Windows.Forms.TextBox();
            this.x1_text = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.z2_text = new System.Windows.Forms.TextBox();
            this.y2_text = new System.Windows.Forms.TextBox();
            this.x2_text = new System.Windows.Forms.TextBox();
            this.angle_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.zScale = new System.Windows.Forms.TextBox();
            this.yScale = new System.Windows.Forms.TextBox();
            this.xScale = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rotatez = new System.Windows.Forms.TextBox();
            this.rotatey = new System.Windows.Forms.TextBox();
            this.rotatex = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(565, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 609);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonTranslite
            // 
            this.buttonTranslite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTranslite.Location = new System.Drawing.Point(12, 157);
            this.buttonTranslite.Name = "buttonTranslite";
            this.buttonTranslite.Size = new System.Drawing.Size(138, 48);
            this.buttonTranslite.TabIndex = 2;
            this.buttonTranslite.Text = "��������";
            this.buttonTranslite.UseVisualStyleBackColor = true;
            this.buttonTranslite.Click += new System.EventHandler(this.buttonTranslite_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(182, 175);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(263, 175);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 30);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(344, 175);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 30);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(177, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(258, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(339, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "z";
            // 
            // buttonMirror
            // 
            this.buttonMirror.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMirror.Location = new System.Drawing.Point(29, 553);
            this.buttonMirror.Name = "buttonMirror";
            this.buttonMirror.Size = new System.Drawing.Size(138, 67);
            this.buttonMirror.TabIndex = 12;
            this.buttonMirror.Text = "��������";
            this.buttonMirror.UseVisualStyleBackColor = true;
            this.buttonMirror.Click += new System.EventHandler(this.buttonMirror_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(240, 18);
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
            "�� XY",
            "�� XZ",
            "�� YZ"});
            this.comboBoxAxis.Location = new System.Drawing.Point(196, 587);
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
            this.axonometric_button.Text = "�����������������";
            this.axonometric_button.UseVisualStyleBackColor = true;
            this.axonometric_button.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.perpective_button);
            this.groupBox1.Controls.Add(this.axonometric_button);
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
            this.groupBox2.Location = new System.Drawing.Point(968, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 43);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rotate_around_line
            // 
            this.rotate_around_line.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotate_around_line.Location = new System.Drawing.Point(12, 299);
            this.rotate_around_line.Name = "rotate_around_line";
            this.rotate_around_line.Size = new System.Drawing.Size(138, 45);
            this.rotate_around_line.TabIndex = 33;
            this.rotate_around_line.Text = "���������";
            this.rotate_around_line.UseVisualStyleBackColor = true;
            this.rotate_around_line.Click += new System.EventHandler(this.rotate_around_line_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(335, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "z1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(254, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "y1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(173, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "x1";
            // 
            // z1_text
            // 
            this.z1_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.z1_text.Location = new System.Drawing.Point(340, 315);
            this.z1_text.Name = "z1_text";
            this.z1_text.Size = new System.Drawing.Size(75, 30);
            this.z1_text.TabIndex = 36;
            this.z1_text.Text = "0";
            // 
            // y1_text
            // 
            this.y1_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.y1_text.Location = new System.Drawing.Point(259, 315);
            this.y1_text.Name = "y1_text";
            this.y1_text.Size = new System.Drawing.Size(75, 30);
            this.y1_text.TabIndex = 35;
            this.y1_text.Text = "0";
            // 
            // x1_text
            // 
            this.x1_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x1_text.Location = new System.Drawing.Point(178, 315);
            this.x1_text.Name = "x1_text";
            this.x1_text.Size = new System.Drawing.Size(75, 30);
            this.x1_text.TabIndex = 34;
            this.x1_text.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(339, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 25);
            this.label7.TabIndex = 43;
            this.label7.Text = "z2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(258, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 25);
            this.label8.TabIndex = 44;
            this.label8.Text = "y2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(177, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 25);
            this.label9.TabIndex = 45;
            this.label9.Text = "x2";
            // 
            // z2_text
            // 
            this.z2_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.z2_text.Location = new System.Drawing.Point(344, 388);
            this.z2_text.Name = "z2_text";
            this.z2_text.Size = new System.Drawing.Size(75, 30);
            this.z2_text.TabIndex = 42;
            this.z2_text.Text = "0";
            // 
            // y2_text
            // 
            this.y2_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.y2_text.Location = new System.Drawing.Point(263, 388);
            this.y2_text.Name = "y2_text";
            this.y2_text.Size = new System.Drawing.Size(75, 30);
            this.y2_text.TabIndex = 41;
            this.y2_text.Text = "0";
            // 
            // x2_text
            // 
            this.x2_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x2_text.Location = new System.Drawing.Point(182, 388);
            this.x2_text.Name = "x2_text";
            this.x2_text.Size = new System.Drawing.Size(75, 30);
            this.x2_text.TabIndex = 40;
            this.x2_text.Text = "0";
            // 
            // angle_text
            // 
            this.angle_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.angle_text.Location = new System.Drawing.Point(79, 388);
            this.angle_text.Name = "angle_text";
            this.angle_text.Size = new System.Drawing.Size(75, 30);
            this.angle_text.TabIndex = 46;
            this.angle_text.Text = "0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(16, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 60);
            this.button1.TabIndex = 47;
            this.button1.Text = "�������������� ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(329, 444);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 25);
            this.label10.TabIndex = 51;
            this.label10.Text = "z";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(248, 444);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 25);
            this.label11.TabIndex = 52;
            this.label11.Text = "y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(167, 444);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 25);
            this.label12.TabIndex = 53;
            this.label12.Text = "x";
            // 
            // zScale
            // 
            this.zScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zScale.Location = new System.Drawing.Point(334, 472);
            this.zScale.Name = "zScale";
            this.zScale.Size = new System.Drawing.Size(75, 30);
            this.zScale.TabIndex = 50;
            this.zScale.Text = "0";
            // 
            // yScale
            // 
            this.yScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yScale.Location = new System.Drawing.Point(253, 472);
            this.yScale.Name = "yScale";
            this.yScale.Size = new System.Drawing.Size(75, 30);
            this.yScale.TabIndex = 49;
            this.yScale.Text = "0";
            // 
            // xScale
            // 
            this.xScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xScale.Location = new System.Drawing.Point(172, 472);
            this.xScale.Name = "xScale";
            this.xScale.Size = new System.Drawing.Size(75, 30);
            this.xScale.TabIndex = 48;
            this.xScale.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(335, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 25);
            this.label13.TabIndex = 57;
            this.label13.Text = "z";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(254, 216);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 25);
            this.label14.TabIndex = 58;
            this.label14.Text = "y";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(173, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 25);
            this.label15.TabIndex = 59;
            this.label15.Text = "x";
            // 
            // rotatez
            // 
            this.rotatez.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotatez.Location = new System.Drawing.Point(340, 244);
            this.rotatez.Name = "rotatez";
            this.rotatez.Size = new System.Drawing.Size(75, 30);
            this.rotatez.TabIndex = 56;
            this.rotatez.Text = "0";
            // 
            // rotatey
            // 
            this.rotatey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotatey.Location = new System.Drawing.Point(259, 244);
            this.rotatey.Name = "rotatey";
            this.rotatey.Size = new System.Drawing.Size(75, 30);
            this.rotatey.TabIndex = 55;
            this.rotatey.Text = "0";
            // 
            // rotatex
            // 
            this.rotatex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotatex.Location = new System.Drawing.Point(178, 244);
            this.rotatex.Name = "rotatex";
            this.rotatex.Size = new System.Drawing.Size(75, 30);
            this.rotatex.TabIndex = 54;
            this.rotatex.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 747);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.rotatez);
            this.Controls.Add(this.rotatey);
            this.Controls.Add(this.rotatex);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.zScale);
            this.Controls.Add(this.yScale);
            this.Controls.Add(this.xScale);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.angle_text);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.z2_text);
            this.Controls.Add(this.y2_text);
            this.Controls.Add(this.x2_text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.z1_text);
            this.Controls.Add(this.y1_text);
            this.Controls.Add(this.x1_text);
            this.Controls.Add(this.rotate_around_line);
            this.Controls.Add(this.rotate);
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
        private System.Windows.Forms.Button rotate;
        private System.Windows.Forms.Button rotate_around_line;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox z1_text;
        private System.Windows.Forms.TextBox y1_text;
        private System.Windows.Forms.TextBox x1_text;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox z2_text;
        private System.Windows.Forms.TextBox y2_text;
        private System.Windows.Forms.TextBox x2_text;
        private System.Windows.Forms.TextBox angle_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox zScale;
        private System.Windows.Forms.TextBox yScale;
        private System.Windows.Forms.TextBox xScale;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox rotatez;
        private System.Windows.Forms.TextBox rotatey;
        private System.Windows.Forms.TextBox rotatex;
    }
}

