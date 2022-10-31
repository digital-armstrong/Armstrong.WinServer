using System;
using System.Linq;
using System.Windows.Forms;
using Armstrong.WinServer.Classes;
using Armstrong.WinServer.Properties;

namespace Armstrong.WinServer
{
    public partial class GridVision : Form
    {
        private MainForm mainForm;
        public GridVision(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        /// <summary>
        /// Расставляет чекбоксы в состояние, соответствующее dataGridView.Column[i].Visible
        /// </summary>
        private void GridVision_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i < mainForm.dataGridView1.Columns.Count; i++)
            {
                CheckBox checkStatus = Controls.OfType<CheckBox>().FirstOrDefault(checkBox => checkBox.TabIndex == i);
                if (checkStatus != null)
                    checkStatus.Checked = mainForm.dataGridView1.Columns[i].Visible;
            }
        }

        #region Check Change events
        private void id_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = id.Checked;

            mainForm.dataGridView1.Columns[Map.channel_id].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsIdVisible,
                                    value: isChecked);
        }

        private void idServer_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = idServer.Checked;

            mainForm.dataGridView1.Columns[Map.id_server].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsIdServerVisible,
                                    value: isChecked);
        }
        private void state_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = state.Checked;

            mainForm.dataGridView1.Columns[Map.channel_image_state].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsChannelStateVisible,
                                    value: isChecked);
        }

        private void name_controlPoint_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = name_controlPoint.Checked;

            mainForm.dataGridView1.Columns[Map.control_point].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsControlPointVusuble,
                                    value: isChecked);
        }

        private void name_db_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked =  name_db.Checked;

            mainForm.dataGridView1.Columns[Map.block_name].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsDeviceVisible,
                                    value: isChecked);
        }

        private void name_location_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = name_location.Checked;

            mainForm.dataGridView1.Columns[Map.block_location].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsLocationVisible,
                                    value: isChecked);
        }

        private void value_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = value.Checked;

            mainForm.dataGridView1.Columns[Map.value_system].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsEventValueVisible,
                                    value: isChecked);
        }

        private void dim_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = dim.Checked;

            mainForm.dataGridView1.Columns[Map.unit].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsUnitVisible,
                                    value: isChecked);
        }

        private void date_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = date.Checked; 

            mainForm.dataGridView1.Columns[Map.event_date].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsEventDateVisible,
                                     value: isChecked);
        }

        private void on_off_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = on_off.Checked;

            mainForm.dataGridView1.Columns[Map.channel_power_state].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsChannelActiveVisible,
                                    value: isChecked);
        }

        private void coefficient_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = coefficient.Checked;

            mainForm.dataGridView1.Columns[Map.channel_coefficient].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsChannelCoefficientVisible,
                                    value: isChecked);
        }

        private void pre_accident_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = pre_accident.Checked;

            mainForm.dataGridView1.Columns[Map.channel_pre_accident].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsChannelPreEmergencyVisible,
                                    value: isChecked);
        }

        private void accident_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = accident.Checked;

            mainForm.dataGridView1.Columns[Map.channel_accident].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsChannelEmergencyVisible,
                                    value: isChecked);
        }

        private void type_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = type.Checked;

            mainForm.dataGridView1.Columns[Map.block_type].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsDeviceTypeVisible,
                                    value: isChecked);
        }

        private void count_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = count.Checked;

            mainForm.dataGridView1.Columns[Map.channel_value_unic_count].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsEventCountVisible,
                                    value: isChecked);
        }

        private void value_impulses_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = value_impulses.Checked;

            mainForm.dataGridView1.Columns[Map.value_impulses].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsEventImpulseValueVisible,
                                    value: isChecked);
        }

        private void error_count_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = error_count.Checked;

            mainForm.dataGridView1.Columns[Map.channel_value_error_count].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsEventErrorCountVisible,
                                    value: isChecked);
        }

        private void state_for_treeview_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = state_for_treeview.Checked;

            mainForm.dataGridView1.Columns[Map.channel_state].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsStateForTreeVisible,
                                    value: isChecked);
        }

        private void min_nuclid_value_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = min_nuclid_value.Checked;

            mainForm.dataGridView1.Columns[Map.block_min_nuclid].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsDeviceMinReferenceValue,
                                    value: isChecked);
        }

        private void max_nuclid_value_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = max_nuclid_value.Checked;

            mainForm.dataGridView1.Columns[Map.block_max_nuclid].Visible = isChecked;
            SettingsVariable.SetValue(name: Constants.GridVisibleSettingName.IsDeviceMaxReferenceValue,
                                    value: isChecked);
        }

        #endregion
    }
}
