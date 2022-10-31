namespace Armstrong.WinServer.Classes
{
    static class PackageControlSum
    {
        // -----------------------------------------------------------------------------
        //Возвращает двухбайтовую контрольную сумму. + Алгоритм расчета CRC
        // -----------------------------------------------------------------------------
        public static void CalculationCRC(byte[] message, ref byte[] CRC)              // входные данные функции : byte[] message(см. строчку где message.Length)- это данные которые пришли в функцию,
                                                                         // входные данные функции: ref byte[] CRC - эти данные мы получаем внутри этой функции и потом выводим в тело
                                                                         // программы откуда мы вызвали эту ффункцию
        {
            ushort CRCFull = 0xFFFF;                                     // 16-ти битовый регистр загружается числом FF hex (все 1), и используется далее как регистр CRC
            char CRCLSB;                                                 // переменная определения значения младшего бита в цикле
            for (int i = 0; i < (message.Length) - 2; i++)               //Повторяются шаги для следующего сообщения(1). Это повторяется до тех пор пока все байты сообщения не будут обработаны.  
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);                // Первый байт сообщения (- 2 это отсекаем место под CRC) складывается по ИСКЛЮЧАЮЩЕМУ ИЛИ
                                                                         // с содержимым регистра CRC. Результат помещается в регистр CRC
                for (int j = 0; j < 8; j++)                              // цикл повторяется 8 раз
                {
                    CRCLSB = (char)(CRCFull & 0x0001);                   // Если младший бит 0. Повторяется сдвиг (следующая строка).
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);         // Регистр CRC сдвигается вправо(в направлении младшего бита) на 1 бит, старший бит заполняется 0
                    if (CRCLSB == 1)                                     // Если младший бит 1
                        CRCFull = (ushort)(CRCFull ^ 0xA001);            // Делается операция ИСКЛЮЧАЮЩЕЕ ИЛИ регистра CRC и полиномиального числа A001 hex
                }
            }
            CRC[1] = (byte)((CRCFull >> 8) & 0xFF);                      // определяем получившийся старший байт 
            CRC[0] = (byte)(CRCFull & 0xFF);                             // определяем получившийся младший байт 
        }

    }
}