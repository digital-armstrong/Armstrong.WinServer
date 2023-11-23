using Armstrong.WinServer.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Armstrong.WinServer.Classes
{
    class NewShift
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly PackagesInitialization packInit = new PackagesInitialization();
        private readonly ComPort comPort = new ComPort();
        private int TestRequestsCount { get; set; } = 50;

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
        public void Rewind(SerialPort serialPort, int address, DataRow channelInfo)
        {
            logger.Debug($"Осуществляется перемотка ленты канала: {address}.");

            var initRewindPkg = packInit.GenerateSinglePackage(address, Function.StartService, Operation.Write, ActionType.Rewind);
            var fetchFieldState = packInit.GenerateSinglePackage(address, Function.StartService, Operation.Read);
            var fetchValuePkg = packInit.GenerateSinglePackage(address, Function.GetValue);

            if (serialPort.IsOpen)
            {
                logger.Debug($"--- {serialPort.PortName} уже был открыт.");

                for (var i = 0; i < initRewindPkg.Count(); i++)
                {
                    logger.Debug($"------ Попытка отправки команды перемотки [{BitConverter.ToString(initRewindPkg[0])}] на канал {address}.");
                    comPort.Inquiry(serialPort, initRewindPkg, i);
                    logger.Debug($"------ Канал {address} - успешно.");
                }

                for (var i = 0; i < fetchValuePkg.Count(); i++)
                {
                    NewShiftReport report = new NewShiftReport(channelAddress: address,
                                                               minLimit: (double)channelInfo[Map.block_min_nuclid],
                                                               maxLimit: (double)channelInfo[Map.block_max_nuclid],
                                                               impulsesBufferSize: TestRequestsCount,
                                                               isDetectorHaveField: true);

                    for (var j = 0; j < TestRequestsCount; j++)
                    {
                        comPort.Inquiry(serialPort, fetchValuePkg[i]);
                        report.ImpulsesBuffer[j] = comPort.Answer(serialPort, address);

                        Thread.Sleep(900);
                    }

                    comPort.Inquiry(serialPort, fetchFieldState[i]);
                    var _fieldRiwindResult = comPort.AnswerRaw(serialPort, address);

                    if (_fieldRiwindResult == null)
                    {
                        report.IsLineDown = true;
                    }
                    else
                    {
                        report.IsFielRewind = _fieldRiwindResult[4] == 0x01;
                    }

                    var _avgImpulsesValue = report.GetAvgImpulsesValue();
                    var _isSignalValid = report.GetIsSignalValid();

                    logger.Info($"------------------------------------ ");
                    logger.Info($"------ Результаты проверки {address}");
                    logger.Info($"--------- Перемотка: {report.IsFielRewind}");
                    logger.Info($"--------- Сигнал: {report.IsSignallValid}");
                    logger.Info($"--------- Отказ линии: {report.IsLineDown}");
                    logger.Info($"--------- Импульсов: {report.AvgImpulsesValue} имп/с");
                    logger.Info($"------------------------------------ \n");

                    MessageBox.Show(messageBoxText: $"Перемотка:\t{report.IsFielRewind}\n"
                                                    + $"Сигнал:\t\t{report.IsSignallValid}\n"
                                                    + $"Отказ линии:\t{report.IsLineDown}\n"
                                                    + $"Кол. имп.:\t{report.AvgImpulsesValue} имп/с",
                                    caption: $"Результаты проверки {address}");
                }
            }
            else
            {
                {
                    logger.Debug($"--- {serialPort.PortName} был закрыт.");
                    logger.Debug($"--- Попытка открыть порт {serialPort.PortName}.");
                    serialPort.Open();
                    logger.Debug($"--- {serialPort.PortName} открыт.");

                    for (var i = 0; i < initRewindPkg.Count(); i++)
                    {
                        logger.Debug($"------ Попытка отправки команды перемотки [{BitConverter.ToString(initRewindPkg[0])}] на канал {address}.");
                        comPort.Inquiry(serialPort, initRewindPkg, i);
                        logger.Debug($"------ Канал {address} - успешно.");
                    }

                    for (var i = 0; i < fetchValuePkg.Count(); i++)
                    {
                        NewShiftReport report = new NewShiftReport(channelAddress: address,
                                                                   minLimit: (double)channelInfo[Map.block_min_nuclid],
                                                                   maxLimit: (double)channelInfo[Map.block_max_nuclid],
                                                                   impulsesBufferSize: TestRequestsCount,
                                                                   isDetectorHaveField: true);

                        for (var j = 0; j < TestRequestsCount; j++)
                        {
                            comPort.Inquiry(serialPort, fetchValuePkg[i]);
                            report.ImpulsesBuffer[j] = comPort.Answer(serialPort, address);

                            Thread.Sleep(900);
                        }

                        comPort.Inquiry(serialPort, fetchFieldState[i]);
                        var _fieldRiwindResult = comPort.AnswerRaw(serialPort, address);

                        if (_fieldRiwindResult == null)
                        {
                            report.IsLineDown = true;
                        }
                        else
                        {
                            report.IsFielRewind = _fieldRiwindResult[4] == 0x01;
                        }

                        var _avgImpulsesValue = report.GetAvgImpulsesValue();
                        var _isSignalValid = report.GetIsSignalValid();

                        logger.Info($"------------------------------------ ");
                        logger.Info($"------ Результаты проверки {address}");
                        logger.Info($"--------- Перемотка: {report.IsFielRewind}");
                        logger.Info($"--------- Сигнал: {report.IsSignallValid}");
                        logger.Info($"--------- Отказ линии: {report.IsLineDown}");
                        logger.Info($"--------- Импульсов: {report.AvgImpulsesValue} имп/с");
                        logger.Info($"------------------------------------ \n");

                        MessageBox.Show(messageBoxText: $"Перемотка:\t{report.IsFielRewind}\n"
                                                        + $"Сигнал:\t\t{report.IsSignallValid}\n"
                                                        + $"Отказ линии:\t{report.IsLineDown}\n"
                                                        + $"Кол. имп.:\t{report.AvgImpulsesValue} имп/с",
                                        caption: $"Результаты проверки {address}");

                        logger.Debug($"--- Попытка закрыть порт {serialPort.PortName}.");
                        serialPort.Close();
                        serialPort.Dispose();

                        logger.Debug("Все пакеты перемотки кадра успешно отправлены.");
                    }
                }
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
            {
                comPort.Inquiry(serialPort, packages, i);
            }
        }
    }
}
