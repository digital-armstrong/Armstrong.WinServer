using Armstrong.WinServer.Models;
using Armstrong.WinServer.Properties;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace Armstrong.WinServer.Classes
{
    class ComPort
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private int stepIndex;
        private bool startRead;
        string dsTableName = "Table";

        /// <summary>
        /// Инициализирует новый объект COM-port.
        /// </summary>
        /// <param name="portName">Имя COM-port</param>
        /// <param name="baudRate">Скорость COM-port</param>
        /// <returns>Объект SerialPort с заполненными свойствами PortName, BaudRate и StopBits</returns>
        public SerialPort Initialization(string portName, int baudRate)
        {
            SerialPort serialPort = new SerialPort(portName)
            {
                BaudRate = baudRate,
                StopBits = StopBits.One
            };

            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }

            serialPort.PortName = portName;

            try
            {
                serialPort.Open();
                return serialPort;
            }
            catch (Exception e)
            {
                logger.Error(e, "COM-port: Ошибка подключения к " + portName);

                return null;
            }
        }

        /// <summary>
        /// Выполняет запрос/отправку пакета в COM-port.
        /// </summary>
        /// <param name="serialPort">Объект SerialPort.</param>
        /// <param name="packages">Список пакетов для отправки, каждый из которых представляет собой массив из 8 байт.</param>
        /// <param name="inquiryAddress">Адрес устройства, на которой производится запрос/оправка.</param>
        public DialogMessage Inquiry(SerialPort serialPort, List<byte[]> packages, int inquiryAddress)
        {
            if (serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Write(packages[inquiryAddress], 0, 8);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("COM-port закрыт! \nОткрыть настройки?", "Ошибка: COM-port", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    MainSettings options = new MainSettings();
                    options.Show();
                }
                else
                {
                    Application.Exit();
                }
            }

            Thread.Sleep(100);

            return new DialogMessage
            {
                TextColor = Color.Blue,
                MessageType = MessageType.SendedSuccessfull,
                MessageText = "Sending pkg is successfull",
                PackageText = $"OUT:\t{BitConverter.ToString(packages[inquiryAddress])}",
            };
        }

        /// <summary>
        /// Выполняет запрос/отправку одного пакета в COM-port.
        /// </summary>
        /// <param name="serialPort">Объект SerialPort.</param>
        /// <param name="package">Пакет для отправки, представляющий обой массив из 8 байт, первый из которых - адрес.</param>
        public DialogMessage Inquiry(SerialPort serialPort, byte[] package)
        {
            if (serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Write(package, 0, 8);
            }
            else
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("COM-port закрыт! \nОткрыть настройки?", "Ошибка: COM-port", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    MainSettings options = new MainSettings();
                    options.Show();
                }
                else
                {
                    Application.Exit();
                }
            }

            Thread.Sleep(100);

            return new DialogMessage
            {
                TextColor = Color.Blue,
                MessageType = MessageType.SendedSuccessfull,
                MessageText = "Sending pkg is successfull",
                PackageText = $"OUT:\t{BitConverter.ToString(package)}",
            };
        }

        /// <summary>
        /// Выполняет чтение пакета из COM-port.
        /// </summary>
        /// <param name="serialPort">Объект SerialPort.</param>
        /// <param name="inquiryAddress">Адрес устройства, от которого ожидается ответ.</param>
        /// <returns>Возвращает double значение количества импульсов полученных с устройства.</returns>
        public DialogMessage Answer(SerialPort serialPort, int inquiryAddress)
        {
            var packageSize = serialPort.BytesToRead;
            var bufferSize = 8;
            var buffer = new byte[bufferSize];
            var msg = new DialogMessage();
            double impulses = 0;

            if (packageSize != bufferSize)
            {
                msg.MessageType = MessageType.ReceivedError;
                msg.MessageText = $"COM: Size error, pkg size = {packageSize}";
                msg.TextColor = Color.Red;

                for (var i = 0; i < packageSize; i++)
                {
                    try
                    {
                        buffer[i] = (byte)serialPort.ReadByte();
                    }
                    catch (Exception e)
                    {
                        logger.Error(e, "COM-port: ошибка в буфере пакетов, канал " + (inquiryAddress));
                        MessageBox.Show(e.StackTrace);
                    }
                }

                msg.PackageText = $"INP:\t{BitConverter.ToString(buffer)}";

                return msg;
            }

            for (var i = 0; i < packageSize; i++)
            {
                var message = (byte)serialPort.ReadByte();
                var messageReceived = new byte[packageSize];

                messageReceived[i] = message;

                if (inquiryAddress == messageReceived[0])
                {
                    stepIndex = 0;
                    startRead = true;
                }
                if (startRead && stepIndex < packageSize)
                {
                    try
                    {
                        buffer[stepIndex] = message;
                        stepIndex++;
                    }
                    catch (Exception e)
                    {
                        logger.Error(e, "COM-port: ошибка в буфере пакетов, канал " + (inquiryAddress));
                        MessageBox.Show(e.StackTrace);
                    }
                }
                if (startRead && stepIndex == bufferSize)
                {
                    byte[] calculatedCRC = (new byte[2]);
                    byte[] receivedCRC = (new byte[2]);

                    receivedCRC[0] = buffer[6];
                    receivedCRC[1] = buffer[7];

                    PackageControlSum.CalculationCRC(buffer, ref calculatedCRC);

                    int controlCRC = BitConverter.ToInt16(calculatedCRC, 0) - BitConverter.ToInt16(receivedCRC, 0);

                    if (controlCRC == 0)
                    {
                        impulses = BitConverter.ToSingle(buffer, 2);
                    }
                    else
                    {
                        logger.Debug("COM-port: Ошибка CRC: канал " + (inquiryAddress));

                        msg.TextColor = Color.Red;
                        msg.MessageType = MessageType.ReceivedError;
                        msg.MessageText = $"COM: CRC16 error: received: {BitConverter.ToString(receivedCRC)}, calculated: {BitConverter.ToString(calculatedCRC)}";
                        msg.PackageText = $"INP:\t{BitConverter.ToString(buffer)}";

                        return msg;
                    }
                }
            }

            msg.TextColor = Color.Green;
            msg.MessageType = MessageType.ReceivedSuccessfull;
            msg.MessageText = "Receive pkg is successfull";
            msg.PackageText = $"INP:\t{BitConverter.ToString(buffer)}";
            msg.Value = impulses;

            return msg;
        }

        /// <summary>
        /// Выполняет обработку полученного пакета из COM-port и сохранение данных в DataSet.
        /// </summary>
        /// <param name="dataSet">Объект DataSet, в котором хранится temp-таблица monitor.</param>
        /// <param name="inquiryAddress">Адрес канала, для которого производится обработка.</param>
        /// <param name="impulses">Количество импульсов.</param>
        /// <returns>ID состояния для цветовой маркеровки.</returns>
        public int Processing(DataSet dataSet, int inquiryAddress, double impulses)
        {
            var backgroundValue = (double)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_background];
            var blockType = (int)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.block_type];
            var channelCoefficient = (double)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_coefficient];

            double value = UnitConverter.Convert(blockType, channelCoefficient, impulses);
            value = value >= backgroundValue ? value - backgroundValue : 0;

            double notSystemValue = UnitConverter.Convert(blockType, value);
            int state = 0;
            DateTime dateTime = DateTime.Now;

            if ((double)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.value_system] != value)
            {
                // save data
                dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.value_system] = value;
                dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.value_not_system] = notSystemValue;
                dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.value_impulses] = impulses;
                dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.event_date] = dateTime;
                dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_error_count] = 0;

                var preAccident = (double)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_pre_accident];
                var accident = (double)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_accident];

                if (dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_unic_count] != DBNull.Value)
                {
                    var valueCount = (int)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_unic_count];
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_unic_count] = ++valueCount;
                }
                else
                {
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_unic_count] = 1;
                }

                // color marking
                // accident
                if (value >= accident)
                {
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_state] = DetectorsInfo.StateAccident;
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_image_state] = Resources.accident_state;
                    state = DetectorsInfo.StateAccident;
                }
                // pre accident
                if (value >= preAccident && value < accident)
                {
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_state] = DetectorsInfo.StatePreAccident;
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_image_state] = Resources.preaccident_state;
                    state = DetectorsInfo.StatePreAccident;
                }
                // normal
                if (value < preAccident)
                {
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_state] = DetectorsInfo.StateNormal;
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_image_state] = Resources.normal_state;
                    state = DetectorsInfo.StateNormal;
                }
                return state;
            }
            else
            {
                if (dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_error_count] != DBNull.Value)
                {
                    var errorCount = (int)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_error_count];
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_error_count] = ++errorCount;

                    if ((int)dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_error_count] > 59)
                    {
                        dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_state] = DetectorsInfo.StateOffline;
                        dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_image_state] = Resources.failure_state;
                    }
                }
                else
                {
                    dataSet.Tables[dsTableName].Rows[inquiryAddress][Map.channel_value_error_count] = 1;
                }

                return 0;
            }
        }
    }
}
