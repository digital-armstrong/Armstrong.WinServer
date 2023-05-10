namespace Armstrong.WinServer.Classes
{
    public static class Constants
    {
        public static class SqlColumnName
        {
            public static string Id => "channel_id";
            public static string IdServer => "server_id";
            public static string ChannelImageState => "state";              // желательно переименовать в базе столбец
            public static string ChannelState => "state_for_threeview";      // желательно переименовать в базе столбец
            public static string ChannelOnOff => "on_off";
            public static string ChannelCoefficient => "coefficient";
            public static string ChannelPreAccident => "pre_accident";
            public static string ChannelAccident => "accident";
            public static string ChannelValueUnicCount => "count";
            public static string ChannelValueErrorCount => "error_count";
            public static string ChannelSpecialControl => "special_control";
            public static string ControlPoint => "name_ControlPoint";
            public static string BlockType => "type";                        // желательно переименовать в базе столбец
            public static string BlockName => "name_db";
            public static string BlockLocation => "name_location";
            public static string BlockMinNuclid => "min_nuclid_value";
            public static string BlockMaxNuclid => "max_nuclid_value";
            public static string EventDate => "date";                        // желательно переименовать в базе столбец
            public static string ValueSystem => "value";                     // желательно переименовать в базе столбец
            public static string ValueNotSystem => "value_cu";
            public static string ValueImpulses => "value_impulses";
            public static string Unit => "dim";
        }
        public static class EnvirovmentVariableName
        {
            public static string DatabaseHost => "ASRC_SQL_HOST";
            public static string DataBaseName => "ASRC_SQL_DATABASE";
            public static string DatabaseUserID => "ASRC_SQL_USER_ID";
            public static string DatabaseUserPSWD => "ASRC_SQL_USER_PSWD";
            public static string ConnectionString => "ARMS_PG_CONNECTION_STRING";
            public static string MonitorTable => "ASRC_MONITOR_TABLE";
            public static string HistoryTable => "ASRC_HISTORY_TABLE";
        }

        public static class SettingName
        {
            public static string MainFormTitle => "mainFormTitle";
            public static string ComPortName => "comPort";
            public static string ComPortBaudRate => "baudRate";
            public static string TimeToAsk => "timeAsk";
            public static string TimeNewShift => "newShift";
            public static string ServerId => "serverId";
            public static string HostName => "hostName";
        }

        public static class GridVisibleSettingName
        {
            public static string IsIdVisible => "visibleId";
            public static string IsIdServerVisible => "visibleIdServer";
            public static string IsChannelStateVisible => "visibleState";
            public static string IsControlPointVusuble => "visibleControlPoint";
            public static string IsDeviceVisible => "visibleDb";
            public static string IsLocationVisible => "visibleLocation";
            public static string IsEventValueVisible => "visibleValue";
            public static string IsUnitVisible => "visibleDim";
            public static string IsEventDateVisible => "visibleDate";
            public static string IsChannelActiveVisible => "visibleOnOff";
            public static string IsChannelCoefficientVisible => "visibleCoefficient";
            public static string IsChannelPreEmergencyVisible => "visiblePreAccident";
            public static string IsChannelEmergencyVisible => "visibleAccident";
            public static string IsDeviceTypeVisible => "visibleType";
            public static string IsEventCountVisible => "visibleCount";
            public static string IsEventImpulseValueVisible => "visibleValueImpulses";
            public static string IsEventErrorCountVisible => "visibleErrorCount";
            public static string IsStateForTreeVisible => "visibleStateForTreeView";
            public static string IsDeviceMinReferenceValue => "visibleMinNuclidValue";
            public static string IsDeviceMaxReferenceValue => "visibleMaxNuclidValue";
        }
    }
}
