using System;
using System.Windows.Forms;
using Armstrong.WinServer.Classes;

namespace Armstrong.WinServer
{
    public partial class ChannelAdd : Form
    {
        int count, id, type, onOff;
        SQL sql = new SQL();

        private void nameDb_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nameDb_ComboBox.SelectedIndex == 0 ||
                nameDb_ComboBox.SelectedIndex == 11 || 
                nameDb_ComboBox.SelectedIndex == 12 || 
                nameDb_ComboBox.SelectedIndex == 13)
            {
                type_ComboBox.Text = "Лентопротяж. механизм";
                if (nameDb_ComboBox.SelectedIndex == 0)
                    coefficient_TBox.Text = "2,0592";
                else
                    coefficient_TBox.Text = "1";
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
            if(nameDb_ComboBox.SelectedIndex ==  5 ||
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
        }

        public ChannelAdd()
        {
            InitializeComponent();
            id_ComboBox.Enabled = false;
        }

        private void AddChannel_Shown(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            count = main.dataGridView1.Rows.Count;

            if (count != 0)
                id = ++count;
            else
                id = 1;

            id_ComboBox.Text = id.ToString();

            coefficient_TBox.Text = "1";
            accident_TBox.Text = "10";
            preAccident_TBox.Text = "1";
            min_TBox.Text = "1";
            max_TBox.Text = "2";
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            Double coefficientParameter, preAccidentParameter, accidentParameter, minParameter, maxParameter;

            if (
                !string.IsNullOrEmpty(coefficient_TBox.Text) &&
                !string.IsNullOrEmpty(preAccident_TBox.Text) &&
                !string.IsNullOrEmpty(accident_TBox.Text) &&
                !string.IsNullOrEmpty(min_TBox.Text) &&
                !string.IsNullOrEmpty(max_TBox.Text)
                )
            {
                coefficientParameter = Convert.ToDouble(coefficient_TBox.Text.Replace(".", ","));
                preAccidentParameter = Convert.ToDouble(preAccident_TBox.Text.Replace(".", ","));
                accidentParameter = Convert.ToDouble(accident_TBox.Text.Replace(".", ","));
                minParameter = Convert.ToDouble(min_TBox.Text.Replace(".", ","));
                maxParameter = Convert.ToDouble(max_TBox.Text.Replace(".", ","));
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            switch (type_ComboBox.Text)
            {
                case "Частотный":
                    type = 1;
                    break;
                case "Временной":
                    type = 2;
                    break;
                case "Лентопротяж. механизм":
                    type = 3;
                    break;
            }

            switch (onOff_checkBox.Checked)
            {
                case true:
                    onOff = 1;
                    break;
                case false:
                    onOff = 0;
                    break;
            }

            string columnNameString = $"{Map.channel_id}, {Map.id_server}, {Map.control_point}, {Map.block_name}, {Map.block_location}, {Map.value_system}, {Map.event_date}, {Map.channel_power_state}, {Map.channel_coefficient}, {Map.channel_pre_accident}, {Map.channel_accident}, {Map.block_type}, {Map.channel_value_unic_count}, {Map.value_impulses}, {Map.channel_value_error_count}, {Map.channel_state}, {Map.block_min_nuclid}, {Map.block_max_nuclid}";
            string valuesString = @"" + id + ", " + idServer_ComboBox.Text + ", '" + nameControlPoint_TBox.Text + "', '" + nameDb_ComboBox.Text + "', '" + nameLocation_TextBox.Text + "', 0, '" + DateTime.Now.ToString() + "', " + onOff + ", @coefficient, @pre_accident, @accident, " + type + ", 0, 0, 0, 3, @min_nuclid_value, @max_nuclid_value";


            sql.Insert(columnNameString, valuesString, coefficientParameter, preAccidentParameter, accidentParameter, minParameter, maxParameter);

            DataGridViewRow row = new DataGridViewRow();
            foreach (DataGridViewRow item in main.dataGridView1.SelectedRows)
                main.dataGridView1.Rows.RemoveAt(item.Index);

            Close();
        }
    }
}
