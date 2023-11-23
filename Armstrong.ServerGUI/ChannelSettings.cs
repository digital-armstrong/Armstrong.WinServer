using Armstrong.WinServer.Classes;
using Npgsql;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Armstrong.WinServer
{
    public partial class ChannelSettings : Form
    {
        int type = 1, onOff = 1, channelState = 3;

        public ChannelSettings()
        {
            InitializeComponent();
            Server_groupBox.Enabled = false;
            spetial_CheckBox.Enabled = false;
        }

        private void ChangeChannel_Shown(object sender, EventArgs e)
        {
            MainForm main = Owner as MainForm;

            switch ((int)main.dataGridView1.SelectedRows[0].Cells[Map.block_type].Value)
            {
                case 1:
                    type_ComboBox.Text = "Частотный";
                    break;
                case 2:
                    type_ComboBox.Text = "Временной";
                    break;
                case 3:
                    type_ComboBox.Text = "Лентопротяж. механизм";
                    break;
            }

            id_ComboBox.Text = main.dataGridView1.SelectedRows[0].Cells[Map.channel_global_id].Value.ToString();
            idServer_ComboBox.Text = main.dataGridView1.SelectedRows[0].Cells[Map.id_server].Value.ToString();
            nameControlPoint_TBox.Text = main.dataGridView1.SelectedRows[0].Cells[Map.control_point].Value.ToString();
            nameDb_ComboBox.Text = main.dataGridView1.SelectedRows[0].Cells[Map.block_name].Value.ToString();
            nameLocation_TextBox.Text = main.dataGridView1.SelectedRows[0].Cells[Map.block_location].Value.ToString();

            switch ((int)main.dataGridView1.SelectedRows[0].Cells[Map.channel_power_state].Value)
            {
                case 0:
                    onOff_checkBox.Checked = false;
                    break;
                case 1:
                    onOff_checkBox.Checked = true;
                    break;
            }

            coefficient_TBox.Text = main.dataGridView1.SelectedRows[0].Cells[Map.channel_coefficient].Value.ToString();
            preAccident_TBox.Text = Convert.ToDouble(main.dataGridView1.SelectedRows[0].Cells[Map.channel_pre_accident].Value)
                .ToString("E3");
            accident_TBox.Text = Convert.ToDouble(main.dataGridView1.SelectedRows[0].Cells[Map.channel_accident].Value)
                .ToString("E3");
            min_TBox.Text = Convert.ToDouble(main.dataGridView1.SelectedRows[0].Cells[Map.block_min_nuclid].Value)
                .ToString("E3");
            max_TBox.Text = Convert.ToDouble(main.dataGridView1.SelectedRows[0].Cells[Map.block_max_nuclid].Value)
                .ToString("E3");
            background_TBox.Text = Convert.ToDouble(main.dataGridView1.SelectedRows[0].Cells[Map.channel_background].Value)
                .ToString("E3");
        }

        private void nameDb_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nameDb_ComboBox.SelectedIndex == 0 ||
               nameDb_ComboBox.SelectedIndex == 11 ||
               nameDb_ComboBox.SelectedIndex == 12 ||
               nameDb_ComboBox.SelectedIndex == 13)
            {
                type_ComboBox.Text = "Лентопротяж. механизм";
                if (nameDb_ComboBox.SelectedIndex == 0)
                {
                    coefficient_TBox.Text = "2,0592";
                }
                else
                {
                    coefficient_TBox.Text = "1";
                }
            }
            if (nameDb_ComboBox.SelectedIndex == 1 ||
               nameDb_ComboBox.SelectedIndex == 2)
            {
                type_ComboBox.Text = "Временной";
                coefficient_TBox.Text = "0.0000019";
            }

            if (nameDb_ComboBox.SelectedIndex == 3 ||
                nameDb_ComboBox.SelectedIndex == 4 ||
                nameDb_ComboBox.SelectedIndex == 10)
            {
                type_ComboBox.Text = "Частотный";
                coefficient_TBox.Text = "1";
            }
            // БДМГ-08Р-04 и БДМГ-41-01
            if (nameDb_ComboBox.SelectedIndex == 5 ||
               nameDb_ComboBox.SelectedIndex == 8)
            {
                type_ComboBox.Text = "Частотный";
                coefficient_TBox.Text = "3.6";
            }
            // БДМГ-08Р-05
            if (nameDb_ComboBox.SelectedIndex == 6)
            {
                type_ComboBox.Text = "Частотный";
                coefficient_TBox.Text = "1000";
            }
            // БДМГ-41
            if (nameDb_ComboBox.SelectedIndex == 7)
            {
                type_ComboBox.Text = "Частотный";
                coefficient_TBox.Text = "0.36";
            }
            // БДМГ-41-03
            if (nameDb_ComboBox.SelectedIndex == 9)
            {
                type_ComboBox.Text = "Частотный";
                coefficient_TBox.Text = "36";
            }
            //БДД-01
            if (nameDb_ComboBox.SelectedIndex == 15)
            {
                type_ComboBox.Text = "Импульсный";
                coefficient_TBox.Text = "1";

            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            MainForm main = Owner as MainForm;

            if (
                string.IsNullOrEmpty(coefficient_TBox.Text) ||
                string.IsNullOrEmpty(preAccident_TBox.Text) ||
                string.IsNullOrEmpty(accident_TBox.Text) ||
                string.IsNullOrEmpty(min_TBox.Text) ||
                string.IsNullOrEmpty(max_TBox.Text) ||
                string.IsNullOrEmpty(background_TBox.Text)
                )
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            Double coefficientParameter = Double.Parse(coefficient_TBox.Text, CultureInfo.CurrentCulture);
            Double preAccidentParameter = Double.Parse(preAccident_TBox.Text, CultureInfo.CurrentCulture);
            Double accidentParameter = Double.Parse(accident_TBox.Text, CultureInfo.CurrentCulture);
            Double minParameter = Double.Parse(min_TBox.Text, CultureInfo.CurrentCulture);
            Double maxParameter = Double.Parse(max_TBox.Text, CultureInfo.CurrentCulture);
            Double backgroundParameter = Double.Parse(background_TBox.Text, CultureInfo.CurrentCulture);

            switch (type_ComboBox.Text)
            {
                case "Частотный":
                    type = DetectorsInfo.TypeED;
                    break;
                case "Временной":
                    type = DetectorsInfo.TypeOG;
                    break;
                case "Лентопротяж. механизм":
                    type = DetectorsInfo.TypeOA;
                    break;
                case "Импульсный":
                    type = DetectorsInfo.TypeIC;
                    break;
            }
            switch (onOff_checkBox.Checked)
            {
                case true:
                    onOff = DetectorsInfo.Power_ON;
                    break;
                case false:
                    onOff = DetectorsInfo.Power_OFF;
                    channelState = DetectorsInfo.StatePowerOff;
                    break;
            }

            string connectionString = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.ConnectionString);
            string monitorTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.MonitorTable);

            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand saveChannelOption = new NpgsqlCommand($"UPDATE {monitorTable} SET " +
                $"{Map.channel_state}='{channelState}', " +
                $"{Map.control_point}='{nameControlPoint_TBox.Text}', " +
                $"{Map.block_name}='{nameDb_ComboBox.Text}', " +
                $"{Map.block_location}='{nameLocation_TextBox.Text}', " +
                $"{Map.channel_power_state}={onOff}, " +
                $"{Map.channel_coefficient}=@coefficient, " +
                $"{Map.channel_pre_accident}=@pre_accident, " +
                $"{Map.channel_accident}=@accident, " +
                $"{Map.block_type}={type}, " +
                $"{Map.block_min_nuclid}=@min_nuclid_value, " +
                $"{Map.block_max_nuclid}=@max_nuclid_value, " +
                $"{Map.channel_background}=@background " +
                $"WHERE {Map.channel_global_id}={id_ComboBox.Text}", connection);

            try
            {
                connection.Open();

                saveChannelOption.Parameters.Add("@coefficient", NpgsqlTypes.NpgsqlDbType.Double);
                saveChannelOption.Parameters[0].Value = coefficientParameter;

                saveChannelOption.Parameters.Add("@pre_accident", NpgsqlTypes.NpgsqlDbType.Double);
                saveChannelOption.Parameters[1].Value = preAccidentParameter;

                saveChannelOption.Parameters.Add("@accident", NpgsqlTypes.NpgsqlDbType.Double);
                saveChannelOption.Parameters[2].Value = accidentParameter;

                saveChannelOption.Parameters.Add("@min_nuclid_value", NpgsqlTypes.NpgsqlDbType.Double);
                saveChannelOption.Parameters[3].Value = minParameter;

                saveChannelOption.Parameters.Add("@max_nuclid_value", NpgsqlTypes.NpgsqlDbType.Double);
                saveChannelOption.Parameters[4].Value = maxParameter;

                saveChannelOption.Parameters.Add("@background", NpgsqlTypes.NpgsqlDbType.Double);
                saveChannelOption.Parameters[5].Value = backgroundParameter;

                saveChannelOption.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Произошла ошибка при загрузке изменений в базу данных.\nПроверьте соединение с SQL-сервером.\n\nИнформация по ошибке:\n" + exc);
            }

            Close();
        }
    }
}
