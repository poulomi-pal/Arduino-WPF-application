using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;



namespace WpfApplication3_ardim
{
    internal class FormClosingEventArgs
    {
      
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum ArduinoStatus
        {
            Connected,
            Connecting,
            Disconnected
        }
        //private SerialPort _arduinoPort;
        SerialPort _arduinoPort = new SerialPort("COM3", 9600);
        private ArduinoStatus _status;
        //private object cbAvailablePorts;
        public MainWindow()
        {
            InitializeComponent();
            //SerialPort _arduinoPort = new SerialPort("COM3", 9600);
            _status = ArduinoStatus.Disconnected;

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            _status = ArduinoStatus.Connecting;
            UpdateFormByStatus();
           // _arduinoPort = new SerialPort(cbAvailablePorts.SelectedItem.ToString());
            try
            {
                _arduinoPort.Open();
                _status = ArduinoStatus.Connected;
                UpdateFormByStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lbStatus.Text = "Status: Error";
            }

        }

        private void tbBrightness_ValueChanged(object sender, EventArgs e)
        {
            if (_status == ArduinoStatus.Connected)
            {
                byte[] buffer = new byte[1];
                buffer[0] = (byte)tbBrightness.Value;
                _arduinoPort.Write(buffer, 0, 1);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_status == ArduinoStatus.Connected)
            {
                _arduinoPort.Close();
            }
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _arduinoPort.Close();
                _status = ArduinoStatus.Disconnected;
                UpdateFormByStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lbStatus.Text = "Status: Error";
            }
        }

        private void UpdateFormByStatus()
        {
            switch (_status)
            {
                case ArduinoStatus.Connected:
                    lbStatus.Text = "Status: Successfully connected";
                    btConnect.IsEnabled = false;
                    btDisconnect.IsEnabled = true;
                    tbBrightness.IsEnabled = true;
                    break;

                case ArduinoStatus.Connecting:
                    lbStatus.Text = "Status: Connecting";
                    break;

                case ArduinoStatus.Disconnected:
                    lbStatus.Text = "Status: Disconnected";
                    btConnect.IsEnabled = true;
                    btDisconnect.IsEnabled = false;
                    tbBrightness.IsEnabled = false;
                    break;
            }
        }
    }
}
