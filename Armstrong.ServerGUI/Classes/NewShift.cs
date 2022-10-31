using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using NLog;

namespace Armstrong.WinServer.Classes
{
    class NewShift
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly PackagesInitialization packInit = new PackagesInitialization();
        private readonly ComPort comPort = new ComPort();             

        /// <summary>
        /// Осуществляет перемотку ленты в группе блоков детектирования с лентопротяжным механизмом.
        /// </summary>
        /// <param name="serialPort">Объект COM-порта, через который осуществляется обмен пакетами.</param>
        /// <param name="address">Список адресов блоков детектирования.</param>
        public void Rewind(SerialPort serialPort, List<int> address)
        {
            logger.Debug("Осуществляется попытка отправки пакетов перемотки кадра каналов из списка.");

            var packages = packInit.GeneratePackages(address, Function.StartService, Operation.Write, ActionType.Rewind);
            if (serialPort.IsOpen)
            {
                logger.Debug($"--- {serialPort.PortName} уже был открыт.");

                for (int i = 0; i < packages.Count(); i++)
                {
                    logger.Debug($"------ Отправка команды перемотки [{BitConverter.ToString(packages[i])}] на канал {packages[i][0]}.");
                    comPort.Inquiry(serialPort, packages, i);
                    logger.Debug($"------ Канал {packages[i][0]} - успешно.");
                }
            }
            else
            {
                logger.Debug($"--- {serialPort.PortName} был закрыт.");
                logger.Debug($"--- Попытка открыть порт {serialPort.PortName}.");
                serialPort.Open();
                logger.Debug($"--- {serialPort.PortName} открыт.");
                for (int i = 0; i < packages.Count(); i++)
                {
                    logger.Debug($"------ Попытка отправки команды перемотки [{BitConverter.ToString(packages[i])}] на канал {packages[i][0]}.");
                    comPort.Inquiry(serialPort, packages, i);
                    logger.Debug($"------ Канал {packages[i][0]} - успешно.");
                }
                logger.Debug($"--- Попытка закрыть порт {serialPort.PortName}.");
                serialPort.Close();
                serialPort.Dispose();

                logger.Debug("Все пакеты перемотки кадра успешно отправлены.");
            }
        }
        /// <summary>
        /// Осуществляет перемотку ленты в отдельном блоке детектирования с лентопротяжным механизмом.
        /// </summary>
        /// <param name="serialPort">Объект COM-порта, через который осуществляется обмен пакетами.</param>
        /// <param name="address">Адрес блока детектирования.</param>
        public void Rewind(SerialPort serialPort, int address)
        {
            logger.Debug($"Осуществляется перемотка ленты канала: {address}.");

            var package = packInit.GeneratePackages(address, Function.StartService, Operation.Write, ActionType.Rewind);
            if (serialPort.IsOpen)
            {
                logger.Debug($"--- {serialPort.PortName} уже был открыт.");

                for (var i = 0; i < package.Count(); i++)
                {
                    logger.Debug($"------ Попытка отправки команды перемотки [{BitConverter.ToString(package[0])}] на канал {address}.");
                    comPort.Inquiry(serialPort, package, i);
                    logger.Debug($"------ Канал {address} - успешно.");
                }
            }
            else
            {
                logger.Debug($"--- {serialPort.PortName} был закрыт.");
                logger.Debug($"--- Попытка открыть порт {serialPort.PortName}.");
                serialPort.Open();
                logger.Debug($"--- {serialPort.PortName} открыт.");
                for (var i = 0; i < package.Count(); i++)
                {
                    logger.Debug($"------ Попытка отправки команды перемотки [{BitConverter.ToString(package[0])}] на канал {address}.");
                    comPort.Inquiry(serialPort, package, i);
                    logger.Debug($"------ Канал {address} - успешно.");
                }
                logger.Debug($"--- Попытка закрыть порт {serialPort.PortName}.");
                serialPort.Close();
                serialPort.Dispose();

                logger.Debug("Все пакеты перемотки кадра успешно отправлены.");
            }
        }
        /// <summary>
        /// Производит открытия шторки бленкера в блоках с гамма-источником.
        /// </summary>
        /// <param name="serialPort">Объект COM-порта, через который осуществляется обмен пакетами.</param>
        /// <param name="address">Список адресов блоков детектирования.</param>
        public void OpenBlenker(SerialPort serialPort, List<int> address)
        {
            logger.Debug($"Осуществляется открытие бленкера канала: {address}.");

            var packages = packInit.GeneratePackages(address, Function.StartService, Operation.Write, ActionType.OpenBlenker);
            for (int i = 0; i < packages.Count(); i++)
                comPort.Inquiry(serialPort, packages, i);
        }
    }
}
