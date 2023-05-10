using Armstrong.WinServer.Models;
using NLog;
using Npgsql;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Armstrong.WinServer.Classes
{
    /// <summary>
    /// Предоставляет методы для работы с SQL базой данных.
    /// </summary>
    class SQL
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Stopwatch stopwatch = new Stopwatch();
        public int connectionErrorCount { get; set; } = 0;

        /// <summary>
        /// Выполняет простой запрос SELECT в базу данных.
        /// </summary>
        /// <param name="table">Имя таблицы в базе данных.</param>
        /// <returns>Все данные в таблице в виде DataSet или NULL</returns>
        public DataSet Select(string table)
        {
            logger.Debug($"Осуществляется попытка выполнить SELECT в таблицу {table}.");
            string serverId = SettingsVariable.GetValue<string>(Constants.SettingName.ServerId);

            string query = $"SELECT * FROM {table} WHERE {Map.id_server} = {serverId} ORDER BY {Map.channel_id}";
            string connectionString = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.ConnectionString);
            DataSet dataSet = new DataSet();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, connection);

            try
            {
                connection.Open();
                logger.Debug("--- Соединение успешно открыто.");
                stopwatch.Start();
                dataAdapter.Fill(dataSet);
                stopwatch.Stop();
                connection.Close();
                connection.Dispose();
                logger.Debug("--- Соединение успешно закрыто.");
                logger.Debug($"--- Время выполнения запроса и получения данных: {stopwatch.ElapsedMilliseconds} милисекунд.");


                connectionErrorCount = 0;
                return dataSet;
            }
            catch (Exception e)
            {
                connectionErrorCount += 1;

                logger.Error(e, $"SQL: Неудачная попытка подключения №{connectionErrorCount}");
                if (connectionErrorCount > 3)
                {
                    MessageBox.Show("Неудачная попытка подключения к PostgreSQL\n" + e.StackTrace);
                    return null;
                }
                else
                {
                    Thread.Sleep(10000);
                    Select(table);
                }

                return null;
            }
        }

        /// <summary>
        /// Выполняет заранее сформированный запрос SELECT в базу данных.
        /// </summary>
        /// <param name="query">Готовая к выполнению строка запроса.</param>
        /// <returns></returns>
        public DataSet SelectWithQuery(string query)
        {
            logger.Debug($"Осуществляется попытка выполнить SELECT с запросом {query}.");

            string connectionString = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.ConnectionString);
            DataSet dataSet = new DataSet();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, connection);

            try
            {
                connection.Open();
                logger.Debug("--- Соединение успешно открыто.");
                stopwatch.Start();
                dataAdapter.Fill(dataSet);
                stopwatch.Stop();
                connection.Close();
                connection.Dispose();
                logger.Debug("--- Соединение успешно закрыто.");
                logger.Debug($"--- Время выполнения запроса и получения данных: {stopwatch.ElapsedMilliseconds} милисекунд.");

                connectionErrorCount = 0;
                return dataSet;
            }
            catch (Exception e)
            {
                connectionErrorCount += 1;

                logger.Error(e, $"SQL: Неудачная попытка подключения №{connectionErrorCount}");
                if (connectionErrorCount > 3)
                {
                    MessageBox.Show("Неудачная попытка подключения к PostgreSQL\n" + e.StackTrace);
                    return null;
                }
                else
                {
                    Thread.Sleep(10000);
                    SelectWithQuery(query);
                }

                return null;
            }
        }

        /// <summary>
        /// Выполянет вставку данных (запрос INSERT) в таблицу "table" выбранной базы данных.
        /// </summary>
        /// <param name="table">Имя таблицы в базе данных.</param>
        /// <param name="id">Номер канала.</param>
        /// <param name="value">Значение, полученное от блока детектирования.</param>
        /// <param name="date">Время, в которое зафиксировано значение.</param>
        /// <param name="name">Имя канала.</param>
        public void Insert(string table, int id, double value, DateTime date)
        {
            string connectionString = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.ConnectionString);
            string query = $"INSERT INTO {table} ({Map.history_channel_id}, {Map.value_system}, {Map.event_date}) VALUES({id}, @value, @date)";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand saveHistory = new NpgsqlCommand(query, connection);

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                connectionErrorCount += 1;

                logger.Error(e, $"SQL: Неудачная попытка подключения №{connectionErrorCount}");
                if (connectionErrorCount > 3)
                {
                    MessageBox.Show("Неудачная попытка подключения к PostgreSQL\n" + e.StackTrace);
                    return;
                }

                Thread.Sleep(10000);
                Insert(table, id, value, date);
            }

            saveHistory.Parameters.Add("@value", NpgsqlTypes.NpgsqlDbType.Double);
            saveHistory.Parameters.Add("@date", NpgsqlTypes.NpgsqlDbType.Timestamp);
            saveHistory.Parameters[0].Value = value;
            saveHistory.Parameters[1].Value = date;

            try
            {
                saveHistory.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connectionErrorCount += 1;
                logger.Error(e, $"SQL: ошибка сохоранения истории №{connectionErrorCount}");
                if (connectionErrorCount > 3)
                {
                    MessageBox.Show("Ошибка при сохранении изменений в Sql db. \n\nОписание ошибки:\n\n" + e.ToString());
                    return;
                }

                Thread.Sleep(10000);
                Insert(table, id, value, date);
            }

            connectionErrorCount = 0;
            connection.Close();
            connection.Dispose();
        }

        /// <summary>
        /// Выполянет вставку данных (запрос INSERT) в конкретную таблицу "monitor" (имя которой сохранено в настройках) выбранной базы данных.
        /// </summary>
        /// <param name="columnNameString">Строка с перечнем колонок для вставки в таблицу.</param>
        /// <param name="valuesString">Строка с перечнем значений колонок для вставки в таблицу.</param>
        /// <param name="coefficientParameter">Коеффициент преобразования.</param>
        /// <param name="preAccidentParameter">Предаварийаня уставка.</param>
        /// <param name="accidentParameter">Аварийная уставка.</param>
        /// <param name="minParameter">Минимальное значение от источника.</param>
        /// <param name="maxParameter">Максимальное значение от источника.</param>
        public void Insert(string columnNameString,
                           string valuesString,
                           double coefficientParameter,
                           double preAccidentParameter,
                           double accidentParameter,
                           double minParameter,
                           double maxParameter)
        {
            string connectionString = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.ConnectionString);
            string monitorTable = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.MonitorTable);
            string query = $"INSERT INTO {monitorTable} ({columnNameString}) VALUES ({valuesString})";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.Parameters.Add("@coefficient", NpgsqlTypes.NpgsqlDbType.Double);
            command.Parameters[0].Value = coefficientParameter;

            command.Parameters.Add("@pre_accident", NpgsqlTypes.NpgsqlDbType.Double);
            command.Parameters[1].Value = preAccidentParameter;

            command.Parameters.Add("@accident", NpgsqlTypes.NpgsqlDbType.Double);
            command.Parameters[2].Value = accidentParameter;

            command.Parameters.Add("@min_nuclid_value", NpgsqlTypes.NpgsqlDbType.Double);
            command.Parameters[3].Value = minParameter;

            command.Parameters.Add("@max_nuclid_value", NpgsqlTypes.NpgsqlDbType.Double);
            command.Parameters[4].Value = maxParameter;


            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                connectionErrorCount += 1;

                logger.Error(e, $"SQL: Неудачная попытка подключения №{connectionErrorCount}");
                if (connectionErrorCount > 3)
                {
                    MessageBox.Show("Неудачная попытка подключения к PostgreSQL\n" + e.StackTrace);
                    return;
                }

                Thread.Sleep(10000);
                Insert(columnNameString,
                            valuesString,
                            coefficientParameter,
                            preAccidentParameter,
                            accidentParameter,
                            minParameter,
                            maxParameter);
            }
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connectionErrorCount += 1;
                logger.Error(e, $"SQL: ошибка сохоранения истории №{connectionErrorCount}");
                if (connectionErrorCount > 3)
                {
                    MessageBox.Show("Ошибка при сохранении изменений в Sql db. \n\nОписание ошибки:\n\n" + e.ToString());
                    return;
                }

                Thread.Sleep(10000);
                Insert(columnNameString,
                            valuesString,
                            coefficientParameter,
                            preAccidentParameter,
                            accidentParameter,
                            minParameter,
                            maxParameter);
            }

            connectionErrorCount = 0;
            connection.Close();
            connection.Dispose();
        }

        /// <summary>
        /// Выполняет удаленее строк (запрос DELETE) из таблицы базы данных.
        /// </summary>
        /// <param name="table">Имя таблицы в базе данных.</param>
        /// <param name="id">Номер канала.</param>
        public void Delete(string table, int id)
        {
            string connectionString = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.ConnectionString);
            string query = $"DELETE FROM {table} WHERE {Map.channel_global_id}={id}";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand delete = new NpgsqlCommand(query, connection);

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                logger.Error(e, "SQL: Неудачная попытка подключения");
                MessageBox.Show("Неудачная попытка подключения к MS SQL\n" + e.StackTrace);
                return;
            }
            try
            {
                delete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                logger.Error(e, "SQL: ошибка сохоранения истории");
                MessageBox.Show("Ошибка при сохранении изменений в Sql db. \n\nОписание ошибки:\n\n" + e.ToString());
            }

            connection.Close();
            connection.Dispose();
        }
        public void Update(ChannelMonitorUpdater updater)
        {
            string connectionString = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.ConnectionString);
            string query = updater.UpdateQuery;

            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand updateMonitor = new NpgsqlCommand(query, connection);

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                connectionErrorCount += 1;

                logger.Error(e, $"SQL: Неудачная попытка подключения №{connectionErrorCount}");
                if (connectionErrorCount > 3)
                {
                    MessageBox.Show("Неудачная попытка подключения к PostgreSQL\n" + e.StackTrace);
                    return;
                }

                Thread.Sleep(10000);
                Update(updater);
            }

            updateMonitor.Parameters.Add("@system_value", NpgsqlTypes.NpgsqlDbType.Double);
            updateMonitor.Parameters.Add("@impulse_value", NpgsqlTypes.NpgsqlDbType.Double);
            updateMonitor.Parameters.Add("@not_system_value", NpgsqlTypes.NpgsqlDbType.Double);
            updateMonitor.Parameters.Add("@date", NpgsqlTypes.NpgsqlDbType.Timestamp);

            updateMonitor.Parameters[0].Value = updater.SystemEventValue;
            updateMonitor.Parameters[1].Value = updater.ImpulsesEventValue;
            updateMonitor.Parameters[2].Value = updater.NotSystemEventValue;
            updateMonitor.Parameters[3].Value = updater.EventDateTime;

            try
            {
                updateMonitor.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connectionErrorCount += 1;
                logger.Error(e, $"SQL: ошибка сохоранения истории №{connectionErrorCount}");
                if (connectionErrorCount > 3)
                {
                    MessageBox.Show("Ошибка при сохранении изменений в Sql db. \n\nОписание ошибки:\n\n" + e.ToString());
                    return;
                }

                Thread.Sleep(10000);
                Update(updater);
            }

            connectionErrorCount = 0;
            connection.Close();
            connection.Dispose();
        }
        /// <summary>
        /// Выполняет обновление данных в строке таблицы базы данных.
        /// </summary>
        /// <param name="table">Имя таблицы.</param>
        /// <param name="id">Номер канала.</param>
        /// <param name="value">Значение, полученное с блока детектирования на данном канале.</param>
        public void UpdateById(int id, bool value, string column, string table)
        {
            string connectionString = SettingsVariable.GetValue(Constants.EnvirovmentVariableName.ConnectionString);
            string query = $"UPDATE {table} SET {column} = {value} WHERE {Map.channel_global_id} = {id}";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand updateMonitor = new NpgsqlCommand(query, connection);

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                logger.Error(e, "SQL: Неудачная попытка подключения");
                MessageBox.Show("Неудачная попытка подключения к MS SQL\n" + e.StackTrace);
                return;
            }

            try
            {
                updateMonitor.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                logger.Error(e, "SQL: ошибка сохоранения истории");
                MessageBox.Show("Ошибка при сохранении изменений в Sql db. \n\nОписание ошибки:\n\n" + e.ToString());
            }

            connection.Close();
            connection.Dispose();
        }

        public DataSet GetBlowoutReport(string startDateTime, string endDateTime)
        {
            string dropBlowoutTempTableQuery = "SELECT drop_blowout_table();";
            string fillBlowoutTempTableQuery = $"SELECT fill_blowout_table('{startDateTime}', '{endDateTime}');";
            string returnBlowoutReportQuery = "SELECT control_point, blowout_system, blowout_not_system FROM get_blowout_report();";

            string dropScTempTableQuery = "SELECT drop_special_control_table();";
            string fillScTempTableQuery = $"SELECT fill_special_control_table('{startDateTime}', '{endDateTime}');";
            string returnSpecialControlQuery = "SELECT sc_point, sc_unit, sc_value FROM get_special_control_report()";

            string connectionString = Environment.GetEnvironmentVariable(
                variable: Constants.EnvirovmentVariableName.ConnectionString,
                target: EnvironmentVariableTarget.User);

            NpgsqlConnection connection = new NpgsqlConnection(connectionString: connectionString);
            NpgsqlCommand dropTempTable = new NpgsqlCommand(dropBlowoutTempTableQuery, connection);
            NpgsqlCommand fillTempTable = new NpgsqlCommand(fillBlowoutTempTableQuery, connection);
            NpgsqlCommand dropScTempTable = new NpgsqlCommand(dropScTempTableQuery, connection);
            NpgsqlCommand fillScTempTable = new NpgsqlCommand(fillScTempTableQuery, connection);

            NpgsqlDataAdapter blowoutAdapter = new NpgsqlDataAdapter(selectCommandText: returnBlowoutReportQuery, selectConnection: connection);
            NpgsqlDataAdapter specialControlAdapter = new NpgsqlDataAdapter(selectCommandText: returnSpecialControlQuery, selectConnection: connection);

            connection.Open();
            dropTempTable.ExecuteNonQuery();
            fillTempTable.ExecuteNonQuery();
            dropScTempTable.ExecuteNonQuery();
            fillScTempTable.ExecuteNonQuery();

            DataSet data = new DataSet();
            DataTable blowoutTable = new DataTable()
            {
                TableName = "Blowout"
            };
            DataTable specialControlTable = new DataTable()
            {
                TableName = "SpecialControl"
            };

            blowoutAdapter.Fill(blowoutTable);
            specialControlAdapter.Fill(specialControlTable);

            data.Tables.AddRange(new DataTable[] { blowoutTable, specialControlTable });

            connection.Close();

            return data;
        }
    }
}
