namespace Armstrong.WinServer
{
    partial class DatePicker
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
            this.minDate_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.maxDate_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataShift_radioButton = new System.Windows.Forms.RadioButton();
            this.dataRange_radioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxTime_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.minTime_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ok_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // minDate_dateTimePicker
            // 
            this.minDate_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.minDate_dateTimePicker.Location = new System.Drawing.Point(35, 19);
            this.minDate_dateTimePicker.Name = "minDate_dateTimePicker";
            this.minDate_dateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.minDate_dateTimePicker.TabIndex = 0;
            // 
            // maxDate_dateTimePicker
            // 
            this.maxDate_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.maxDate_dateTimePicker.Location = new System.Drawing.Point(192, 18);
            this.maxDate_dateTimePicker.Name = "maxDate_dateTimePicker";
            this.maxDate_dateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.maxDate_dateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "От:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "До:";
            // 
            // dataShift_radioButton
            // 
            this.dataShift_radioButton.AutoSize = true;
            this.dataShift_radioButton.Location = new System.Drawing.Point(21, 12);
            this.dataShift_radioButton.Name = "dataShift_radioButton";
            this.dataShift_radioButton.Size = new System.Drawing.Size(115, 17);
            this.dataShift_radioButton.TabIndex = 4;
            this.dataShift_radioButton.TabStop = true;
            this.dataShift_radioButton.Text = "Данные за смену";
            this.dataShift_radioButton.UseVisualStyleBackColor = true;
            this.dataShift_radioButton.CheckedChanged += new System.EventHandler(this.DataShift_radioButton_CheckedChanged);
            // 
            // dataRange_radioButton
            // 
            this.dataRange_radioButton.AutoSize = true;
            this.dataRange_radioButton.Location = new System.Drawing.Point(207, 12);
            this.dataRange_radioButton.Name = "dataRange_radioButton";
            this.dataRange_radioButton.Size = new System.Drawing.Size(132, 17);
            this.dataRange_radioButton.TabIndex = 5;
            this.dataRange_radioButton.TabStop = true;
            this.dataRange_radioButton.Text = "Данные в диапазоне";
            this.dataRange_radioButton.UseVisualStyleBackColor = true;
            this.dataRange_radioButton.CheckedChanged += new System.EventHandler(this.DataRange_radioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxTime_dateTimePicker);
            this.groupBox1.Controls.Add(this.minTime_dateTimePicker);
            this.groupBox1.Controls.Add(this.minDate_dateTimePicker);
            this.groupBox1.Controls.Add(this.maxDate_dateTimePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // maxTime_dateTimePicker
            // 
            this.maxTime_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.maxTime_dateTimePicker.ShowUpDown = true;
            this.maxTime_dateTimePicker.Location = new System.Drawing.Point(192, 44);
            this.maxTime_dateTimePicker.Name = "maxTime_dateTimePicker";
            this.maxTime_dateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.maxTime_dateTimePicker.TabIndex = 7;
            // 
            // minTime_dateTimePicker
            // 
            this.minTime_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.minTime_dateTimePicker.ShowUpDown = true;
            this.minTime_dateTimePicker.Location = new System.Drawing.Point(35, 45);
            this.minTime_dateTimePicker.Name = "minTime_dateTimePicker";
            this.minTime_dateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.minTime_dateTimePicker.TabIndex = 6;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(12, 120);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(331, 23);
            this.ok_button.TabIndex = 7;
            this.ok_button.Text = "Построить график";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // changeData_Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 152);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataRange_radioButton);
            this.Controls.Add(this.dataShift_radioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "changeData_Graphic";
            this.Text = "Выбор источника данных:";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker minDate_dateTimePicker;
        private System.Windows.Forms.DateTimePicker maxDate_dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton dataShift_radioButton;
        private System.Windows.Forms.RadioButton dataRange_radioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker maxTime_dateTimePicker;
        private System.Windows.Forms.DateTimePicker minTime_dateTimePicker;
        private System.Windows.Forms.Button ok_button;
    }
}