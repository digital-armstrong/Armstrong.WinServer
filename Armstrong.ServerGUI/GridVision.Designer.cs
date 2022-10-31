namespace Armstrong.WinServer
{
    partial class GridVision
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
            this.id = new System.Windows.Forms.CheckBox();
            this.idServer = new System.Windows.Forms.CheckBox();
            this.state = new System.Windows.Forms.CheckBox();
            this.name_controlPoint = new System.Windows.Forms.CheckBox();
            this.name_db = new System.Windows.Forms.CheckBox();
            this.name_location = new System.Windows.Forms.CheckBox();
            this.value = new System.Windows.Forms.CheckBox();
            this.dim = new System.Windows.Forms.CheckBox();
            this.date = new System.Windows.Forms.CheckBox();
            this.on_off = new System.Windows.Forms.CheckBox();
            this.pre_accident = new System.Windows.Forms.CheckBox();
            this.coefficient = new System.Windows.Forms.CheckBox();
            this.accident = new System.Windows.Forms.CheckBox();
            this.type = new System.Windows.Forms.CheckBox();
            this.count = new System.Windows.Forms.CheckBox();
            this.value_impulses = new System.Windows.Forms.CheckBox();
            this.error_count = new System.Windows.Forms.CheckBox();
            this.state_for_treeview = new System.Windows.Forms.CheckBox();
            this.min_nuclid_value = new System.Windows.Forms.CheckBox();
            this.max_nuclid_value = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(12, 12);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(37, 17);
            this.id.TabIndex = 0;
            this.id.Text = "№";
            this.id.UseVisualStyleBackColor = true;
            this.id.CheckedChanged += new System.EventHandler(this.id_CheckedChanged);
            // 
            // idServer
            // 
            this.idServer.AutoSize = true;
            this.idServer.Location = new System.Drawing.Point(12, 35);
            this.idServer.Name = "idServer";
            this.idServer.Size = new System.Drawing.Size(83, 17);
            this.idServer.TabIndex = 1;
            this.idServer.Text = "№ Сервера";
            this.idServer.UseVisualStyleBackColor = true;
            this.idServer.CheckedChanged += new System.EventHandler(this.idServer_CheckedChanged);
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(12, 58);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(82, 17);
            this.state.TabIndex = 2;
            this.state.Text = "Индикация";
            this.state.UseVisualStyleBackColor = true;
            this.state.CheckedChanged += new System.EventHandler(this.state_CheckedChanged);
            // 
            // name_controlPoint
            // 
            this.name_controlPoint.AutoSize = true;
            this.name_controlPoint.Location = new System.Drawing.Point(12, 81);
            this.name_controlPoint.Name = "name_controlPoint";
            this.name_controlPoint.Size = new System.Drawing.Size(106, 17);
            this.name_controlPoint.TabIndex = 3;
            this.name_controlPoint.Text = "Точка контроля";
            this.name_controlPoint.UseVisualStyleBackColor = true;
            this.name_controlPoint.CheckedChanged += new System.EventHandler(this.name_controlPoint_CheckedChanged);
            // 
            // name_db
            // 
            this.name_db.AutoSize = true;
            this.name_db.Location = new System.Drawing.Point(12, 104);
            this.name_db.Name = "name_db";
            this.name_db.Size = new System.Drawing.Size(136, 17);
            this.name_db.TabIndex = 4;
            this.name_db.Text = "Блок детектирования";
            this.name_db.UseVisualStyleBackColor = true;
            this.name_db.CheckedChanged += new System.EventHandler(this.name_db_CheckedChanged);
            // 
            // name_location
            // 
            this.name_location.AutoSize = true;
            this.name_location.Location = new System.Drawing.Point(12, 127);
            this.name_location.Name = "name_location";
            this.name_location.Size = new System.Drawing.Size(101, 17);
            this.name_location.TabIndex = 5;
            this.name_location.Text = "Расположение";
            this.name_location.UseVisualStyleBackColor = true;
            this.name_location.CheckedChanged += new System.EventHandler(this.name_location_CheckedChanged);
            // 
            // value
            // 
            this.value.AutoSize = true;
            this.value.Location = new System.Drawing.Point(12, 150);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(74, 17);
            this.value.TabIndex = 6;
            this.value.Text = "Значение";
            this.value.UseVisualStyleBackColor = true;
            this.value.CheckedChanged += new System.EventHandler(this.value_CheckedChanged);
            // 
            // dim
            // 
            this.dim.AutoSize = true;
            this.dim.Location = new System.Drawing.Point(12, 173);
            this.dim.Name = "dim";
            this.dim.Size = new System.Drawing.Size(130, 17);
            this.dim.TabIndex = 7;
            this.dim.Text = "Единицы измерения";
            this.dim.UseVisualStyleBackColor = true;
            this.dim.CheckedChanged += new System.EventHandler(this.dim_CheckedChanged);
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(12, 196);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(52, 17);
            this.date.TabIndex = 8;
            this.date.Text = "Дата";
            this.date.UseVisualStyleBackColor = true;
            this.date.CheckedChanged += new System.EventHandler(this.date_CheckedChanged);
            // 
            // on_off
            // 
            this.on_off.AutoSize = true;
            this.on_off.Location = new System.Drawing.Point(12, 219);
            this.on_off.Name = "on_off";
            this.on_off.Size = new System.Drawing.Size(77, 17);
            this.on_off.TabIndex = 9;
            this.on_off.Text = "Вкл/Выкл";
            this.on_off.UseVisualStyleBackColor = true;
            this.on_off.CheckedChanged += new System.EventHandler(this.on_off_CheckedChanged);
            // 
            // pre_accident
            // 
            this.pre_accident.AutoSize = true;
            this.pre_accident.Location = new System.Drawing.Point(154, 35);
            this.pre_accident.Name = "pre_accident";
            this.pre_accident.Size = new System.Drawing.Size(149, 17);
            this.pre_accident.TabIndex = 11;
            this.pre_accident.Text = "Предаварийная уставка";
            this.pre_accident.UseVisualStyleBackColor = true;
            this.pre_accident.CheckedChanged += new System.EventHandler(this.pre_accident_CheckedChanged);
            // 
            // coefficient
            // 
            this.coefficient.AutoSize = true;
            this.coefficient.Location = new System.Drawing.Point(154, 12);
            this.coefficient.Name = "coefficient";
            this.coefficient.Size = new System.Drawing.Size(96, 17);
            this.coefficient.TabIndex = 10;
            this.coefficient.Text = "Коэффициент";
            this.coefficient.UseVisualStyleBackColor = true;
            this.coefficient.CheckedChanged += new System.EventHandler(this.coefficient_CheckedChanged);
            // 
            // accident
            // 
            this.accident.AutoSize = true;
            this.accident.Location = new System.Drawing.Point(154, 58);
            this.accident.Name = "accident";
            this.accident.Size = new System.Drawing.Size(124, 17);
            this.accident.TabIndex = 12;
            this.accident.Text = "Аварийная уставка";
            this.accident.UseVisualStyleBackColor = true;
            this.accident.CheckedChanged += new System.EventHandler(this.accident_CheckedChanged);
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Location = new System.Drawing.Point(154, 81);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(45, 17);
            this.type.TabIndex = 13;
            this.type.Text = "Тип";
            this.type.UseVisualStyleBackColor = true;
            this.type.CheckedChanged += new System.EventHandler(this.type_CheckedChanged);
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Location = new System.Drawing.Point(154, 104);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(161, 17);
            this.count.TabIndex = 14;
            this.count.Text = "Кол. уникальных значений";
            this.count.UseVisualStyleBackColor = true;
            this.count.CheckedChanged += new System.EventHandler(this.count_CheckedChanged);
            // 
            // value_impulses
            // 
            this.value_impulses.AutoSize = true;
            this.value_impulses.Location = new System.Drawing.Point(154, 127);
            this.value_impulses.Name = "value_impulses";
            this.value_impulses.Size = new System.Drawing.Size(106, 17);
            this.value_impulses.TabIndex = 15;
            this.value_impulses.Text = "Импульсов/сек";
            this.value_impulses.UseVisualStyleBackColor = true;
            this.value_impulses.CheckedChanged += new System.EventHandler(this.value_impulses_CheckedChanged);
            // 
            // error_count
            // 
            this.error_count.AutoSize = true;
            this.error_count.Location = new System.Drawing.Point(154, 150);
            this.error_count.Name = "error_count";
            this.error_count.Size = new System.Drawing.Size(173, 17);
            this.error_count.TabIndex = 16;
            this.error_count.Text = "Кол. неуникальных значений";
            this.error_count.UseVisualStyleBackColor = true;
            this.error_count.CheckedChanged += new System.EventHandler(this.error_count_CheckedChanged);
            // 
            // state_for_treeview
            // 
            this.state_for_treeview.AutoSize = true;
            this.state_for_treeview.Location = new System.Drawing.Point(154, 173);
            this.state_for_treeview.Name = "state_for_treeview";
            this.state_for_treeview.Size = new System.Drawing.Size(80, 17);
            this.state_for_treeview.TabIndex = 17;
            this.state_for_treeview.Text = "Состояние";
            this.state_for_treeview.UseVisualStyleBackColor = true;
            this.state_for_treeview.CheckedChanged += new System.EventHandler(this.state_for_treeview_CheckedChanged);
            // 
            // min_nuclid_value
            // 
            this.min_nuclid_value.AutoSize = true;
            this.min_nuclid_value.Location = new System.Drawing.Point(154, 196);
            this.min_nuclid_value.Name = "min_nuclid_value";
            this.min_nuclid_value.Size = new System.Drawing.Size(148, 17);
            this.min_nuclid_value.TabIndex = 18;
            this.min_nuclid_value.Text = "Мин. знач. от источника";
            this.min_nuclid_value.UseVisualStyleBackColor = true;
            this.min_nuclid_value.CheckedChanged += new System.EventHandler(this.min_nuclid_value_CheckedChanged);
            // 
            // max_nuclid_value
            // 
            this.max_nuclid_value.AutoSize = true;
            this.max_nuclid_value.Location = new System.Drawing.Point(154, 219);
            this.max_nuclid_value.Name = "max_nuclid_value";
            this.max_nuclid_value.Size = new System.Drawing.Size(154, 17);
            this.max_nuclid_value.TabIndex = 19;
            this.max_nuclid_value.Text = "Макс. знач. от источника";
            this.max_nuclid_value.UseVisualStyleBackColor = true;
            this.max_nuclid_value.CheckedChanged += new System.EventHandler(this.max_nuclid_value_CheckedChanged);
            // 
            // GridVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 253);
            this.Controls.Add(this.max_nuclid_value);
            this.Controls.Add(this.min_nuclid_value);
            this.Controls.Add(this.state_for_treeview);
            this.Controls.Add(this.error_count);
            this.Controls.Add(this.value_impulses);
            this.Controls.Add(this.count);
            this.Controls.Add(this.type);
            this.Controls.Add(this.accident);
            this.Controls.Add(this.coefficient);
            this.Controls.Add(this.pre_accident);
            this.Controls.Add(this.on_off);
            this.Controls.Add(this.date);
            this.Controls.Add(this.dim);
            this.Controls.Add(this.value);
            this.Controls.Add(this.name_location);
            this.Controls.Add(this.name_db);
            this.Controls.Add(this.name_controlPoint);
            this.Controls.Add(this.state);
            this.Controls.Add(this.idServer);
            this.Controls.Add(this.id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GridVision";
            this.Text = "Вид:";
            this.Shown += new System.EventHandler(this.GridVision_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox id;
        private System.Windows.Forms.CheckBox idServer;
        private System.Windows.Forms.CheckBox state;
        private System.Windows.Forms.CheckBox name_controlPoint;
        private System.Windows.Forms.CheckBox name_db;
        private System.Windows.Forms.CheckBox name_location;
        private System.Windows.Forms.CheckBox value;
        private System.Windows.Forms.CheckBox dim;
        private System.Windows.Forms.CheckBox date;
        private System.Windows.Forms.CheckBox on_off;
        private System.Windows.Forms.CheckBox pre_accident;
        private System.Windows.Forms.CheckBox coefficient;
        private System.Windows.Forms.CheckBox accident;
        private System.Windows.Forms.CheckBox type;
        private System.Windows.Forms.CheckBox count;
        private System.Windows.Forms.CheckBox value_impulses;
        private System.Windows.Forms.CheckBox error_count;
        private System.Windows.Forms.CheckBox state_for_treeview;
        private System.Windows.Forms.CheckBox min_nuclid_value;
        private System.Windows.Forms.CheckBox max_nuclid_value;
    }
}