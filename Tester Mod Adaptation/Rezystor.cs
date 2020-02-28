using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester_Mod_Adaptation
{
    public partial class Rezystor : Form
    {
        SerialPort serial;
        bool stop;
        string message;
        private delegate void SafeCallDelegate(string text);
        public Rezystor()
        {
            InitializeComponent();
            stop = false;
        }
        void wynik(string m)
        {
            char[] charsToTrim = { '\r', ' ', '\'' };
            m = m.Trim(charsToTrim);
            float w;
            NumberFormatInfo setPrecision = new NumberFormatInfo();
            setPrecision.NumberDecimalDigits = 2;
            try
            {
                 w = float.Parse(m, CultureInfo.InvariantCulture);
            }
            catch
            {
                w = 0;
            }
            
            if (w > 999)
            {
                w /= 1000;
                WriteTextSafe(w.ToString("N", setPrecision) +"  K OHM");
            }
            else
            {
                WriteTextSafe(w.ToString("N", setPrecision) + "  OHM");
            }
        }
        private void WriteTextSafe(string text)
        {
            if (label2.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                label2.Invoke(d, new object[] { text });
            }
            else
            {
                label2.Text = text;
            }
        }
        private void Rezystor_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }
        void UstawieniaSerial(SerialPort serial, String wybranyPort)
        {
            serial.PortName = wybranyPort;
            serial.ReadTimeout = 500;
            serial.WriteTimeout = 500;

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            serial = new SerialPort();
            if (serial.IsOpen == false)
            {
                try
                {
                    foreach (string s in SerialPort.GetPortNames())
                    {
                        UstawieniaSerial(serial, s);
                        label1.Text = s;
                    }
                    serial.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Serial port name isn't correctly", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }

            serial.Write("3");
             backgroundWorker1.RunWorkerAsync();
            
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (stop == false)
            {
                try
                {
                    serial.DiscardInBuffer();
                    message = serial.ReadLine();
                    wynik(message);
                }
                catch (TimeoutException) { }

            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            stop = true;
            DialogResult result;
            result = MessageBox.Show("Exit Aplication ?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                serial.Close();
                Application.Exit();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            stop = true;
            this.Close();
            Connection connection = new Connection();
            connection.Visible = true;
            backgroundWorker1.CancelAsync();
        }

        

    }
}
