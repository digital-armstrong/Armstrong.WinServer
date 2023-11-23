using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Armstrong.WinServer.Properties;
using Armstrong.WinServer.Classes;
using NLog;
using System.Reflection;
using Armstrong.WinServer.Models;

namespace Armstrong.WinServer
{
    public partial class MainForm : Form
    {
        string dsTableName = "Table";

        private CancellationTokenSource cancellation;
        SerialPort serialPort;
        public DataSet dataSet = new DataSet();
        public DataTable dataTable = new DataTable();
        public DataTable dataTableTemp = new DataTable();
        private const int dataSize = 8;                                                                         // Задаём фиксированный объем буффера
        private byte[] _buffer = new byte[dataSize];                                                            // Используем фиксированный объем буффера
        List<int> selectedId = new List<int>();

        List<byte[]> valuePackages, ledGRN, ledYEL, ledRED, SendSpecialSignal, ledOFF, blenkerOpenPackages, blenkerClosePackages,
            rewindStartPackages, rewindResultPackages;
        static private Logger logger;

        ComPort comPort = new ComPort();
        SQL sql = new SQL();

        private Task SerialPortTask;

        public MainForm()
        {
            InitializeComponent();

            // 1. Загрузить настройки
            // 2. Включить двойную буферизацию в DataGridWiew

            // Включаем двойную буферизацию для DataGridView
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dataGridView1,
                new object[] { true });

            dataGridView1.AutoGenerateColumns = false;

            logger = LogManager.GetCurrentClassLogger();
            logger.Info("Приложение запущено");
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Error("Unhandled exception: {0}", e.ExceptionObject);
            LogManager.Flush();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Заполнить DataGridWiew в отдельном потоке
            StartExecute();
            treeView1.Enabled = false;

            var dgvColumns = dataGridView1.Columns;
            dgvColumns[Map.channel_global_id].DataPropertyName = Map.channel_global_id;
            dgvColumns[Map.channel_id].DataPropertyName = Map.channel_id;
            dgvColumns[Map.id_server].DataPropertyName = Map.id_server;
            dgvColumns[Map.channel_image_state].DataPropertyName = Map.channel_image_state;
            dgvColumns[Map.control_point].DataPropertyName = Map.control_point;
            dgvColumns[Map.block_name].DataPropertyName = Map.block_name;
            dgvColumns[Map.block_location].DataPropertyName = Map.block_location;
            dgvColumns[Map.value_system].DataPropertyName = Map.value_system;
            dgvColumns[Map.unit].DataPropertyName = Map.unit;
            dgvColumns[Map.value_not_system].DataPropertyName = Map.value_not_system;
            dgvColumns[Map.event_date].DataPropertyName = Map.event_date;
            dgvColumns[Map.channel_value_unic_count].DataPropertyName = Map.channel_value_unic_count;
            dgvColumns[Map.value_impulses].DataPropertyName = Map.value_impulses;
            dgvColumns[Map.channel_value_error_count].DataPropertyName = Map.channel_value_error_count;
            dgvColumns[Map.block_type].DataPropertyName = Map.block_type;
            dgvColumns[Map.channel_power_state].DataPropertyName = Map.channel_power_state;
            dgvColumns[Map.channel_coefficient].DataPropertyName = Map.channel_coefficient;
            dgvColumns[Map.channel_pre_accident].DataPropertyName = Map.channel_pre_accident;
            dgvColumns[Map.channel_accident].DataPropertyName = Map.channel_accident;
            dgvColumns[Map.channel_state].DataPropertyName = Map.channel_state;
            dgvColumns[Map.block_min_nuclid].DataPropertyName = Map.block_min_nuclid;
            dgvColumns[Map.block_max_nuclid].DataPropertyName = Map.block_max_nuclid;
            dgvColumns[Map.channel_background].DataPropertyName = Map.channel_background;

            Thread thread = new Thread(TimerThread)
            {
                IsBackground = true,
                Name = "TimerThread"
            };
            thread.Start();
        }

        private void TimerThread()
        {
            System.Timers.Timer timer = new System.Timers.Timer()
            {
                Enabled = true,
                Interval = 1000,
                AutoReset = true
            };
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string signalTime = DateTime.Now.ToString("T");
            string timeNewShift = SettingsVariable.GetValue<string>(Constants.SettingName.TimeNewShift);

            if (signalTime == timeNewShift)
            {
                StartNewShift();
            }
        }

        /// <summary>
        /// Запускает новую смену (осуществляет перемотку ленты)
        /// </summary>
        private async void StartNewShift()
        {
            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
            });

            await AwaitStopExecute();

            if (serialPort.IsOpen)
            {
                serialPort.Close();
                serialPort.Dispose();
            }

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение остановлено";
            });

            List<int> addressList = new List<int>();
            foreach (DataRow row in dataSet.Tables[dsTableName].Rows)
            {
                switch (row[Map.block_type])
                {
                    case DetectorsInfo.TypeED:
                        break;
                    case DetectorsInfo.TypeOG:
                        break;
                    case DetectorsInfo.TypeOA:
                        addressList.Add((int)row[Map.channel_id]);
                        break;
                }
            }

            Task task = null;
            task = Task.Run(() =>
            {
                NewShift newShift = new NewShift();
                newShift.Rewind(serialPort, addressList);
                Invoke((MethodInvoker)delegate
                {
                    toolStripStatusLabel1.Text = ("Начало новой смены.");
                });
                Thread.Sleep(60000);

                foreach (int address in addressList)
                    logger.Info("System: успешная перемотка ленты канала {0}", address);

                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    serialPort.Dispose();
                }

                StartExecute();
            });
        }
        public void StopExecute()
        {
            cancellation?.Cancel();
            logger.Debug("Выполнение потока прервано!");
        }
        public void StartExecute()
        {
            MainMethod();
        }
        public async void MainMethod()
        {

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение работает";
            });

            cancellation = new CancellationTokenSource();

            await DataGridView_Fill(cancellation.Token);
            if (!cancellation.Token.IsCancellationRequested)
            {
                SerialPortDialog(cancellation.Token);
            }
        }

        // Serial port - send, read and processing task 
        private void SerialPortDialog(CancellationToken token)
        {
            SerialPortTask = Task.Run(() =>
            {
                logger.Debug("Запущен поток опроса каналов.");
                try
                {
                    double impulses;
                    string portName = SettingsVariable.GetValue<string>(Constants.SettingName.ComPortName);
                    string historyTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.HistoryTable);
                    int baudRate = SettingsVariable.GetValue<int>(Constants.SettingName.ComPortBaudRate);

                    serialPort = comPort.Initialization(portName, baudRate);

                    if (serialPort == null)
                    {
                        MessageBox.Show($"Не удалось установить соединение с Com-port или порт Com-port не существует! \nДля устранения ошибки проверьте настройки соединения.",
                            "Ошибка: COM-port",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        StopExecute();

                        StopExecute();

                        Invoke((MethodInvoker)delegate
                        {
                            toolStripStatusLabel1.Text = "Приложение остановлено: COMPORT-ERROR";
                        });

                        if (token.IsCancellationRequested)
                            throw new TaskCanceledException(SerialPortTask);
                    }

                    logger.Debug("Запускается цикл опроса...");
                    while (serialPort.IsOpen)
                    {
                        if (token.IsCancellationRequested)
                            throw new TaskCanceledException(SerialPortTask);

                        for (int i = 0; i < dataSet.Tables[dsTableName].Rows.Count; i++)
                        {
                            if ((int)dataSet.Tables[dsTableName].Rows[i][Map.channel_power_state] == DetectorsInfo.Power_OFF)
                                continue;

                            comPort.Inquiry(serialPort, valuePackages, i);
                            impulses = comPort.Answer(serialPort, i + 1);
                            var state = comPort.Processing(dataSet, i, impulses);

                            // Light alarm
                            // 0 -- Non-unique value, 1 -- accident (R), 2 -- pre-accident (Y), 3 -- normal (G), 8 -- device failure (off)
                            switch (state)
                            {
                                case 0:
                                    break;
                                case DetectorsInfo.StateAccident:
                                    if ((bool)dataSet.Tables[dsTableName].Rows[i][Map.channel_special_control])
                                        comPort.Inquiry(serialPort, SendSpecialSignal, i);
                                    else
                                        comPort.Inquiry(serialPort, ledRED, i);
                                    break;
                                case DetectorsInfo.StatePreAccident:
                                    comPort.Inquiry(serialPort, ledYEL, i);
                                    break;
                                case DetectorsInfo.StateNormal:
                                    comPort.Inquiry(serialPort, ledGRN, i);
                                    break;
                                case DetectorsInfo.StateOffline:
                                    comPort.Inquiry(serialPort, ledOFF, i);
                                    break;
                            }
                        }

                        foreach (DataRow row in this.dataSet.Tables[this.dsTableName].Rows)
                        {
                            int id = Convert.ToInt32(row[Map.channel_global_id]);
                            int count = (int)row[Map.channel_value_unic_count];
                            int errorCount = (int)row[Map.channel_value_error_count];
                            double systemValue = (double)row[Map.value_system];
                            double notSystemValue = (double)row[Map.value_not_system];
                            double impulsesValue = (double)row[Map.value_impulses];
                            DateTime dateTime = (DateTime)row[Map.event_date];
                            string unit = (string)row[Map.unit];
                            int channelState = (int)row[Map.channel_state];

                            var updater = new ChannelMonitorUpdater()
                            {
                                Id = id,
                                SystemEventValue = systemValue,
                                ImpulsesEventValue = impulsesValue,
                                NotSystemEventValue = notSystemValue,
                                EventCount = count,
                                ErrorEventCount = errorCount,
                                EventDateTime = dateTime,
                                ChannelState = channelState,
                                Unit = unit
                            };

                            updater.SetQueryString();

                            if (impulsesValue != 0)
                            {
                                this.sql.Insert(historyTable, id, systemValue, dateTime);
                            }

                            this.sql.Update(updater);
                        }

                        int timeToAsk = (int)SettingsVariable.GetValue<float>(Constants.SettingName.TimeToAsk);

                        for (int i = 0; i < timeToAsk; i++)
                        {
                            if (token.IsCancellationRequested)
                                throw new TaskCanceledException(SerialPortTask);

                            Thread.Sleep(1000);
                        }
                    }

                    logger.Debug("Видимо SerialPort закрылся");
                    throw new TaskCanceledException(SerialPortTask);
                }
                catch (TaskCanceledException)
                {
                    logger.Debug($"{MethodBase.GetCurrentMethod().Name}:Задача была прервана");
                }
                catch(Exception e)
                {
                    logger.Debug(e);
                }
            });
            return;
        }

        /// <summary>
        /// Выполняет формирование пакетов запросов и заполнение таблицы в DataSet/DataGridViev данными.
        /// </summary>
        /// <param name="token">Токен, сигнализирующий об отмене Task-а.</param>
        /// <returns>Вернет объект Task-а.</returns>
        private Task DataGridView_Fill(CancellationToken token)
        {
            logger.Debug($"Заполнение локальных таблиц...");

            Task task = null;
            task = Task.Run(() =>
            {
                string monitorTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.MonitorTable);

                logger.Debug($"--- Получение данных из {monitorTable}");

                dataSet = sql.Select(monitorTable);

                if (dataSet == null)
                {
                    logger.Error($"--- DataSet не был заполнен, осуществляется прерывание потока.");

                    MessageBox.Show($"Неудачная попытка подключения к MS SQL\nДля устранения ошибки проверьте настройки соединения.",
                        "Ошибка: SQL-connection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    StopExecute();

                    Invoke((MethodInvoker)delegate
                    {
                        toolStripStatusLabel1.Text = "Приложение остановлено: SQL-ERROR";
                    });
                }

                else
                {
                    logger.Debug($"--- Данные успешно получены.");

                    DataColumn imageColumn = new DataColumn
                    {
                        ColumnName = Map.channel_image_state,
                        DataType = typeof(Icon)
                    };

                    dataSet.Tables[dsTableName].Columns.Add(imageColumn);
                }

                // Инициализация пакетов и списков
                // ВАЖНО! нумерация в List начинается___с 0
                //        нумерация каналов_____________с 1
                try
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException(task);

                    int count = 0;
                    if (dataSet.Tables.Count > 0)
                    {
                        count = dataSet.Tables[dsTableName].Rows.Count;

                        PackagesInitialization packagesInitialization = new PackagesInitialization();

                        valuePackages = packagesInitialization.GeneratePackages(count, Function.GetValue);

                        ledGRN = packagesInitialization.GeneratePackages(count, Function.SetLed, LedColor.GRN);
                        ledYEL = packagesInitialization.GeneratePackages(count, Function.SetLed, LedColor.YEL);
                        ledRED = packagesInitialization.GeneratePackages(count, Function.SetLed, LedColor.RED);
                        ledOFF = packagesInitialization.GeneratePackages(count, Function.SetLed, LedColor.OFF);
                        SendSpecialSignal = packagesInitialization.GeneratePackages(count, Function.SetLed, LedColor.RED, ActionType.SendSpeсialSignal);

                        blenkerClosePackages = packagesInitialization.GeneratePackages(count, Function.StartService, Operation.Write, ActionType.CloseBlenker);
                        blenkerOpenPackages = packagesInitialization.GeneratePackages(count, Function.StartService, Operation.Write, ActionType.OpenBlenker);
                        rewindStartPackages = packagesInitialization.GeneratePackages(count, Function.StartService, Operation.Write, ActionType.Rewind);
                        rewindResultPackages = packagesInitialization.GeneratePackages(count, Function.StartService, Operation.Read);

                        Invoke((MethodInvoker)delegate
                        {
                            dataGridView1.DataSource = dataSet.Tables[dsTableName];
                        });

                        for (int i = 0; i < dataSet.Tables[dsTableName].Rows.Count; i++)
                        {
                            int type = (int)dataSet.Tables[dsTableName].Rows[i][Map.block_type];
                            switch (type)
                            {
                                case DetectorsInfo.TypeED:
                                    dataSet.Tables[dsTableName].Rows[i][Map.unit] = "мЗв/ч";
                                    break;
                                case DetectorsInfo.TypeOG:
                                    dataSet.Tables[dsTableName].Rows[i][Map.unit] = "Бк/м³";
                                    break;
                                case DetectorsInfo.TypeOA:
                                    dataSet.Tables[dsTableName].Rows[i][Map.unit] = "Бк/м³";
                                    break;
                                case DetectorsInfo.TypeIC:
                                    dataSet.Tables[dsTableName].Rows[i][Map.unit] = "имп/с";
                                    break;
                            }
                            // Установить световую сигнализацию в Зелёную позицию
                            dataSet.Tables[dsTableName].Rows[i][Map.channel_value_unic_count] = 0;
                            dataSet.Tables[dsTableName].Rows[i][Map.channel_value_error_count] = 0;
                            dataSet.Tables[dsTableName].Rows[i][Map.value_system] = 0;
                            dataSet.Tables[dsTableName].Rows[i][Map.value_impulses] = 0;
                            dataSet.Tables[dsTableName].Rows[i][Map.value_not_system] = 0;

                            if ((bool)dataSet.Tables[dsTableName].Rows[i][Map.channel_special_control])
                                dataGridView1.Rows[i].Cells[Map.channel_special_control].Value = true;

                            switch ((int)dataSet.Tables[dsTableName].Rows[i][Map.channel_state])
                            {
                                case DetectorsInfo.StateAccident:
                                    dataSet.Tables[dsTableName].Rows[i][Map.channel_image_state] = Resources.accident_state;
                                    break;
                                case DetectorsInfo.StatePreAccident:
                                    dataSet.Tables[dsTableName].Rows[i][Map.channel_image_state] = Resources.preaccident_state;
                                    break;
                                case DetectorsInfo.StateNormal:
                                    dataSet.Tables[dsTableName].Rows[i][Map.channel_image_state] = Resources.normal_state;
                                    break;
                                case DetectorsInfo.StateOffline:
                                    dataSet.Tables[dsTableName].Rows[i][Map.channel_image_state] = Resources.failure_state;
                                    break;
                                case DetectorsInfo.StatePowerOff:
                                    dataSet.Tables[dsTableName].Rows[i][Map.channel_image_state] = Resources.offline_state;
                                    break;
                            }
                            if ((int)dataSet.Tables[dsTableName].Rows[i][Map.channel_power_state] == DetectorsInfo.Power_OFF)
                            {
                                dataSet.Tables[dsTableName].Rows[i][Map.channel_image_state] = Resources.offline_state;
                            }
                        }
                    }
                }
                catch (TaskCanceledException)
                {
                    logger.Debug("Task: Задача была прервана");
                }

            });
            return task;
        }

        private async void ShowOption()
        {
            // 1. Остановить поток опроса
            // 2. Закрыть COM-port
            // 3. Сообщить приложению, что будет совершен респринг (restart = true)
            
            logger.Debug("Вызвано метод настроек приложения.");

            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
                settingsToolStripMenuItem.Enabled = false;
            });

            await AwaitStopExecute();

            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                {
                    logger.Debug("COM-port все еще не был закрыт...");
                    serialPort.Close();
                    serialPort.Dispose();
                    logger.Debug("COM-port закрыт.");
                }
            }

            MainSettings options = new MainSettings();
            options.Owner = this;

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение остановлено";
                settingsToolStripMenuItem.Enabled = true;
            });

            logger.Debug("Вызвано окно настроек приложения.");
            options.ShowDialog();
            StartExecute();
        }

        // Checking SerialPortTask status. Waiting when SerialPortTask will be DIE.
        public Task AwaitStopExecute() => Task.Factory.StartNew(() =>
        {
            if (SerialPortTask != null)
            {
                while (SerialPortTask.Status == TaskStatus.Running)
                {
                    Thread.Sleep(100);
                }
            }
            else
                return;
        });

        // Кнопка Настройки в верхней панели
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOption();
        }


        #region Context menu click events

        /// <summary>
        /// Добавляет новый канал по клику в контекстном меню по ПКМ в таблице.
        /// </summary>
        private async void AddChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Остановить поток опроса
            // 2. Закрыть COM-port
            // 3. Сообщить приложению, что будет совершен респринг (restart = true)
            logger.Debug("Вызван метод добавление канала.");
            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
            });

            await AwaitStopExecute();

            if (serialPort.IsOpen)
            {
                logger.Debug("COM-port все еще не был закрыт...");
                serialPort.Close();
                serialPort.Dispose();
                logger.Debug("COM-port закрыт.");
            }

            ChannelAdd addChannel = new ChannelAdd();
            addChannel.Owner = this;

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение остановлено";
            });

            logger.Debug("Вызвано окно добавление канала");
            addChannel.ShowDialog();
            StartExecute();
        }

        // Удаление канала
        private async void RemoveChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Debug("Вызван метод удаление канала.");
            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
            });

            await AwaitStopExecute();

            if (serialPort.IsOpen)
            {
                logger.Debug("COM-port все еще не был закрыт...");
                serialPort.Close();
                serialPort.Dispose();
                logger.Debug("COM-port закрыт.");
            }

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение остановлено";
            });

            int id = (int)dataGridView1.SelectedRows[0].Cells[Map.channel_id].Value;
            string monitorTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.MonitorTable);

            DialogResult result = MessageBox.Show($"Удалить канал №{id} из базы данных", "Подтверждение:", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                sql.Delete(monitorTable, id);
                StartExecute();
                MessageBox.Show("Устройство удалёно!");
                logger.Debug($"Канал {id} удален.");
            }
            if (result == DialogResult.Cancel)
            {
                StartExecute();
            }
        }
        // Перемотка отдельного канала
        private async void rewindTapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Debug("Вызван метод перемотки кадра одного канала.");
            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
            });

            await AwaitStopExecute();

            if (serialPort.IsOpen)
            {
                serialPort.Close();
                serialPort.Dispose();
            }

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение остановлено";
            });

            int address = (int)dataGridView1.SelectedRows[0].Cells[Map.channel_id].Value;
            var channelGlobalId = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[Map.channel_global_id].Value);

            string historyTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.HistoryTable);
            sql.Insert(table: historyTable, id: channelGlobalId, value: 0, date: DateTime.Now);

            Task task = null;
            task = Task.Run(() =>
            {
                NewShift newShift = new NewShift();
                var channelInfo = dataSet.Tables[dsTableName].AsEnumerable().FirstOrDefault(row => row.Field<int>(Map.channel_global_id) == channelGlobalId);
                
                newShift.Rewind(serialPort, address, channelInfo);
                Invoke((MethodInvoker)delegate
                {
                    toolStripStatusLabel1.Text = ($"Перемотка ленты канала № {address}");
                });
                Thread.Sleep(60000);

                logger.Info($"System: успешная перемотка ленты канала {address}");

                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    serialPort.Dispose();
                }

                StartExecute();
            });
        }
        // Тест СК
        private async void checkSpecialSignalMenuItem_Click(object sender, EventArgs e)
        {
            var id = (int)dataGridView1.SelectedRows[0].Cells[Map.channel_id].Value;
            logger.Debug($"Вызван метод проверки спец. сигнала канала {id}");

            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
            });

            await AwaitStopExecute();

            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                {
                    logger.Debug("COM-port все еще не был закрыт...");
                    serialPort.Close();
                    serialPort.Dispose();
                    logger.Debug("COM-port закрыт.");
                }
            }

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = $"Приложение остановлено. Тест сигнала СК канала №{id}";
            });

            Task task = null;
            task = Task.Run(() =>
            {
                if (!serialPort.IsOpen)
                    serialPort.Open();

                id--; // так как нумерация каналов с 1, а нумерация в списке/dgv/массивве с 0

                for (int i = 0; i < 3; i++)
                {
                    comPort.Inquiry(serialPort, SendSpecialSignal, id);
                    dataSet.Tables[dsTableName].Rows[id][Map.channel_image_state] = Resources.accident_state;
                    Thread.Sleep(500);

                    comPort.Inquiry(serialPort, ledGRN, id);
                    dataSet.Tables[dsTableName].Rows[id][Map.channel_image_state] = Resources.normal_state;
                    Thread.Sleep(500);
                }

                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    serialPort.Dispose();
                }

                StartExecute();
            });

        }
        // Расчет выброса
        private void blowoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Debug("Вызван метод расчета выбросов.");
            DatePicker datePicker = new DatePicker(selectedId);
            datePicker.Show();
        }

        // Вызов графика
        private void ShowChart_Event(object sender, EventArgs e)
        {
            logger.Debug("Вызвано окно выбора дат для построения графиков.");
            DatePicker datePicker = new DatePicker(selectedId);
            datePicker.Show();
        }

        // Настройки канала
        private async void OptionsChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
            });

            await AwaitStopExecute();

            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                {
                    logger.Debug("COM-port все еще не был закрыт...");
                    serialPort.Close();
                    serialPort.Dispose();
                    logger.Debug("COM-port закрыт.");
                }
            }

            ChannelSettings changeChannel = new ChannelSettings();
            changeChannel.Owner = this;

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение остановлено";
            });

            logger.Debug("Вызвано окно настроек канала.");
            changeChannel.ShowDialog();
            StartExecute();
        }

        private async void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.DoubleClick -= dataGridView1_DoubleClick;

            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
            });

            await AwaitStopExecute();

            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                {
                    logger.Debug("COM-port все еще не был закрыт...");
                    serialPort.Close();
                    serialPort.Dispose();
                    logger.Debug("COM-port закрыт.");
                }
            }

            ChannelSettings changeChannel = new ChannelSettings();
            changeChannel.Owner = this;

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение остановлено";
            });

            logger.Debug("Вызвано окно настроек канала.");
            changeChannel.ShowDialog();

            dataGridView1.DoubleClick += new EventHandler(dataGridView1_DoubleClick);

            StartExecute();
        }

        // Новая смена
        private void NewShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Debug("Принудительно запущено начало новой смены.");
            StartNewShift();
        }

        // Обработка ошибки DataError
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            logger.Error("Data Grid: ошибка привязки данных.");
        }

        /// <summary>
        /// Добавляет новый канал по клику в Tool-баре "Сервис" --> "Добавить канал".
        /// </summary>
        private async void addChannelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 1. Остановить поток опроса
            // 2. Закрыть COM-port
            // 3. Сообщить приложению, что будет совершен респринг (restart = true)

            StopExecute();

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Завершение всех процессов...";
            });

            await AwaitStopExecute();

            if (serialPort.IsOpen)
            {
                logger.Debug("COM-port все еще не был закрыт...");
                serialPort.Close();
                serialPort.Dispose();
                logger.Debug("COM-port закрыт.");
            }

            ChannelAdd addChannel = new ChannelAdd();
            addChannel.Owner = this;

            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Приложение остановлено";
            });

            logger.Debug("Вызвано окно добавления канала.");
            addChannel.ShowDialog();
            StartExecute();
        }
        // Вид
        private void visionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Debug("Вызвано окно \"Вид\".");
            GridVision gridVision = new GridVision(this);
            this.AddOwnedForm(gridVision);
            gridVision.Show();
        }
        #endregion
        
        // Selecting rows with Right Mouse Button Click
        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;

                // Set context menu show-position
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        // Reading a selected channels-id
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectedId.Clear();

            switch (dataGridView1.SelectedRows.Count != 1)
            {
                case true:
                    for(int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        selectedId.Add(Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[Map.channel_global_id].Value));
                    break;
                case false:
                    selectedId.Add(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[Map.channel_global_id].Value));
                    break;
            }
        }

        // Метод, регистрирующий нажатие по чекбоксу спец. сигнала
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            string monitorTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.MonitorTable);

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    senderGrid.EndEdit();
                    dataSet.Tables[dsTableName].Rows[e.RowIndex][Map.channel_special_control] = false;
                    var globalId = Convert.ToInt32(dataSet.Tables[dsTableName].Rows[e.RowIndex][Map.channel_global_id]);
                    sql.UpdateById(globalId, false, Map.channel_special_control, monitorTable);
                }
                else
                {
                    senderGrid.EndEdit();
                    dataSet.Tables[dsTableName].Rows[e.RowIndex][Map.channel_special_control] = true;
                    var globalId = Convert.ToInt32(dataSet.Tables[dsTableName].Rows[e.RowIndex][Map.channel_global_id]);
                    sql.UpdateById(globalId, true, Map.channel_special_control, monitorTable);
                }
            }
        }

        // Close MainForm event
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Debug("Выполняется закрытие приложения...");

            StopExecute();

            await AwaitStopExecute();

            logger.Debug("Выполняется отключение световой сигнализации...");
            // Turn off the Light Alarm
            if (dataSet.Tables.Count > 0)
                for (int i = 0; i < dataSet.Tables[dsTableName].Rows.Count; i++)
                {
                    comPort.Inquiry(serialPort, ledOFF, i);
                    Thread.Sleep(100);
                }
            else
                return;
        }
    }
}
