using System;
using Armstrong.WinServer.Classes;

namespace Armstrong.WinServer.Models
{
    public class ChannelMonitorUpdater
    {
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public double SystemEventValue { get; set; }
        public double NotSystemEventValue { get; set; }
        public double ImpulsesEventValue { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int EventCount { get; set; }
        public int ErrorEventCount { get; set; }
        public int ChannelState { get; set; }
        public string AssignedDataTable { get; set; } = "channels";
        public string UpdateQuery { get; private set; } = string.Empty;

        public void SetQueryString()
        {
            this.UpdateQuery = $"UPDATE {this.AssignedDataTable} SET " +
                $"{Map.value_system} = @system_value, " +
                $"{Map.value_not_system} = @not_system_value, " +
                $"{Map.value_impulses} = @impulse_value, " +
                $"{Map.event_date} = @date, " +
                $"{Map.channel_value_unic_count} = '{this.EventCount}', " +
                $"{Map.channel_value_error_count} = '{this.ErrorEventCount}', " +
                $"{Map.channel_state} = '{this.ChannelState}', " +
                $"{Map.unit} = '{this.Unit}' " +
                $"WHERE {Map.channel_global_id} = {this.Id}";
        }
    }
}
