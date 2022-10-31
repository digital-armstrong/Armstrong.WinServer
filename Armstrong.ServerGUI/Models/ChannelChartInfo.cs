using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Armstrong.WinServer.Classes;
using OxyPlot;
using OxyPlot.Wpf;

namespace Armstrong.WinServer.Models
{
    public class ChannelChartInfo
    {
        public double AverageValueSystem { get; set; }
        public double AverageValueNotSystem { get; set; }
        public double BlowoutSystem { get; set; }
        public double BlowoutNotSystem { get; set; }
        public int ChannelId { get; set; }
        public int ChannelType { get; set; }
        public string ChannelName { get; set; }
        public double Consumption { get; set; }
        public DateTime EndDateTime { get; set; }
        private EnumerableRowCollection<DataRow> PointsCollection { get; }
        public Series Series { get; set; }
        public int ServerId { get; set; }
        public DateTime StartDateTime { get; set; }

        SQL sql = new SQL();

        public ChannelChartInfo(int channelId,
                                string startDateTime,
                                string endDateTime)
        {
            EnumerableRowCollection<DataRow> channelInfo = this.GetChannelInfo(channelId);

            this.ChannelId = channelId;
            this.ChannelName = channelInfo.Select(x => x.Field<string>(Map.control_point)).FirstOrDefault();
            this.ChannelType = channelInfo.Select(x => x.Field<int>(Map.block_type)).FirstOrDefault();
            this.Consumption = channelInfo.Select(x => x.Field<double>(Map.consumption)).FirstOrDefault();

            this.PointsCollection = this.GetPoints(channelId: channelId,
                                                   startDateTime: startDateTime,
                                                   endDateTime: endDateTime);
            this.StartDateTime = this.GetStartDateTime();
            this.EndDateTime = this.GetEndDateTime();

            this.AverageValueSystem = this.GetAverageSystemValue();
            this.AverageValueNotSystem = this.GetAverageNotSystemValue();

            this.BlowoutSystem = this.GetBlowoutSystemValue();
            this.BlowoutNotSystem = this.GetBlowoutNotSystemValue();

            this.Series = this.GetSeries();
        }

        private EnumerableRowCollection<DataRow> GetChannelInfo(int channelId)
        {
            string monitorTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.MonitorTable);
            string query = $"SELECT {Map.control_point}, {Map.block_type}, {Map.consumption} FROM {monitorTable} WHERE {Map.channel_global_id}={channelId}";
            EnumerableRowCollection <DataRow> channelInfo = this.sql.SelectWithQuery(query)
                                                                    .Tables[0]
                                                                    .AsEnumerable();
            return channelInfo;
        }

        public EnumerableRowCollection<DataRow> GetPoints(int channelId,
                                                          string startDateTime,
                                                          string endDateTime)
        {
            string historyTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.HistoryTable);
            string historyID = $"{historyTable}.{Map.history_channel_id}";
            string historyValue = $"{historyTable}.{Map.value_system}";
            string historyDate = $"{historyTable}.{Map.event_date}";

            string query = $"SELECT {historyValue}, " +
                    $"{historyDate} " +
                    $"FROM {historyTable} " +
                    $"WHERE {historyID}={channelId} AND {historyDate} BETWEEN '{startDateTime}' AND '{endDateTime}' " +
                    $"ORDER BY {historyDate}";

            EnumerableRowCollection<DataRow> points = this.sql.SelectWithQuery(query).Tables[0].AsEnumerable();

            return points;
        }

        private double GetAverageSystemValue() =>
            this.PointsCollection.Any() ? this.PointsCollection.Average(r => r.Field<double>($"{Map.value_system}")) : 0;

        private double GetAverageNotSystemValue() => UnitConverter.Convert(type: this.ChannelType,
                                                                           value: this.AverageValueSystem);

        private DateTime GetStartDateTime() =>
            this.PointsCollection.Any() ? this.PointsCollection.Select(x => x.Field<DateTime>($"{Map.event_date}")).Min() : DateTime.Now;

        private DateTime GetEndDateTime() =>
            this.PointsCollection.Any() ? this.PointsCollection.Select(x => x.Field<DateTime>($"{Map.event_date}")).Max() : DateTime.Now;

        private double GetBlowoutSystemValue()
        {
            if (this.ChannelType == DetectorsInfo.TypeOG)
            {
                double secInHour = 3600;

                double blowoutTimeRange = this.EndDateTime.Subtract(this.StartDateTime).TotalSeconds;
                double blowoutSystemValue = this.AverageValueSystem * blowoutTimeRange * this.Consumption / secInHour;

                return blowoutSystemValue;
            }
            else
                return 0;
        }

        private double GetBlowoutNotSystemValue()
        {
            if (this.ChannelType == DetectorsInfo.TypeOG)
            {
                double secInHour = 3600;
                double convertCoefficient = 37000000000;

                double blowoutTimeRange = this.EndDateTime.Subtract(this.StartDateTime).TotalSeconds;
                double blowoutNotSystemValue = (this.AverageValueSystem * blowoutTimeRange * this.Consumption / secInHour) / convertCoefficient;

                return blowoutNotSystemValue;
            }
            else
                return 0;
        }

        private Series GetSeries()
        {
            LineSeries series = new LineSeries
            {
                Title = ChannelName,
            };

            List<DataPoint> dataPoints = new List<DataPoint>();

            foreach (DataRow dataPoint in this.PointsCollection)
            {
                dataPoints.Add(new DataPoint(x: OxyPlot.Axes.Axis.ToDouble(dataPoint[$"{Map.event_date}"]), y: (double)dataPoint[$"{Map.value_system}"]));
            }

            series.ItemsSource = dataPoints;

            return series;
        }
    }
}
