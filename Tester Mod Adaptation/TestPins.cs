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
        struct Ramka
        {
            public Byte  AdresUrzadzenia;
            public byte NrKomendy;
            public byte kontrolaDanych;
            public byte Dane;
        };

        public StringBuilder DaneDoWys;
        public static bool _continue;

        public TestPins()
        {
            InitializeComponent();
           
        }

        private void TestPins_Load(object sender, EventArgs e)
        {

            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Exit Aplication ?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Connection connection = new Connection();
            connection.Visible = true;

        }

        void UstawieniaSerial(SerialPort serial, String wybranyPort)
        {
            serial.PortName = wybranyPort;
            serial.ReadTimeout = 5000;
            serial.WriteTimeout = 500;
            
        }
        void WskazPin(Ramka ramka)
        {
            if (ramka.Dane == 0x01) { p1.BackColor = Color.Green; } //else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x02) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x03) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x04) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x05) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x06) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x07) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x08) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x09) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x10) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x11) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x12) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x13) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x14) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x15) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x16) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x17) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x18) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x19) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x20) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x21) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x22) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x23) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x24) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x25) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x26) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x27) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x28) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x29) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x30) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x31) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x32) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x33) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x34) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x35) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x36) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x37) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x38) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x39) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x40) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x41) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x42) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x43) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x44) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x45) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x46) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x47) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x48) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x49) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
            if (ramka.Dane == 0x50) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
        }
         void OdbiorDanych(Ramka ramka)
        {
            ///kontrola danych
            if(ramka.AdresUrzadzenia==0xf0)
            { 
                if (ramka.kontrolaDanych==0x68)
                 {
                label1.Text = "Connection is ok !!!";
                    WskazPin(ramka);
                }
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Ramka ramka = new Ramka();
            DaneDoWys = new StringBuilder();
            SerialPort serial = new SerialPort();
            string portnazwa;
            while (serial.IsOpen == false)
            {
                try
                {
                    foreach (string s in SerialPort.GetPortNames())
                    {
                        portnazwa = s;
                        UstawieniaSerial(serial, s);
                    }
                    serial.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Serial port name is not corectly", "ERROR", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
          
            _continue = true;
            /// ramka danych

            ramka.AdresUrzadzenia = 0xff;//adres tma
            ramka.NrKomendy = 0x01;//Komenda test pin 0x02 izoltion test czyli do drugiegookn 0x03 resistor test 
            ramka.kontrolaDanych = 0x68;//poprawnosc danych
            _ = DaneDoWys.Append(ramka.AdresUrzadzenia);
            _ = DaneDoWys.Append(ramka.NrKomendy);
            _ = DaneDoWys.Append(ramka.kontrolaDanych);

            serial.WriteLine("1");
           
            Read();
            serial.Close();

            void Read()
            {
                
                while (_continue)
                {
                   
                    try
                    {

                        ramka.AdresUrzadzenia = (byte) serial.ReadByte();
                        ramka.Dane = (byte)serial.ReadByte();
                        ramka.kontrolaDanych = (byte)serial.ReadByte();
                        OdbiorDanych(ramka);

                    }
                    catch (TimeoutException) { }
                }

                



            }
        }
    }
}
