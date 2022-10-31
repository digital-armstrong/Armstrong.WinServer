namespace Armstrong.WinServer
{
    partial class ChannelAdd
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
            this.id_ComboBox = new System.Windows.Forms.ComboBox();
            this.Server_groupBox = new System.Windows.Forms.GroupBox();
            this.UIM_BD_label = new System.Windows.Forms.Label();
            this.Id_BD_label = new System.Windows.Forms.Label();
            this.idServer_ComboBox = new System.Windows.Forms.ComboBox();
            this.Add_Button = new System.Windows.Forms.Button();
            this.BD_groupBox = new System.Windows.Forms.GroupBox();
            this.max_label = new System.Windows.Forms.Label();
            this.min__label = new System.Windows.Forms.Label();
            this.min_TBox = new System.Windows.Forms.TextBox();
            this.max_TBox = new System.Windows.Forms.TextBox();
            this.spetial_CheckBox = new System.Windows.Forms.CheckBox();
            this.onOff_checkBox = new System.Windows.Forms.CheckBox();
            this.Tipe_BD_label = new System.Windows.Forms.Label();
            this.Coefficient_BD_label = new System.Windows.Forms.Label();
            this.Dim_BD_label = new System.Windows.Forms.Label();
            this.type_ComboBox = new System.Windows.Forms.ComboBox();
            this.coefficient_TBox = new System.Windows.Forms.TextBox();
            this.nameDb_ComboBox = new System.Windows.Forms.ComboBox();
            this.Point_groupBox = new System.Windows.Forms.GroupBox();
            this.nameControlPoint_TBox = new System.Windows.Forms.TextBox();
            this.NamePoint_BD_Label = new System.Windows.Forms.Label();
            this.Point_label = new System.Windows.Forms.Label();
            this.nameLocation_TextBox = new System.Windows.Forms.TextBox();
            this.Accident_groupBox = new System.Windows.Forms.GroupBox();
            this.preAccident_TBox = new System.Windows.Forms.TextBox();
            this.accident_TBox = new System.Windows.Forms.TextBox();
            this.PreAccident_label = new System.Windows.Forms.Label();
            this.Accident_label = new System.Windows.Forms.Label();
            this.Server_groupBox.SuspendLayout();
            this.BD_groupBox.SuspendLayout();
            this.Point_groupBox.SuspendLayout();
            this.Accident_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // id_ComboBox
            // 
            this.id_ComboBox.FormattingEnabled = true;
            this.id_ComboBox.Items.AddRange(new object[] {
            "1",
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
            "48"});
            this.id_ComboBox.Location = new System.Drawing.Point(331, 32);
            this.id_ComboBox.Name = "id_ComboBox";
            this.id_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.id_ComboBox.TabIndex = 14;
            // 
            // Server_groupBox
            // 
            this.Server_groupBox.Controls.Add(this.UIM_BD_label);
            this.Server_groupBox.Controls.Add(this.Id_BD_label);
            this.Server_groupBox.Controls.Add(this.idServer_ComboBox);
            this.Server_groupBox.Controls.Add(this.id_ComboBox);
            this.Server_groupBox.Location = new System.Drawing.Point(12, 12);
            this.Server_groupBox.Name = "Server_groupBox";
            this.Server_groupBox.Size = new System.Drawing.Size(468, 66);
            this.Server_groupBox.TabIndex = 37;
            this.Server_groupBox.TabStop = false;
            this.Server_groupBox.Text = "Конфигурация связи:";
            // 
            // UIM_BD_label
            // 
            this.UIM_BD_label.AutoSize = true;
            this.UIM_BD_label.Location = new System.Drawing.Point(18, 35);
            this.UIM_BD_label.Name = "UIM_BD_label";
            this.UIM_BD_label.Size = new System.Drawing.Size(89, 13);
            this.UIM_BD_label.TabIndex = 15;
            this.UIM_BD_label.Text = "Номер сервера:";
            // 
            // Id_BD_label
            // 
            this.Id_BD_label.AutoSize = true;
            this.Id_BD_label.Location = new System.Drawing.Point(242, 35);
            this.Id_BD_label.Name = "Id_BD_label";
            this.Id_BD_label.Size = new System.Drawing.Size(83, 13);
            this.Id_BD_label.TabIndex = 17;
            this.Id_BD_label.Text = "Номер канала:";
            // 
            // idServer_ComboBox
            // 
            this.idServer_ComboBox.FormattingEnabled = true;
            this.idServer_ComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.idServer_ComboBox.Location = new System.Drawing.Point(113, 32);
            this.idServer_ComboBox.Name = "idServer_ComboBox";
            this.idServer_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.idServer_ComboBox.TabIndex = 13;
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(12, 375);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(471, 23);
            this.Add_Button.TabIndex = 36;
            this.Add_Button.Text = "Добавить канал";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // BD_groupBox
            // 
            this.BD_groupBox.Controls.Add(this.max_label);
            this.BD_groupBox.Controls.Add(this.min__label);
            this.BD_groupBox.Controls.Add(this.min_TBox);
            this.BD_groupBox.Controls.Add(this.max_TBox);
            this.BD_groupBox.Controls.Add(this.spetial_CheckBox);
            this.BD_groupBox.Controls.Add(this.onOff_checkBox);
            this.BD_groupBox.Controls.Add(this.Tipe_BD_label);
            this.BD_groupBox.Controls.Add(this.Coefficient_BD_label);
            this.BD_groupBox.Controls.Add(this.Dim_BD_label);
            this.BD_groupBox.Controls.Add(this.type_ComboBox);
            this.BD_groupBox.Controls.Add(this.coefficient_TBox);
            this.BD_groupBox.Controls.Add(this.nameDb_ComboBox);
            this.BD_groupBox.Location = new System.Drawing.Point(12, 84);
            this.BD_groupBox.Name = "BD_groupBox";
            this.BD_groupBox.Size = new System.Drawing.Size(468, 144);
            this.BD_groupBox.TabIndex = 37;
            this.BD_groupBox.TabStop = false;
            this.BD_groupBox.Text = "Конфигурация блока детектирования:";
            // 
            // max_label
            // 
            this.max_label.AutoSize = true;
            this.max_label.Location = new System.Drawing.Point(251, 114);
            this.max_label.Name = "max_label";
            this.max_label.Size = new System.Drawing.Size(74, 13);
            this.max_label.TabIndex = 17;
            this.max_label.Text = "Макс. от ист:";
            // 
            // min__label
            // 
            this.min__label.AutoSize = true;
            this.min__label.Location = new System.Drawing.Point(39, 114);
            this.min__label.Name = "min__label";
            this.min__label.Size = new System.Drawing.Size(68, 13);
            this.min__label.TabIndex = 16;
            this.min__label.Text = "Мин. от ист:";
            // 
            // min_TBox
            // 
            this.min_TBox.Location = new System.Drawing.Point(113, 111);
            this.min_TBox.Name = "min_TBox";
            this.min_TBox.Size = new System.Drawing.Size(121, 20);
            this.min_TBox.TabIndex = 15;
            // 
            // max_TBox
            // 
            this.max_TBox.Location = new System.Drawing.Point(331, 111);
            this.max_TBox.Name = "max_TBox";
            this.max_TBox.Size = new System.Drawing.Size(121, 20);
            this.max_TBox.TabIndex = 14;
            // 
            // spetial_CheckBox
            // 
            this.spetial_CheckBox.AutoSize = true;
            this.spetial_CheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.spetial_CheckBox.Location = new System.Drawing.Point(243, 88);
            this.spetial_CheckBox.Name = "spetial_CheckBox";
            this.spetial_CheckBox.Size = new System.Drawing.Size(101, 17);
            this.spetial_CheckBox.TabIndex = 13;
            this.spetial_CheckBox.Text = "Спецконтроль:";
            this.spetial_CheckBox.UseVisualStyleBackColor = true;
            // 
            // onOff_checkBox
            // 
            this.onOff_checkBox.AutoSize = true;
            this.onOff_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.onOff_checkBox.Location = new System.Drawing.Point(266, 65);
            this.onOff_checkBox.Name = "onOff_checkBox";
            this.onOff_checkBox.Size = new System.Drawing.Size(78, 17);
            this.onOff_checkBox.TabIndex = 12;
            this.onOff_checkBox.Text = "Включить:";
            this.onOff_checkBox.UseVisualStyleBackColor = true;
            // 
            // Tipe_BD_label
            // 
            this.Tipe_BD_label.AutoSize = true;
            this.Tipe_BD_label.Location = new System.Drawing.Point(28, 40);
            this.Tipe_BD_label.Name = "Tipe_BD_label";
            this.Tipe_BD_label.Size = new System.Drawing.Size(79, 13);
            this.Tipe_BD_label.TabIndex = 0;
            this.Tipe_BD_label.Text = "Название БД:";
            // 
            // Coefficient_BD_label
            // 
            this.Coefficient_BD_label.AutoSize = true;
            this.Coefficient_BD_label.Location = new System.Drawing.Point(27, 67);
            this.Coefficient_BD_label.Name = "Coefficient_BD_label";
            this.Coefficient_BD_label.Size = new System.Drawing.Size(80, 13);
            this.Coefficient_BD_label.TabIndex = 1;
            this.Coefficient_BD_label.Text = "Коэффициент:";
            // 
            // Dim_BD_label
            // 
            this.Dim_BD_label.AutoSize = true;
            this.Dim_BD_label.Location = new System.Drawing.Point(277, 40);
            this.Dim_BD_label.Name = "Dim_BD_label";
            this.Dim_BD_label.Size = new System.Drawing.Size(48, 13);
            this.Dim_BD_label.TabIndex = 2;
            this.Dim_BD_label.Text = "Тип БД:";
            // 
            // type_ComboBox
            // 
            this.type_ComboBox.FormattingEnabled = true;
            this.type_ComboBox.Items.AddRange(new object[] {
            "Частотный",
            "Временной",
            "Лентопротяж. механизм"});
            this.type_ComboBox.Location = new System.Drawing.Point(331, 37);
            this.type_ComboBox.Name = "type_ComboBox";
            this.type_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.type_ComboBox.TabIndex = 11;
            // 
            // coefficient_TBox
            // 
            this.coefficient_TBox.Location = new System.Drawing.Point(113, 64);
            this.coefficient_TBox.Name = "coefficient_TBox";
            this.coefficient_TBox.Size = new System.Drawing.Size(121, 20);
            this.coefficient_TBox.TabIndex = 6;
            // 
            // nameDb_ComboBox
            // 
            this.nameDb_ComboBox.FormattingEnabled = true;
            this.nameDb_ComboBox.Items.AddRange(new object[] {
            "БДАС-03П",
            "БДГБ-02П",
            "БДГБ-02И",
            "БДЛН-32Р",
            "БДМГ-08Р-02",
            "БДМГ-08Р-04",
            "БДМГ-08Р-05",
            "БДМГ-41",
            "БДМГ-41-01",
            "БДМГ-41-03",
            "Генератор",
            "УДАБ-03П",
            "УДАС-02П",
            "УДАС-03П",
            "УДБН-02Р"});
            this.nameDb_ComboBox.Location = new System.Drawing.Point(113, 37);
            this.nameDb_ComboBox.Name = "nameDb_ComboBox";
            this.nameDb_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.nameDb_ComboBox.TabIndex = 9;
            this.nameDb_ComboBox.SelectedIndexChanged += new System.EventHandler(this.nameDb_ComboBox_SelectedIndexChanged);
            // 
            // Point_groupBox
            // 
            this.Point_groupBox.Controls.Add(this.nameControlPoint_TBox);
            this.Point_groupBox.Controls.Add(this.NamePoint_BD_Label);
            this.Point_groupBox.Controls.Add(this.Point_label);
            this.Point_groupBox.Controls.Add(this.nameLocation_TextBox);
            this.Point_groupBox.Location = new System.Drawing.Point(12, 234);
            this.Point_groupBox.Name = "Point_groupBox";
            this.Point_groupBox.Size = new System.Drawing.Size(469, 64);
            this.Point_groupBox.TabIndex = 38;
            this.Point_groupBox.TabStop = false;
            this.Point_groupBox.Text = "Конфигурация размещения и категории:";
            // 
            // nameControlPoint_TBox
            // 
            this.nameControlPoint_TBox.Location = new System.Drawing.Point(113, 34);
            this.nameControlPoint_TBox.Name = "nameControlPoint_TBox";
            this.nameControlPoint_TBox.Size = new System.Drawing.Size(121, 20);
            this.nameControlPoint_TBox.TabIndex = 7;
            // 
            // NamePoint_BD_Label
            // 
            this.NamePoint_BD_Label.AutoSize = true;
            this.NamePoint_BD_Label.Location = new System.Drawing.Point(17, 37);
            this.NamePoint_BD_Label.Name = "NamePoint_BD_Label";
            this.NamePoint_BD_Label.Size = new System.Drawing.Size(90, 13);
            this.NamePoint_BD_Label.TabIndex = 4;
            this.NamePoint_BD_Label.Text = "Точка контроля:";
            // 
            // Point_label
            // 
            this.Point_label.AutoSize = true;
            this.Point_label.Location = new System.Drawing.Point(262, 37);
            this.Point_label.Name = "Point_label";
            this.Point_label.Size = new System.Drawing.Size(64, 13);
            this.Point_label.TabIndex = 5;
            this.Point_label.Text = "Располож.:";
            // 
            // nameLocation_TextBox
            // 
            this.nameLocation_TextBox.Location = new System.Drawing.Point(332, 34);
            this.nameLocation_TextBox.Name = "nameLocation_TextBox";
            this.nameLocation_TextBox.Size = new System.Drawing.Size(121, 20);
            this.nameLocation_TextBox.TabIndex = 8;
            // 
            // Accident_groupBox
            // 
            this.Accident_groupBox.Controls.Add(this.preAccident_TBox);
            this.Accident_groupBox.Controls.Add(this.accident_TBox);
            this.Accident_groupBox.Controls.Add(this.PreAccident_label);
            this.Accident_groupBox.Controls.Add(this.Accident_label);
            this.Accident_groupBox.Location = new System.Drawing.Point(13, 304);
            this.Accident_groupBox.Name = "Accident_groupBox";
            this.Accident_groupBox.Size = new System.Drawing.Size(468, 65);
            this.Accident_groupBox.TabIndex = 39;
            this.Accident_groupBox.TabStop = false;
            this.Accident_groupBox.Text = "Конфигурация световой сигнализации:";
            // 
            // preAccident_TBox
            // 
            this.preAccident_TBox.Location = new System.Drawing.Point(113, 30);
            this.preAccident_TBox.Name = "preAccident_TBox";
            this.preAccident_TBox.Size = new System.Drawing.Size(121, 20);
            this.preAccident_TBox.TabIndex = 23;
            // 
            // accident_TBox
            // 
            this.accident_TBox.Location = new System.Drawing.Point(331, 30);
            this.accident_TBox.Name = "accident_TBox";
            this.accident_TBox.Size = new System.Drawing.Size(121, 20);
            this.accident_TBox.TabIndex = 24;
            // 
            // PreAccident_label
            // 
            this.PreAccident_label.AutoSize = true;
            this.PreAccident_label.Location = new System.Drawing.Point(47, 33);
            this.PreAccident_label.Name = "PreAccident_label";
            this.PreAccident_label.Size = new System.Drawing.Size(60, 13);
            this.PreAccident_label.TabIndex = 21;
            this.PreAccident_label.Text = "Предавар:";
            // 
            // Accident_label
            // 
            this.Accident_label.AutoSize = true;
            this.Accident_label.Location = new System.Drawing.Point(260, 33);
            this.Accident_label.Name = "Accident_label";
            this.Accident_label.Size = new System.Drawing.Size(65, 13);
            this.Accident_label.TabIndex = 22;
            this.Accident_label.Text = "Аварийная:";
            // 
            // AddChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 405);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.Server_groupBox);
            this.Controls.Add(this.BD_groupBox);
            this.Controls.Add(this.Point_groupBox);
            this.Controls.Add(this.Accident_groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddChannel";
            this.ShowInTaskbar = false;
            this.Text = "Добавить канал:";
            this.Shown += new System.EventHandler(this.AddChannel_Shown);
            this.Server_groupBox.ResumeLayout(false);
            this.Server_groupBox.PerformLayout();
            this.BD_groupBox.ResumeLayout(false);
            this.BD_groupBox.PerformLayout();
            this.Point_groupBox.ResumeLayout(false);
            this.Point_groupBox.PerformLayout();
            this.Accident_groupBox.ResumeLayout(false);
            this.Accident_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox id_ComboBox;
        private System.Windows.Forms.GroupBox Server_groupBox;
        private System.Windows.Forms.Label UIM_BD_label;
        private System.Windows.Forms.Label Id_BD_label;
        private System.Windows.Forms.ComboBox idServer_ComboBox;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.GroupBox BD_groupBox;
        private System.Windows.Forms.Label max_label;
        private System.Windows.Forms.Label min__label;
        private System.Windows.Forms.TextBox min_TBox;
        private System.Windows.Forms.TextBox max_TBox;
        private System.Windows.Forms.CheckBox spetial_CheckBox;
        private System.Windows.Forms.CheckBox onOff_checkBox;
        private System.Windows.Forms.Label Tipe_BD_label;
        private System.Windows.Forms.Label Coefficient_BD_label;
        private System.Windows.Forms.Label Dim_BD_label;
        private System.Windows.Forms.ComboBox type_ComboBox;
        private System.Windows.Forms.TextBox coefficient_TBox;
        private System.Windows.Forms.ComboBox nameDb_ComboBox;
        private System.Windows.Forms.GroupBox Point_groupBox;
        private System.Windows.Forms.TextBox nameControlPoint_TBox;
        private System.Windows.Forms.Label NamePoint_BD_Label;
        private System.Windows.Forms.Label Point_label;
        private System.Windows.Forms.TextBox nameLocation_TextBox;
        private System.Windows.Forms.GroupBox Accident_groupBox;
        private System.Windows.Forms.TextBox preAccident_TBox;
        private System.Windows.Forms.TextBox accident_TBox;
        private System.Windows.Forms.Label PreAccident_label;
        private System.Windows.Forms.Label Accident_label;
    }
}