using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester_Mod_Adaptation
{
    public partial class TestPins : Form
    {
        SerialPort serial;
        bool _continue;
        string message;


        public TestPins()
        {
            InitializeComponent();

        }

        private void TestPins_Load(object sender, EventArgs e)
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
        void kolor()
        {
            if(message.Equals("1\r")){ p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (message.Equals("2\r")) { p2.BackColor = Color.Green; } else { p2.BackColor = Color.Coral; }
            if (message.Equals("3\r")) { p3.BackColor = Color.Green; } else { p3.BackColor = Color.Coral; }
            if (message.Equals("4\r")) { p4.BackColor = Color.Green; } else { p4.BackColor = Color.Coral; }
            if (message.Equals("5\r")) { p5.BackColor = Color.Green; } else { p5.BackColor = Color.Coral; }
            if (message.Equals("6\r")) { p6.BackColor = Color.Green; } else { p6.BackColor = Color.Coral; }
            if (message.Equals("7\r")) { p7.BackColor = Color.Green; } else { p7.BackColor = Color.Coral; }
            if (message.Equals("8\r")) { p8.BackColor = Color.Green; } else { p8.BackColor = Color.Coral; }
            if (message.Equals("9\r")) { p9.BackColor = Color.Green; } else { p9.BackColor = Color.Coral; }
            if (message.Equals("10\r")) { p10.BackColor = Color.Green; } else { p10.BackColor = Color.Coral; }
            if (message.Equals("11\r")) { p11.BackColor = Color.Green; } else { p11.BackColor = Color.Coral; }
            if (message.Equals("12\r")) { p12.BackColor = Color.Green; } else { p12.BackColor = Color.Coral; }
            if (message.Equals("13\r")) { p13.BackColor = Color.Green; } else { p13.BackColor = Color.Coral; }
            if (message.Equals("14\r")) { p14.BackColor = Color.Green; } else { p14.BackColor = Color.Coral; }
            if (message.Equals("15\r")) { p15.BackColor = Color.Green; } else { p15.BackColor = Color.Coral; }
            if (message.Equals("16\r")) { p16.BackColor = Color.Green; } else { p16.BackColor = Color.Coral; }
            if (message.Equals("17\r")) { p17.BackColor = Color.Green; } else { p17.BackColor = Color.Coral; }
            if (message.Equals("18\r")) { p18.BackColor = Color.Green; } else { p18.BackColor = Color.Coral; }
            if (message.Equals("19\r")) { p19.BackColor = Color.Green; } else { p19.BackColor = Color.Coral; }
            if (message.Equals("20\r")) { p20.BackColor = Color.Green; } else { p20.BackColor = Color.Coral; }
            if (message.Equals("21\r")) { p21.BackColor = Color.Green; } else { p21.BackColor = Color.Coral; }
            if (message.Equals("22\r")) { p22.BackColor = Color.Green; } else { p22.BackColor = Color.Coral; }
            if (message.Equals("23\r")) { p23.BackColor = Color.Green; } else { p23.BackColor = Color.Coral; }
            if (message.Equals("24\r")) { p24.BackColor = Color.Green; } else { p24.BackColor = Color.Coral; }
            if (message.Equals("25\r")) { p25.BackColor = Color.Green; } else { p25.BackColor = Color.Coral; }
            if (message.Equals("26\r")) { p26.BackColor = Color.Green; } else { p26.BackColor = Color.Coral; }
            if (message.Equals("27\r")) { p27.BackColor = Color.Green; } else { p27.BackColor = Color.Coral; }
            if (message.Equals("28\r")) { p28.BackColor = Color.Green; } else { p28.BackColor = Color.Coral; }
            if (message.Equals("29\r")) { p29.BackColor = Color.Green; } else { p29.BackColor = Color.Coral; }
            if (message.Equals("30\r")) { p30.BackColor = Color.Green; } else { p30.BackColor = Color.Coral; }
            if (message.Equals("31\r")) { p31.BackColor = Color.Green; } else { p31.BackColor = Color.Coral; }
            if (message.Equals("32\r")) { p32.BackColor = Color.Green; } else { p32.BackColor = Color.Coral; }
            if (message.Equals("33\r")) { p33.BackColor = Color.Green; } else { p33.BackColor = Color.Coral; }
            if (message.Equals("34\r")) { p34.BackColor = Color.Green; } else { p34.BackColor = Color.Coral; }
            if (message.Equals("35\r")) { p35.BackColor = Color.Green; } else { p35.BackColor = Color.Coral; }
            if (message.Equals("36\r")) { p36.BackColor = Color.Green; } else { p36.BackColor = Color.Coral; }
            if (message.Equals("37\r")) { p37.BackColor = Color.Green; } else { p37.BackColor = Color.Coral; }
            if (message.Equals("38\r")) { p38.BackColor = Color.Green; } else { p38.BackColor = Color.Coral; }
            if (message.Equals("39\r")) { p39.BackColor = Color.Green; } else { p39.BackColor = Color.Coral; }
            if (message.Equals("40\r")) { p40.BackColor = Color.Green; } else { p40.BackColor = Color.Coral; }
            if (message.Equals("41\r")) { p41.BackColor = Color.Green; } else { p41.BackColor = Color.Coral; }
            if (message.Equals("42\r")) { p42.BackColor = Color.Green; } else { p42.BackColor = Color.Coral; }
            if (message.Equals("43\r")) { p43.BackColor = Color.Green; } else { p43.BackColor = Color.Coral; }
            if (message.Equals("44\r")) { p44.BackColor = Color.Green; } else { p44.BackColor = Color.Coral; }
            if (message.Equals("45\r")) { p45.BackColor = Color.Green; } else { p45.BackColor = Color.Coral; }
            if (message.Equals("46\r")) { p46.BackColor = Color.Green; } else { p46.BackColor = Color.Coral; }
            if (message.Equals("47\r")) { p47.BackColor = Color.Green; } else { p47.BackColor = Color.Coral; }
            if (message.Equals("48\r")) { p48.BackColor = Color.Green; } else { p48.BackColor = Color.Coral; }
            if (message.Equals("49\r")) { p49.BackColor = Color.Green; } else { p49.BackColor = Color.Coral; }
            if (message.Equals("50\r")) { p50.BackColor = Color.Green; } else { p50.BackColor = Color.Coral; }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            _continue = true;
            serial = new SerialPort();
            while (serial.IsOpen == false)
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
            
            serial.Write("1");
            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            while (_continue)
            {
                try
                {
                    message = serial.ReadLine();
                    kolor();
                }
                catch(TimeoutException) { }
               
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Exit Aplication ?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Connection connection = new Connection();
            connection.Visible = true;
            _continue = false;
            backgroundWorker1.CancelAsync();
        }
    }
}
