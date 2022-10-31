namespace Armstrong.WinServer
{
    partial class MainSettings
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.testCom_button = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TimeAsk_comboBox = new System.Windows.Forms.ComboBox();
            this.NewShift_comboBox = new System.Windows.Forms.ComboBox();
            this.newShift_Label = new System.Windows.Forms.Label();
            this.timeAsk_Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.baudRate_label = new System.Windows.Forms.Label();
            this.BaudRate_comboBox = new System.Windows.Forms.ComboBox();
            this.comPort_Label = new System.Windows.Forms.Label();
            this.PortName_comboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Информация:";
            //
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(485, 274);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.testCom_button);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основные";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // testCom_button
            // 
            this.testCom_button.Location = new System.Drawing.Point(248, 71);
            this.testCom_button.Name = "testCom_button";
            this.testCom_button.Size = new System.Drawing.Size(223, 31);
            this.testCom_button.TabIndex = 4;
            this.testCom_button.Text = "Тест Com-порта";
            this.testCom_button.UseVisualStyleBackColor = true;
            this.testCom_button.Click += new System.EventHandler(this.TestCom_button_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TimeAsk_comboBox);
            this.groupBox4.Controls.Add(this.NewShift_comboBox);
            this.groupBox4.Controls.Add(this.newShift_Label);
            this.groupBox4.Controls.Add(this.timeAsk_Label);
            this.groupBox4.Location = new System.Drawing.Point(6, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 178);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Общая конфигурация СРК";
            // 
            // TimeAsk_comboBox
            // 
            this.TimeAsk_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeAsk_comboBox.FormattingEnabled = true;
            this.TimeAsk_comboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.TimeAsk_comboBox.Location = new System.Drawing.Point(116, 22);
            this.TimeAsk_comboBox.Name = "TimeAsk_comboBox";
            this.TimeAsk_comboBox.Size = new System.Drawing.Size(92, 21);
            this.TimeAsk_comboBox.TabIndex = 8;
            this.TimeAsk_comboBox.SelectedIndexChanged += new System.EventHandler(this.TimeAsk_comboBox_SelectedIndexChanged);
            // 
            // NewShift_comboBox
            // 
            this.NewShift_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewShift_comboBox.FormattingEnabled = true;
            this.NewShift_comboBox.Items.AddRange(new object[] {
            "0:00:00",
            "1:00:00",
            "2:00:00",
            "3:00:00",
            "4:00:00",
            "5:00:00",
            "6:00:00",
            "7:00:00",
            "8:00:00",
            "9:00:00",
            "10:00:00",
            "11:00:00",
            "12:00:00",
            "13:00:00",
            "14:00:00",
            "15:00:00",
            "16:00:00",
            "17:00:00",
            "18:00:00",
            "19:00:00",
            "20:00:00",
            "21:00:00",
            "22:00:00",
            "23:00:00"});
            this.NewShift_comboBox.Location = new System.Drawing.Point(116, 48);
            this.NewShift_comboBox.Name = "NewShift_comboBox";
            this.NewShift_comboBox.Size = new System.Drawing.Size(92, 21);
            this.NewShift_comboBox.TabIndex = 7;
            this.NewShift_comboBox.SelectedIndexChanged += new System.EventHandler(this.NewShift_comboBox_SelectedIndexChanged);
            // 
            // newShift_Label
            // 
            this.newShift_Label.AutoSize = true;
            this.newShift_Label.Location = new System.Drawing.Point(6, 51);
            this.newShift_Label.Name = "newShift_Label";
            this.newShift_Label.Size = new System.Drawing.Size(77, 13);
            this.newShift_Label.TabIndex = 6;
            this.newShift_Label.Text = "Новая смена:";
            // 
            // timeAsk_Label
            // 
            this.timeAsk_Label.AutoSize = true;
            this.timeAsk_Label.Location = new System.Drawing.Point(6, 25);
            this.timeAsk_Label.Name = "timeAsk_Label";
            this.timeAsk_Label.Size = new System.Drawing.Size(104, 13);
            this.timeAsk_Label.TabIndex = 4;
            this.timeAsk_Label.Text = "Интервал запроса:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.baudRate_label);
            this.groupBox3.Controls.Add(this.BaudRate_comboBox);
            this.groupBox3.Controls.Add(this.comPort_Label);
            this.groupBox3.Controls.Add(this.PortName_comboBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 52);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройки COM-порта";
            // 
            // baudRate_label
            // 
            this.baudRate_label.AutoSize = true;
            this.baudRate_label.Location = new System.Drawing.Point(239, 25);
            this.baudRate_label.Name = "baudRate_label";
            this.baudRate_label.Size = new System.Drawing.Size(58, 13);
            this.baudRate_label.TabIndex = 3;
            this.baudRate_label.Text = "Скорость:";
            // 
            // BaudRate_comboBox
            // 
            this.BaudRate_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudRate_comboBox.FormattingEnabled = true;
            this.BaudRate_comboBox.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.BaudRate_comboBox.Location = new System.Drawing.Point(320, 22);
            this.BaudRate_comboBox.Name = "BaudRate_comboBox";
            this.BaudRate_comboBox.Size = new System.Drawing.Size(139, 21);
            this.BaudRate_comboBox.TabIndex = 2;
            this.BaudRate_comboBox.SelectedIndexChanged += new System.EventHandler(this.BaudRate_comboBox_SelectedIndexChanged);
            // 
            // comPort_Label
            // 
            this.comPort_Label.AutoSize = true;
            this.comPort_Label.Location = new System.Drawing.Point(6, 25);
            this.comPort_Label.Name = "comPort_Label";
            this.comPort_Label.Size = new System.Drawing.Size(75, 13);
            this.comPort_Label.TabIndex = 1;
            this.comPort_Label.Text = "Выбор порта:";
            // 
            // PortName_comboBox
            // 
            this.PortName_comboBox.FormattingEnabled = true;
            this.PortName_comboBox.Location = new System.Drawing.Point(87, 22);
            this.PortName_comboBox.Name = "PortName_comboBox";
            this.PortName_comboBox.Size = new System.Drawing.Size(121, 21);
            this.PortName_comboBox.TabIndex = 0;
            this.PortName_comboBox.SelectedIndexChanged += new System.EventHandler(this.PortName_comboBox_SelectedIndexChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 294);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.MainSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button testCom_button;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox NewShift_comboBox;
        private System.Windows.Forms.Label newShift_Label;
        private System.Windows.Forms.Label timeAsk_Label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label comPort_Label;
        private System.Windows.Forms.ComboBox PortName_comboBox;
        private System.Windows.Forms.Label baudRate_label;
        private System.Windows.Forms.ComboBox BaudRate_comboBox;
        private System.Windows.Forms.ComboBox TimeAsk_comboBox;
    }
}
