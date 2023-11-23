using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Armstrong.WinServer.Classes
{
    /// <summary>
    /// Байт типа функции: 
    ///                     установка рабочего режима, 
    ///                     сервисные пакеты, 
    ///                     запрос значения, 
    ///                     световая сигнализация, 
    ///                     установка адреса.
    /// </summary>
    enum Function : byte
    {
        SetWorkMode = 0x01,
        StartService = 0x02,
        GetValue = 0x03,
        SetLed = 0x04,
        SetAddress = 0x09
    }
    /// <summary>
    /// Байт типа операции: 
    ///                     запись, 
    ///                     чтение.
    /// </summary>
    enum Operation : byte
    {
        Write = 0x01,
        Read = 0x02
    }
    /// <summary>
    /// Байт цвета: 
    ///             красный, 
    ///             желтый, 
    ///             зеленый, 
    ///             отключено.
    /// </summary>
    enum LedColor : byte
    {
        RED = 0x01,
        YEL = 0x02,
        GRN = 0x03,
        OFF = 0x00
    }
    /// <summary>
    /// Байт типа действия: 
    ///                     открыть бленкер, 
    ///                     закрыть бленкер, 
    ///                     перемотать ленту, 
    ///                     перемотать ленту и включить генератор, 
    ///                     отправить сигнал спец. контроля.
    /// </summary>
    enum ActionType : byte
    {
        CloseBlenker = 0x00,
        OpenBlenker = 0x01,
        Rewind = 0x02,
        RewindAndTurnOnGenerator = 0x03,
        SendSpeсialSignal = 0x01
    }

    class PackagesInitialization
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Генерирует 8-ми байтовые пакеты для запроса значения измерений.
        /// </summary>
        /// <param name="count">Количество каналов</param>
        /// <param name="function">Байт типа выполняемой функции</param>
        /// <returns>Возвращает список 8-ми байтовых пакетов.</returns>
        public List<byte[]> GeneratePackages(int count, Function function)
        {
            logger.Debug($"Сборка \"{function}\" пакетов для запроса значения с блока детектирования...");

            byte[] CRC = new byte[2];
            byte[] message = new byte[] { 0x00, (byte)function, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            List<byte[]> packages = new List<byte[]>();

            for (byte i = 1; i <= count; i++)
            {
                message[0] = i;
                PackageControlSum.CalculationCRC(message, ref CRC);
                byte[] package = new byte[] { i, (byte)function, 0x00, 0x00, 0x00, 0x00, CRC[0], CRC[1] };
                packages.Add(package);
            }

            logger.Debug($"--- Пример \"{function}\" пакета: [{BitConverter.ToString(packages[0])}]");
            logger.Debug($"--- Собрано {packages.Count} \"{function}\" пакетов.");

            return packages;
        }
        /// <summary>
        /// Генерирует 8-ми байтовые пакеты для управления световой сигнализацией
        /// </summary>
        /// <param name="count">Количество каналов</param>
        /// <param name="function">Байт типа выполняемой функции</param>
        /// <param name="color">Байт цвета</param>
        /// <returns>Возвращает список 8-ми байтовых пакетов.</returns>
        public List<byte[]> GeneratePackages(int count, Function function, LedColor color, ActionType sendSpecialSignal = 0x00)
        {
            if (sendSpecialSignal == 0x00)
            {
                logger.Debug($"Сборка пакетов \"{function}\" для управления световой сигнализацией с сигналом \"{color}\"...");
            }
            else
            {
                logger.Debug($"Сборка пакетов \"{function}\" для управления световой сигнализацией с сигналом \"{color}\" и сигналом спец. контроля...");
            }

            byte[] CRC = new byte[2];
            byte[] message = new byte[] { 0x00, (byte)function, (byte)color, (byte)sendSpecialSignal, 0x00, 0x00, 0x00, 0x00 };

            List<byte[]> packages = new List<byte[]>();

            for (byte i = 1; i <= count; i++)
            {
                message[0] = i;
                PackageControlSum.CalculationCRC(message, ref CRC);
                byte[] package = new byte[] { i, (byte)function, (byte)color, (byte)sendSpecialSignal, 0x00, 0x00, CRC[0], CRC[1] };
                packages.Add(package);
            }

            logger.Debug($"--- Пример \"{function}\" пакета: [{BitConverter.ToString(packages[0])}]");
            logger.Debug($"--- Собрано {packages.Count} \"{function}\" пакетов с сигналом \"{color}\".");

            return packages;
        }
        /// <summary>
        /// Генерирует 8-ми байтовые пакеты для запроса результата перемотки ленты БДАС-02П.
        /// </summary>
        /// <param name="count">Количество каналов.</param>
        /// <param name="function">Байт типа выполняемой функции.</param>
        /// <param name="operation">Байт типа выполняемой операции.</param>
        /// <returns>Возвращает список 8-ми байтовых пакетов.</returns>
        public List<byte[]> GeneratePackages(int count, Function function, Operation operation)
        {
            logger.Debug($"Сборка \"{function}\" пакетов для операции \"{operation}\"...");

            byte[] CRC = new byte[2];
            byte[] message = new byte[] { 0x00, (byte)function, (byte)operation, 0x00, 0x00, 0x00, 0x00, 0x00 };

            List<byte[]> packages = new List<byte[]>();

            for (byte i = 1; i <= count; i++)
            {
                message[0] = i;
                PackageControlSum.CalculationCRC(message, ref CRC);
                byte[] package = new byte[] { i, (byte)function, (byte)operation, 0x00, 0x00, 0x00, CRC[0], CRC[1] };
                packages.Add(package);
            }

            logger.Debug($"--- Пример \"{function}\" пакета: [{BitConverter.ToString(packages[0])}]");
            logger.Debug($"--- Собрано {packages.Count} \"{function}\" пакетов для операции \"{operation}\".");

            return packages;
        }

        /// <summary>
        /// Генерирует 8-ми байтовые пакеты для запроса результата перемотки ленты БДАС-02П.
        /// </summary>
        /// <param name="count">Количество каналов.</param>
        /// <param name="function">Байт типа выполняемой функции.</param>
        /// <param name="operation">Байт типа выполняемой операции.</param>
        /// <returns>Возвращает список 8-ми байтовых пакетов.</returns>
        public List<byte[]> GenerateSinglePackage(int address, Function function, Operation operation)
        {
            byte[] CRC = new byte[2];
            byte[] message = new byte[] { (byte)address, (byte)function, (byte)operation, 0x00, 0x00, 0x00, 0x00, 0x00 };

            PackageControlSum.CalculationCRC(message, ref CRC);

            List<byte[]> package = new List<byte[]>
            {
                new byte[] { (byte)address, (byte)function, (byte)operation, 0x00, 0x00, 0x00, CRC[0], CRC[1] }
            };

            return package;
        }

        public List<byte[]> GenerateSinglePackage(int address, Function function, Operation operation, ActionType actionType)
        {
            byte[] CRC = new byte[2];
            byte[] message = new byte[] { (byte)address, (byte)function, (byte)operation, (byte)actionType, 0x00, 0x00, 0x00, 0x00 };

            PackageControlSum.CalculationCRC(message, ref CRC);

            List<byte[]> package = new List<byte[]>
            {
                new byte[] { (byte)address, (byte)function, (byte)operation, (byte)actionType, 0x00, 0x00, CRC[0], CRC[1] }
            };

            return package;
        }

        public List<byte[]> GenerateSinglePackage(int address, Function function)
        {

            byte[] CRC = new byte[2];
            byte[] message = new byte[] { (byte)address, (byte)function, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            PackageControlSum.CalculationCRC(message, ref CRC);

            List<byte[]> package = new List<byte[]>
            {
                new byte[] { (byte)address, (byte)function, 0x00, 0x00, 0x00, 0x00, CRC[0], CRC[1] }
            };

            return package;
        }

        /// <summary>
        /// Генерирует 8-ми байтовые сервисные пакеты.
        /// </summary>
        /// <param name="count">Количество каналов.</param>
        /// <param name="function">Байт типа выполняемой функции.</param>
        /// <param name="operation">Байт типа выполняемой операции.</param>
        /// <param name="actionType">Байт типа выполняемого действия.</param>
        /// <returns>Возвращает список 8-ми байтовых пакетов.</returns>
        public List<byte[]> GeneratePackages(int count, Function function, Operation operation, ActionType actionType)
        {
            logger.Debug($"Сборка \"{function}\" пакетов для операции \"{operation}\" и типа выполняемой задачи \"{actionType}\"...");

            byte[] CRC = new byte[2];
            byte[] message = new byte[] { 0x00, (byte)function, (byte)operation, (byte)actionType, 0x00, 0x00, 0x00, 0x00 };

            List<byte[]> packages = new List<byte[]>();

            for (byte i = 1; i <= count; i++)
            {
                message[0] = i;
                PackageControlSum.CalculationCRC(message, ref CRC);
                byte[] package = new byte[] { i, (byte)function, (byte)operation, (byte)actionType, 0x00, 0x00, CRC[0], CRC[1] };
                packages.Add(package);
            }

            logger.Debug($"--- Пример \"{function}\" пакета: [{BitConverter.ToString(packages[0])}]");
            logger.Debug($"--- Собрано {packages.Count} \"{function}\" пакетов для операции \"{operation}\" и типа выполняемой задачи \"{actionType}\".");

            return packages;
        }

        /// <summary>
        /// Генерирует 8-ми байтовые пакеты для проведения новой смены.
        /// </summary>
        /// <param name="address">Байт адреса канала.</param>
        /// <param name="function">Байт типа выполняемой функции.</param>
        /// <param name="operation">Байт типа выполняемой операции.</param>
        /// <param name="actionType">Байт типа выполняемого действия.</param>
        /// <returns></returns>
        public List<byte[]> GeneratePackages(List<int> address, Function function, Operation operation, ActionType actionType)
        {
            logger.Debug($"Сборка \"{function}\" пакетов для операции \"{operation}\" и типа выполняемой задачи \"{actionType}\"...");

            byte[] CRC = new byte[2];
            byte[] message = new byte[] { 0x00, (byte)function, (byte)operation, (byte)actionType, 0x00, 0x00, 0x00, 0x00 };

            List<byte[]> packages = new List<byte[]>();

            for (byte i = 0; i < address.Count(); i++)
            {
                message[0] = (byte)address[i];
                PackageControlSum.CalculationCRC(message, ref CRC);
                byte[] package = new byte[] { (byte)address[i], (byte)function, (byte)operation, (byte)actionType, 0x00, 0x00, CRC[0], CRC[1] };
                packages.Add(package);
            }

            logger.Debug($"--- Пример \"{function}\" пакета: [{BitConverter.ToString(packages[0])}]");
            logger.Debug($"--- Собрано {packages.Count} \"{function}\" пакетов для операции \"{operation}\" и типа выполняемой задачи \"{actionType}\".");

            return packages;
        }
    }
}
