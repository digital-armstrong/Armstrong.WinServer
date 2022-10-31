using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Armstrong.WinServer.Classes;
using Armstrong.WinServer.Views;
using Armstrong.WinServer.Models;
using System.Runtime.CompilerServices;

namespace Armstrong.WinServer
{
    public partial class DatePicker : Form
    {
        private string CallerMethodName { get; set; } = null;

        readonly List<int> selectedId = new List<int>();
        readonly SQL sql = new SQL();

        public DatePicker(List<int> selectedId, [CallerMemberName] string property = null)
        {
            CallerMethodName = property;

            InitializeComponent();
            this.selectedId = selectedId;
            dataShift_radioButton.Checked = true;

            switch (CallerMethodName)
            {
                case null:
                    break;
                case "blowoutToolStripMenuItem_Click":
                    ok_button.Text = "Рассчитать выброс";
                    break;
                case "ShowChart_Event":
                    ok_button.Text = "Построить график";
                    break;
            }
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            switch (CallerMethodName)
            {
                case null:
                    break;
                case "blowoutToolStripMenuItem_Click":
                    DataSet blowoutData = sql.GetBlowoutReport(startDateTime: GetStartDateTime(), endDateTime: GetEndDateTime());
                    ChannelBlowoutReport blowoutReportTable = new ChannelBlowoutReport(blowoutData);
                    blowoutReportTable.Show();
                    break;
                case "ShowChart_Event":
                    List<ChannelChartInfo> channelsList = GetChannels();
                    Graphic chart = new Graphic(channelsList);
                    chart.Show();
                    break;
            }

            Close();
        }

        /// <summary>
        /// Return search parameter when follow before WHERE keyword
        /// </summary>
        /// <param name="id">Id's column name in database</param>
        /// <param name="date">Date column name in database</param>
        /// <returns></returns>
        private string GetSearchParameter(string id, string date)
        {
            var parameter = string.Empty;
            string startDateTime = GetStartDateTime();
            string endDateTime = GetEndDateTime();

            for (int i = 0; i < selectedId.Count; i++)
            {
                switch (i != (selectedId.Count - 1))
                {
                    case true:
                        parameter = parameter + $"{id}='{selectedId[i]}' " +
                            $"AND {date} BETWEEN '{startDateTime}' " +
                            $"AND '{endDateTime}' OR ";
                        break;
                    case false:
                        parameter = parameter + $"{id}='{selectedId[i]}' " +
                            $"AND {date} BETWEEN '{startDateTime}' " +
                            $"AND '{endDateTime}'";
                        break;
                }
            }

            return parameter;
        }

        private string GetStartDateTime()
        {
            string startDateTime = string.Empty;
            if (dataShift_radioButton.Checked)
            {
                startDateTime = string.Concat(str0: DateTime.Today.ToString("yyyy-MM-dd"),
                                              str1: "T00:00:00");
            }
            if (dataRange_radioButton.Checked)
            {
                var startDate = minDate_dateTimePicker.Value.ToString("yyyy-MM-dd");
                var startTime = minTime_dateTimePicker.Value.ToString("HH:mm:ss");

                startDateTime = string.Concat(str0: startDate,
                                              str1: "T",
                                              str2: startTime);
            }

            return startDateTime;
        }
        private string GetEndDateTime()
        {
            string endDateTime = string.Empty;

            if (dataShift_radioButton.Checked)
            {
                endDateTime = string.Concat(str0: DateTime.Today.ToString("yyyy-MM-dd"),
                                            str1: "T23:59:00");
            }
            if (dataRange_radioButton.Checked)
            {
                string endDate = maxDate_dateTimePicker.Value.ToString("yyyy-MM-dd");
                string endTime = maxTime_dateTimePicker.Value.ToString("HH:mm:ss");

                endDateTime = string.Concat(str0: endDate,
                                            str1: "T",
                                            str2: endTime);
            }

            return endDateTime;
        }

        public List<ChannelChartInfo> GetChannels()
        {;
            string startDateTime = GetStartDateTime();
            string endDateTime = GetEndDateTime();

            List<ChannelChartInfo> channelList = new List<ChannelChartInfo>();
            
            selectedId.Reverse();

            foreach (var id in selectedId)
            {
                ChannelChartInfo channel = new ChannelChartInfo(id, startDateTime, endDateTime);
                channelList.Add(channel);
            }

            selectedId.Reverse();

            return channelList;
        }

        public DataSet GetBlowoutReport()
        {
            string monitor = "monitor";
            string history = "history";
            string historyID = $"history.{Map.history_channel_id}";
            string monitorID = $"monitor.{Map.channel_global_id}";
            string historyValue = $"history.{Map.value_system}";
            string historyDate = $"history.{Map.event_date}";
            string monitorConsumption = $"monitor.{Map.consumption}";
            string monitorControlPoint = $"monitor.{Map.control_point}";
            string cuInBq = "37000000000";
            string secInMin = "3600";
            string dateFormat = "dd.MM.yyyy HH:mm:ss";
            string monitorTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.MonitorTable);
            string historyTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.HistoryTable);

            string parameter = GetSearchParameter(historyID, historyDate);

            string query = $"IF OBJECT_ID(N'[tempdb].[dbo].[#Blowout]', N'U') IS NOT NULL "
                           + $"DROP TABLE [tempdb].[dbo].[#Blowout]; "
                           + $"SELECT {monitorControlPoint} as 'Точка контроля', "
                           + $"(AVG({historyValue}) * (DATEDIFF(SECOND, MIN({historyDate}), MAX({historyDate}))) * ({monitorConsumption} / {secInMin}))"
                           + $" as 'Выброс, Бк', "
                           + $"(AVG({historyValue}) * (DATEDIFF(SECOND, MIN({historyDate}), MAX({historyDate}))) * ({monitorConsumption} / {secInMin})) / {cuInBq}"
                           + $" as 'Выброс, Ки',"
                           + $"{monitorConsumption} as 'Расход, час.', "
                           + $"('с: ' + FORMAT(MIN({historyDate}), '{dateFormat}') + ', ' + ' до: ' + FORMAT(MAX({historyDate}), '{dateFormat}')) as 'Период' "
                           + $"INTO [tempdb].[dbo].[#Blowout] "
                           + $"FROM {historyTable} AS {history} "
                           + $"INNER JOIN {monitorTable} AS {monitor} "
                           + $"ON {monitorID} = {historyID} "
                           + $"WHERE {parameter} "
                           + $"GROUP BY {monitorConsumption}, {monitorControlPoint} "
                           + $"SELECT [Точка контроля] as 'Точка контроля', "
                           + $"FORMAT([Выброс, Бк], 'E3') as 'Выброс, Бк', "
                           + $"FORMAT([Выброс, Ки], 'E3') as 'Выброс, Ки', "
                           + $"[Расход, час.] as 'Расход, час.', "
                           + $"[Период] as 'Период' "
                           + $"FROM [tempdb].[dbo].[#Blowout] "
                           + $"SELECT 'I' as 'Категория', FORMAT(SUM([Выброс, Бк]), 'E3') as 'Выброс, Бк', "
                           + $"FORMAT(SUM([Выброс, Ки]), 'E3') as 'Выброс, Ки', "
                           + $"SUM([Расход, час.]) as 'Расход, час.' "
                           + $"FROM [tempdb].[dbo].[#Blowout] WHERE [Точка контроля] = 'В-1 Г' OR [Точка контроля] = 'В-7 Г' UNION "
                           + $"SELECT 'II' as 'Категория',FORMAT(SUM([Выброс, Бк]), 'E3') as 'Выброс, Бк', "
                           + $"FORMAT(SUM([Выброс, Ки]), 'E3') as 'Выброс, Ки', "
                           + $"SUM([Расход, час.]) as 'Расход, час.' "
                           + $"FROM [tempdb].[dbo].[#Blowout] WHERE [Точка контроля] = 'В-2 Г' OR [Точка контроля] = 'В-3 Г' OR [Точка контроля] = 'В-4` Г' OR [Точка контроля] = 'В-5 Г' UNION "
                           + $"SELECT 'III' as 'Категория', FORMAT([Выброс, Бк], 'E3') as 'Выброс, Бк', "
                           + $"FORMAT([Выброс, Ки], 'E3') as 'Выброс, Ки', "
                           + $"[Расход, час.] as 'Расход, час.' "
                           + $"FROM [tempdb].[dbo].[#Blowout] WHERE [Точка контроля] = 'В-6 Г' UNION "
                           + $"SELECT 'Суммарный' as 'Категория',FORMAT(SUM([Выброс, Бк]), 'E3') as 'Выброс, Бк', "
                           + $"FORMAT(SUM([Выброс, Ки]), 'E3') as 'Выброс, Ки', "
                           + $"SUM([Расход, час.]) as 'Расход, час.' "
                           + $"FROM [tempdb].[dbo].[#Blowout] WHERE [Точка контроля] = 'В-1 Г' OR "
                                                                + $"[Точка контроля] = 'В-2 Г' OR "
                                                                + $"[Точка контроля] = 'В-3 Г' OR "
                                                                + $"[Точка контроля] = 'В-4` Г' OR "
                                                                + $"[Точка контроля] = 'В-5 Г' OR "
                                                                + $"[Точка контроля] = 'В-6 Г' OR "
                                                                + $"[Точка контроля] = 'В-7 Г'";

            DataSet dataSet = sql.SelectWithQuery(query);
            return dataSet;
        }

        private void DataShift_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dataShift_radioButton.Checked)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }

        private void DataRange_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dataShift_radioButton.Checked)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
            }
            minDate_dateTimePicker.Value = DateTime.Now.AddDays(-1);
        }
    }
}
