using System;
using System.Windows.Forms;
using System.IO.Ports;
using Armstrong.WinServer.Classes;

namespace Armstrong.WinServer
{
    public partial class MainSettings : Form
    {
        public string comPort, connectionString, newShift, history, monitor, channel;
        public int timeAsk, baudRate;
        private readonly SQL sql = new SQL();

        public Form OwnerForm { get; set; }

        public MainSettings()
        {
            InitializeComponent();
        }
        private void MainSettings_Load(object sender, EventArgs e)
        {
            OwnerForm = this.Owner as MainForm;

            string[] myPorts;
            PortName_comboBox.Items.Clear();
            myPorts = SerialPort.GetPortNames();
            PortName_comboBox.Items.AddRange(myPorts);
            
            int timeToAsk = (int)SettingsVariable.GetValue<float>(Constants.SettingName.TimeToAsk);
            string timeNewShift = SettingsVariable.GetValue<string>(Constants.SettingName.TimeNewShift);
            string comPortName = SettingsVariable.GetValue<string>(Constants.SettingName.ComPortName);
            string baudRate = SettingsVariable.GetValue<int>(Constants.SettingName.ComPortBaudRate).ToString();
            string mainFormTitle = SettingsVariable.GetValue<string>(Constants.SettingName.MainFormTitle);

            if (!(timeToAsk < 2))
                TimeAsk_comboBox.SelectedIndex = timeToAsk - 2;
            else
                TimeAsk_comboBox.SelectedIndex = 0;

            NewShift_comboBox.SelectedIndex = NewShift_comboBox.Items.IndexOf(timeNewShift);

            PortName_comboBox.Text = comPortName;
            BaudRate_comboBox.SelectedItem = baudRate;
        }

        private void PortName_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comPortName = PortName_comboBox.Text;
            SettingsVariable.SetValue(name: Constants.SettingName.ComPortName, value: comPortName);
        }
        private void BaudRate_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comPortBaudRate = Convert.ToInt32(BaudRate_comboBox.Text);
            SettingsVariable.SetValue(name: Constants.SettingName.ComPortBaudRate, value: comPortBaudRate);
        }
        private void TimeAsk_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float timeToAsk = Convert.ToSingle(TimeAsk_comboBox.Text.Replace(".", ","));
            SettingsVariable.SetValue(name: Constants.SettingName.TimeToAsk, value: timeToAsk);
        }
        private void NewShift_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string timeNewShift = NewShift_comboBox.Text;
            SettingsVariable.SetValue(name: Constants.SettingName.TimeNewShift, value: timeNewShift);
        }

        private void TestCom_button_Click(object sender, EventArgs e)
        {
            comPort = PortName_comboBox.Text;
            baudRate = Convert.ToInt32(BaudRate_comboBox.Text);
            SerialPort serialPort = new SerialPort(comPort)
            {
                BaudRate = baudRate,
                StopBits = StopBits.One
            };

            try
            {
                serialPort.Open();
                var result = MessageBox.Show("???????????????????? ?????????????????????? ??????????????.", "???????????????? ????????????????????", MessageBoxButtons.OK);
            }
            catch
            {
                var result = MessageBox.Show("????????????. ???????????????????? ???? ??????????????????????.", "???????????????? ????????????????????", MessageBoxButtons.OK);
            }
            finally
            {
                serialPort.Close();
                serialPort.Dispose();
            }
        }
    }
}
