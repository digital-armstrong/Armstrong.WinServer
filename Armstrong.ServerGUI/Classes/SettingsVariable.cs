using System;
using NLog;
using Armstrong.WinServer.Properties;

namespace Armstrong.WinServer.Classes
{
    static class SettingsVariable
    {
        static private Logger logger = LogManager.GetCurrentClassLogger();
        public static void SetValue(string name, object value)
        {
            Settings.Default[name] = value;
            Settings.Default.Save();
        }

        public static void SetValue(string variable, string value) => Environment.SetEnvironmentVariable(variable, value);

        public static T GetValue<T>(string name) => (T)Settings.Default[name];

        public static string GetValue(string variable)
        {
            try
            {
                return EnvirovmentHelper.GetEnvirovmentVariable(variable);
            }
            catch (EnvirovmentVariableException ex)
            {
                logger.Error(ex);

                return null;
            }
        }
    }
}
