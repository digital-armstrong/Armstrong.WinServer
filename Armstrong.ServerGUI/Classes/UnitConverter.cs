namespace Armstrong.WinServer.Classes
{
    /// <summary>
    /// Предоставляет методы для конвертации импульсов и других значений в требуемую величину.
    /// </summary>
    static class UnitConverter
    {
        /// <summary>
        /// Преобразует количество импульсов в требуемую величину, в зависимости от типа блока детектирования.
        /// </summary>
        /// <param name="type">Тип блока детектирования.</param>
        /// <param name="coefficient">Коэффициент преобразования.</param>
        /// <param name="n">Количество импульсов полученных с блока детектирования.</param>
        /// <returns>Пересчитанное значение из импульсов в величину в зависимости от тиба блока детектирования.</returns>
        static public double Convert(int type, double coefficient, double n)
        {
            //BDMG coefficient = 1, BDGB coefficient = 0.0000019f, BDAS coefficient = 2.0592f;

            switch (type)
            {
                case 1: return n * coefficient * 0.001f;                // type: 1  БДМГ    мкЗв/ч
                case 2: return n != 0 ? 1 / (n * coefficient) : 0;      // type: 2  БДГБ    Бк/м³
                case 3: return n != 0 ? n / coefficient : 0;            // type: 3  БДАС    Бк/м³
                case 4: return n != 0 ? n * coefficient : 0;            // type: 4  БДБ     имп/с
                default: return 1;
            }
        }

        /// <summary>
        /// Преобразует системные единицы, такие как Зиверты и Бикерели в внесистемные единицы, такие как Рентген и Кюри.
        /// </summary>
        /// <param name="type">Тип блока детектирования.</param>
        /// <param name="value">Значение МЭД или ОА аэрозолей или газов, поученное с блока детектирования.</param>
        /// <returns>Значение, пересчитанное из системных единиц в внесистемные единицы.</returns>
        static public double Convert(int type, double value)
        {
            // Пересчет из мкЗв/ч в мкР/с и Бк/м.куб в Ки/л
            // 1 мкЗв/ч     = 27.777        мкР/с
            // 1 Бк/м.куб   = 370000000000  Ки/л
            
            double curie = 37000000000000;
            double roentgen = 27.777f;

            switch (type)
            {
                case 1: return value * roentgen;                // type: 1  БДМГ    мкЗв/ч
                case 2: return value / curie;                   // type: 2  БДГБ    Бк/м³
                case 3: return value / curie;                   // type: 3  БДАС    Бк/м³
                default: return value;
            }
        }
    }
}
