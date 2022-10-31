namespace Armstrong.WinServer.Classes
{
    /// <summary>
    /// Класс, содержащий пары "переменная" - "имя колонки" в базе данных.
    /// </summary>
    public class Map
    {
        public const string history_channel_id = "channel_id";
        public const string channel_global_id = "id";
        public const string channel_id = "channel_id";
        public const string id_server = "server_id";

        public const string channel_image_state = "state";              // желательно переименовать в базе столбец
        public const string channel_state = "state_for_threeview";      // желательно переименовать в базе столбец
        public const string channel_power_state = "on_off";
        public const string channel_coefficient = "coefficient";
        public const string channel_pre_accident = "pre_accident";
        public const string channel_accident = "accident";
        public const string channel_value_unic_count = "count";
        public const string channel_value_error_count = "error_count";
        public const string channel_special_control = "special_control";

        public const string channel_background = "background";

        public const string control_point = "name_ControlPoint";
        public const string block_type = "type";                        // желательно переименовать в базе столбец
        public const string block_name = "name_db";
        public const string block_location = "name_location";
        public const string block_min_nuclid = "min_nuclid_value";
        public const string block_max_nuclid = "max_nuclid_value";

        public const string event_date = "event_date";                        // желательно переименовать в базе столбец

        public const string value_system = "event_value";                     // желательно переименовать в базе столбец
        public const string value_not_system = "value_cu";
        public const string value_impulses = "value_impulses";

        public const string unit = "unit";
        public const string consumption = "consumption";
    }
}
