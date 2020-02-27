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

        public Rezystor()
        {
            InitializeComponent();
            stop = false;
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
                    message = serial.ReadLine();
                   //wynik(message);
                    label2.Text = "kjgjhgjh";

                }
                catch (TimeoutException) { }
            }
        }
         void wynik (string m)
        {
           // char[] charsToTrim = { '\r', ' ', '\'' };
            //m = m.Trim(charsToTrim);
            label2.Text = "kjgjhgjh";
            /*float wynik = float.Parse(m, CultureInfo.InvariantCulture);
            if (wynik > 999)
            {
                wynik /= 1000;
                label2.Text = String.Format("{0:F2}", wynik+"K");
            }
            else
            {
                label1.Text = m;
                label2.Text = "kupa";
           */ 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            serial.Write("0");
            serial.Close();
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
            serial.Write("0");
            serial.Close();
            backgroundWorker1.CancelAsync();
        }

        
    }
}
