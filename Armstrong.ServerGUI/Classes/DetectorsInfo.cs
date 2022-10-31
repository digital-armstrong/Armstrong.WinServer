namespace Armstrong.WinServer.Classes
{
    /// <summary>
    /// Класс, предоставляющий константы для работы с блоками детектирования и каналами, к которым они подключены. 
    /// Содержит в себе такие константы, как: состояние питания, состояние уровней, тип блока детектирования.
    /// </summary>
    class DetectorsInfo
    {
        /// <summary>
        /// Состояния питания ВКЛ.
        /// </summary>
        public const int Power_ON = 1;

        /// <summary>
        /// Состояния питания ВЫКЛ.
        /// </summary>
        public const int Power_OFF = 0;

        /// <summary>
        /// Состояние блока/канала Accident - превышение аварийной уставки.
        /// </summary>
        public const int StateAccident = 1;

        /// <summary>
        /// Состояние блока/канала PreAccident - превышение предаварийной уставки.
        /// </summary>
        public const int StatePreAccident = 2;

        /// <summary>
        /// Состояние блока/канала Normal - уровни не прервышены.
        /// </summary>
        public const int StateNormal = 3;

        /// <summary>
        /// Состояние канала Offline - обрыв кабеля/связи и/или выход блока из строя.
        /// </summary>
        public const int StateOffline = 8;

        /// <summary>
        /// Состояние канала PowerOff - отключен опрос канала и/или физически отключен канал.
        /// </summary>
        public const int StatePowerOff = 9;

        /// <summary>
        /// Тип детектора ED - Equivalent dose (мощность эквивалентной дозы гамма).
        /// </summary>
        public const int TypeED = 1;

        /// <summary>
        /// Тип детектора OG - объемная активность газа.
        /// </summary>
        public const int TypeOG = 2;

        /// <summary>
        /// Тип детектора OA - объекмная активность аэрозолей (приборы с лентопротяжным механизмом).
        /// </summary>
        public const int TypeOA = 3;

        /// <summary>
        /// Тип детектора IC - Impulses count (генераторы / прямопоказывающие в имп/сек. и тд)
        /// </summary>
        public const int TypeIC = 4;
    }
}
