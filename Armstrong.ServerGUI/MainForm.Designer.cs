using System.Windows.Forms;
using Armstrong.WinServer.Classes;

namespace Armstrong.WinServer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("МЭД");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Воздух");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Спец. контроль");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Не работает");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Категория", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Предаварийная");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Аварийная");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Уставки", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "E3";
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChannelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkSpecialSignalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.globalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_server = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewImageColumn();
            this.name_ControlPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value_impulses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.error_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.on_off = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coefficient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pre_accident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state_for_threeview = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min_nuclid_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max_nuclid_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.special_control = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.value_not_system = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.background = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.graphicToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rewindTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.blowoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewShift_Timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.graphicToolStripMenuItem,
            this.visionToolStripMenuItem,
            this.servicesToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(833, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportExcelToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exportExcelToolStripMenuItem
            // 
            this.exportExcelToolStripMenuItem.Name = "exportExcelToolStripMenuItem";
            this.exportExcelToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exportExcelToolStripMenuItem.Text = "Экспорт в Excel";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // graphicToolStripMenuItem
            // 
            this.graphicToolStripMenuItem.Name = "graphicToolStripMenuItem";
            this.graphicToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.graphicToolStripMenuItem.Text = "График";
            this.graphicToolStripMenuItem.Click += new System.EventHandler(this.ShowChart_Event);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newShiftToolStripMenuItem,
            this.addChannelToolStripMenuItem1});
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.servicesToolStripMenuItem.Text = "Сервис";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.reportToolStripMenuItem.Text = "Отчет";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.blowoutToolStripMenuItem_Click);
            // 
            // newShiftToolStripMenuItem
            // 
            this.newShiftToolStripMenuItem.Name = "newShiftToolStripMenuItem";
            this.newShiftToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newShiftToolStripMenuItem.Text = "Новая смена";
            this.newShiftToolStripMenuItem.Click += new System.EventHandler(this.NewShiftToolStripMenuItem_Click);
            // 
            // addChannelToolStripMenuItem1
            // 
            this.addChannelToolStripMenuItem1.Name = "addChannelToolStripMenuItem1";
            this.addChannelToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.addChannelToolStripMenuItem1.Text = "Добавить канал";
            this.addChannelToolStripMenuItem1.Click += new System.EventHandler(this.addChannelToolStripMenuItem1_Click);
            // 
            // visionToolStripMenuItem
            // 
            this.visionToolStripMenuItem.Name = "visionToolStripMenuItem";
            this.visionToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.visionToolStripMenuItem.Text = "Вид";
            this.visionToolStripMenuItem.Click += new System.EventHandler(this.visionToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(833, 488);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "med";
            treeNode1.Text = "МЭД";
            treeNode2.Name = "air";
            treeNode2.Text = "Воздух";
            treeNode3.Name = "specialcontrol";
            treeNode3.Text = "Спец. контроль";
            treeNode4.Name = "offline";
            treeNode4.Text = "Не работает";
            treeNode5.Checked = true;
            treeNode5.Name = "category";
            treeNode5.Text = "Категория";
            treeNode6.Name = "pre_accident";
            treeNode6.Text = "Предаварийная";
            treeNode7.Name = "accident";
            treeNode7.Text = "Аварийная";
            treeNode8.Name = "warning_control";
            treeNode8.Text = "Уставки";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(137, 488);
            this.treeView1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.globalId,
            this.special_control,
            this.state,
            this.id_server,
            this.id,
            this.name_ControlPoint,
            this.name_db,
            this.name_location,
            this.value,
            this.dim,
            this.value_not_system,
            this.date,
            this.count,
            this.background,
            this.coefficient,
            this.pre_accident,
            this.accident,
            this.value_impulses,
            this.error_count,
            this.type,
            this.on_off,
            this.state_for_threeview,
            this.min_nuclid_value,
            this.max_nuclid_value,});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(692, 488);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_CellMouseDown);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            //
            // special_control
            //
            this.special_control.HeaderText = "СК";
            this.special_control.Name = Map.channel_special_control;
            this.special_control.MinimumWidth = 25;
            this.special_control.Width = 25;
            this.special_control.ReadOnly = false;
            this.special_control.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // globalId
            //
            this.globalId.HeaderText = "ID";
            this.globalId.MinimumWidth = 25;
            this.globalId.Name = Map.channel_global_id;
            this.globalId.ReadOnly = true;
            this.globalId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.globalId.Width = 25;
            this.globalId.Visible = false;
            // 
            // id
            // 
            this.id.HeaderText = "№ к.";
            this.id.MinimumWidth = 25;
            this.id.Name = Map.channel_id;
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 25;
            this.id.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsIdVisible);
            // 
            // id_server
            // 
            this.id_server.HeaderText = "№ с.";
            this.id_server.MinimumWidth = 25;
            this.id_server.Name = Map.id_server;
            this.id_server.ReadOnly = true;
            this.id_server.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id_server.Width = 25;
            this.id_server.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsIdServerVisible);
            // 
            // state
            // 
            this.state.HeaderText = "Индик.";
            this.state.MinimumWidth = 48;
            this.state.Name = Map.channel_image_state;
            this.state.ReadOnly = true;
            this.state.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.state.Width = 48;
            this.state.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsChannelStateVisible);
            // 
            // name_ControlPoint
            // 
            this.name_ControlPoint.HeaderText = "Точка контроля";
            this.name_ControlPoint.MinimumWidth = 100;
            this.name_ControlPoint.Name = Map.control_point;
            this.name_ControlPoint.ReadOnly = true;
            this.name_ControlPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name_ControlPoint.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsControlPointVusuble);
            // 
            // name_db
            // 
            this.name_db.HeaderText = "Блок детект.";
            this.name_db.MinimumWidth = 100;
            this.name_db.Name = Map.block_name;
            this.name_db.ReadOnly = true;
            this.name_db.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name_db.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsDeviceVisible);
            // 
            // name_location
            // 
            this.name_location.HeaderText = "Располож.";
            this.name_location.MinimumWidth = 100;
            this.name_location.Name = Map.block_location;
            this.name_location.ReadOnly = true;
            this.name_location.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name_location.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsLocationVisible);
            // 
            // value
            // 
            this.value.DefaultCellStyle = dataGridViewCellStyle1;
            this.value.HeaderText = "Значение сист.";
            this.value.MinimumWidth = 90;
            this.value.Width = 90;
            this.value.Name = Map.value_system;
            this.value.ReadOnly = true;
            this.value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.value.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsEventValueVisible);
            // 
            // dim
            // 
            this.dim.HeaderText = "Ед. изм.";
            this.dim.MinimumWidth = 60;
            this.dim.Name = Map.unit;
            this.dim.ReadOnly = true;
            this.dim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dim.Width = 60;
            this.dim.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsUnitVisible);
            //
            // value_not_system
            //
            this.value_not_system.DefaultCellStyle = dataGridViewCellStyle1;
            this.value_not_system.HeaderText = "Ки/л мкР/с";
            this.value_not_system.Name = Map.value_not_system;
            this.value_not_system.MinimumWidth = 90;
            this.value_not_system.Width = 90;
            this.value_not_system.ReadOnly = true;
            this.value_not_system.SortMode = DataGridViewColumnSortMode.NotSortable;
            //
            // background
            //
            this.background.DefaultCellStyle = dataGridViewCellStyle1;
            this.background.HeaderText = "Фон";
            this.background.Name = Map.channel_background;
            this.background.MinimumWidth = 90;
            this.background.Width = 90;
            this.background.ReadOnly = true;
            this.background.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // date
            // 
            dataGridViewCellStyle2.Format = "HH:mm:ssss";
            this.date.DefaultCellStyle = dataGridViewCellStyle2;
            this.date.HeaderText = "Дата";
            this.date.MinimumWidth = 60;
            this.date.Width = 60;
            this.date.Name = Map.event_date;
            this.date.ReadOnly = true;
            this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.date.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsEventDateVisible);
            // 
            // count
            // 
            this.count.HeaderText = "Колич.";
            this.count.MinimumWidth = 50;
            this.count.Width = 50;
            this.count.Name = Map.channel_value_unic_count;
            this.count.ReadOnly = true;
            this.count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.count.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsEventCountVisible);
            // 
            // value_impulses
            // 
            this.value_impulses.HeaderText = "Имп./с";
            this.value_impulses.MinimumWidth = 50;
            this.value_impulses.Width = 50;
            this.value_impulses.Name = Map.value_impulses;
            this.value_impulses.ReadOnly = true;
            this.value_impulses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.value_impulses.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsEventImpulseValueVisible);
            // 
            // error_count
            // 
            this.error_count.HeaderText = "Колич. ошиб.";
            this.error_count.MinimumWidth = 50;
            this.error_count.Width = 50;
            this.error_count.Name = Map.channel_value_error_count;
            this.error_count.ReadOnly = true;
            this.error_count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.error_count.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsEventErrorCountVisible);
            // 
            // type
            // 
            this.type.HeaderText = "Тип";
            this.type.MinimumWidth = 50;
            this.type.Width = 50;
            this.type.Name = Map.block_type;
            this.type.ReadOnly = true;
            this.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.type.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsDeviceTypeVisible);
            // 
            // on_off
            // 
            this.on_off.HeaderText = "Вкл/Выкл";
            this.on_off.MinimumWidth = 50;
            this.on_off.Width = 50;
            this.on_off.Name = Map.channel_power_state;
            this.on_off.ReadOnly = true;
            this.on_off.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.on_off.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsChannelActiveVisible);
            // 
            // coefficient
            // 
            this.coefficient.HeaderText = "Коэфф.";
            this.coefficient.MinimumWidth = 50;
            this.coefficient.Width = 50;
            this.coefficient.Name = Map.channel_coefficient;
            this.coefficient.ReadOnly = true;
            this.coefficient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.coefficient.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsChannelCoefficientVisible);
            // 
            // pre_accident
            //
            this.pre_accident.DefaultCellStyle = dataGridViewCellStyle1;
            this.pre_accident.HeaderText = "Предавар. уст.";
            this.pre_accident.MinimumWidth = 90;
            this.pre_accident.Width = 90;
            this.pre_accident.Name = Map.channel_pre_accident;
            this.pre_accident.ReadOnly = true;
            this.pre_accident.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pre_accident.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsChannelPreEmergencyVisible);
            // 
            // accident
            //
            this.accident.DefaultCellStyle = dataGridViewCellStyle1;
            this.accident.HeaderText = "Авар. уст.";
            this.accident.MinimumWidth = 90;
            this.accident.Width = 90;
            this.accident.Name = Map.channel_accident;
            this.accident.ReadOnly = true;
            this.accident.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.accident.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsChannelEmergencyVisible);
            // 
            // state_for_threeview
            // 
            this.state_for_threeview.HeaderText = "Сост.";
            this.state_for_threeview.MinimumWidth = 50;
            this.state_for_threeview.Width = 50;
            this.state_for_threeview.Name = Map.channel_state;
            this.state_for_threeview.ReadOnly = true;
            this.state_for_threeview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.state_for_threeview.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsStateForTreeVisible);
            // 
            // min_nuclid_value
            //
            this.min_nuclid_value.DefaultCellStyle = dataGridViewCellStyle1;
            this.min_nuclid_value.HeaderText = "Мин. от нуклида";
            this.min_nuclid_value.MinimumWidth = 90;
            this.min_nuclid_value.Width = 90;
            this.min_nuclid_value.Name = Map.block_min_nuclid;
            this.min_nuclid_value.ReadOnly = true;
            this.min_nuclid_value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.min_nuclid_value.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsDeviceMinReferenceValue);
            // 
            // max_nuclid_value
            //
            this.max_nuclid_value.DefaultCellStyle = dataGridViewCellStyle1;
            this.max_nuclid_value.HeaderText = "Макс. от нуклида";
            this.max_nuclid_value.MinimumWidth = 90;
            this.max_nuclid_value.Width = 90;
            this.max_nuclid_value.Name = Map.block_max_nuclid;
            this.max_nuclid_value.ReadOnly = true;
            this.max_nuclid_value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.max_nuclid_value.Visible = SettingsVariable.GetValue<bool>(Constants.GridVisibleSettingName.IsDeviceMaxReferenceValue);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(833, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel1.Text = "Статус-панель";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphicToolStripMenuItem1,
            this.blowoutToolStripMenuItem,
            this.toolStripMenuItem5,
            this.checkChannelToolStripMenuItem,
            this.rewindTapeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.addChannelToolStripMenuItem,
            this.removeChannelToolStripMenuItem,
            this.toolStripMenuItem3,
            this.optionsChannelToolStripMenuItem,
            this.toolStripMenuItem4,
            this.checkSpecialSignalMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 246);
            // 
            // graphicToolStripMenuItem1
            // 
            this.graphicToolStripMenuItem1.Name = "graphicToolStripMenuItem1";
            this.graphicToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.graphicToolStripMenuItem1.Text = "График";
            this.graphicToolStripMenuItem1.Click += new System.EventHandler(this.ShowChart_Event);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem5.Text = "__________________";
            // 
            // checkChannelToolStripMenuItem
            // 
            this.checkChannelToolStripMenuItem.Name = "checkChannelToolStripMenuItem";
            this.checkChannelToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.checkChannelToolStripMenuItem.Text = "Проверка";
            // 
            // rewindTapeToolStripMenuItem
            // 
            this.rewindTapeToolStripMenuItem.Name = "rewindTapeToolStripMenuItem";
            this.rewindTapeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.rewindTapeToolStripMenuItem.Text = "Перемотка";
            this.rewindTapeToolStripMenuItem.Click += new System.EventHandler(this.rewindTapeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem2.Text = "__________________";
            // 
            // addChannelToolStripMenuItem
            // 
            this.addChannelToolStripMenuItem.Name = "addChannelToolStripMenuItem";
            this.addChannelToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.addChannelToolStripMenuItem.Text = "Добавить канал";
            this.addChannelToolStripMenuItem.Click += new System.EventHandler(this.AddChannelToolStripMenuItem_Click);
            // 
            // removeChannelToolStripMenuItem
            // 
            this.removeChannelToolStripMenuItem.Name = "removeChannelToolStripMenuItem";
            this.removeChannelToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.removeChannelToolStripMenuItem.Text = "Удалить канал";
            this.removeChannelToolStripMenuItem.Click += new System.EventHandler(this.RemoveChannelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem3.Text = "__________________";
            // 
            // optionsChannelToolStripMenuItem
            // 
            this.optionsChannelToolStripMenuItem.Name = "optionsChannelToolStripMenuItem";
            this.optionsChannelToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.optionsChannelToolStripMenuItem.Text = "Настройки канала";
            this.optionsChannelToolStripMenuItem.Click += new System.EventHandler(this.OptionsChannelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem4.Text = "__________________";
            // 
            // blowoutToolStripMenuItem
            // 
            this.blowoutToolStripMenuItem.Name = "blowoutToolStripMenuItem";
            this.blowoutToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.blowoutToolStripMenuItem.Text = "Расч. Выброс";
            this.blowoutToolStripMenuItem.Click += new System.EventHandler(this.blowoutToolStripMenuItem_Click);
            //
            // checkSpecialSignalMenuItem
            //
            this.checkSpecialSignalMenuItem.Name = "checkSpecialSignalMenuItem";
            this.checkSpecialSignalMenuItem.Size = new System.Drawing.Size(175, 22);
            this.checkSpecialSignalMenuItem.Text = "Тест СК";
            this.checkSpecialSignalMenuItem.Click += new System.EventHandler(this.checkSpecialSignalMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 534);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = $"{Application.ProductName} | " +
                $"{SettingsVariable.GetValue<string>(Constants.SettingName.ComPortName)} | " +
                $"{SettingsVariable.GetValue(Constants.EnvirovmentVariableName.HostName)}";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem checkChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewindTapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem optionsChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkSpecialSignalMenuItem;
        private ToolStripMenuItem exportExcelToolStripMenuItem;
        private ToolStripMenuItem servicesToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem newShiftToolStripMenuItem;
        private ToolStripMenuItem visionToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem blowoutToolStripMenuItem;
        private Timer NewShift_Timer;
        private DataGridViewTextBoxColumn globalId;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn id_server;
        private DataGridViewImageColumn state;
        private DataGridViewTextBoxColumn name_db;
        private DataGridViewTextBoxColumn name_location;
        private DataGridViewTextBoxColumn value;
        private DataGridViewTextBoxColumn dim;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn count;
        private DataGridViewTextBoxColumn value_impulses;
        private DataGridViewTextBoxColumn error_count;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn name_ControlPoint;
        private DataGridViewTextBoxColumn on_off;
        private DataGridViewTextBoxColumn coefficient;
        private DataGridViewTextBoxColumn pre_accident;
        private DataGridViewTextBoxColumn accident;
        private DataGridViewTextBoxColumn state_for_threeview;
        private DataGridViewTextBoxColumn min_nuclid_value;
        private DataGridViewTextBoxColumn max_nuclid_value;
        private DataGridViewCheckBoxColumn special_control;
        private DataGridViewTextBoxColumn value_not_system;
        private DataGridViewTextBoxColumn background;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem addChannelToolStripMenuItem1;
        private ToolStripMenuItem graphicToolStripMenuItem1;

        public TreeView TreeView1 { get => treeView1; }
    }
}

