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
        public struct Ramka
        {
            public Byte  AdresUrzadzenia;
            public byte NrKomendy;
            public byte kontrolaDanych;
            public byte Dane;
        }
        public Ramka ramka;

        public StringBuilder DaneDoWys;
        public static bool _continue;
        

        public TestPins()
        {
            InitializeComponent();
            ramka = new Ramka();
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
        
        
        void WskazPin(byte i)
        {
            
                
                if (ramka.Dane == 0x01) { p1.BackColor = Color.Green; } else { p1.BackColor = Color.Coral; }
                if (ramka.Dane == 0x02) { p2.BackColor = Color.Green; } else { p2.BackColor = Color.Coral; }
                if (ramka.Dane == 0x03) { p3.BackColor = Color.Green; } else { p3.BackColor = Color.Coral; }
                if (ramka.Dane == 0x04) { p4.BackColor = Color.Green; } else { p4.BackColor = Color.Coral; }
                if (ramka.Dane == 0x05) { p5.BackColor = Color.Green; } else { p5.BackColor = Color.Coral; }
                if (ramka.Dane == 0x06) { p6.BackColor = Color.Green; } else { p6.BackColor = Color.Coral; }
                if (ramka.Dane == 0x07) { p7.BackColor = Color.Green; } else { p7.BackColor = Color.Coral; }
                if (ramka.Dane == 0x08) { p8.BackColor = Color.Green; } else { p8.BackColor = Color.Coral; }
                if (ramka.Dane == 0x09) { p9.BackColor = Color.Green; } else { p9.BackColor = Color.Coral; }
                if (ramka.Dane == 0x10) { p10.BackColor = Color.Green; } else { p10.BackColor = Color.Coral; }
                if (ramka.Dane == 0x11) { p11.BackColor = Color.Green; } else { p11.BackColor = Color.Coral; }
                if (ramka.Dane == 0x12) { p12.BackColor = Color.Green; } else { p12.BackColor = Color.Coral; }
                if (ramka.Dane == 0x13) { p13.BackColor = Color.Green; } else { p13.BackColor = Color.Coral; }
                if (ramka.Dane == 0x14) { p14.BackColor = Color.Green; } else { p14.BackColor = Color.Coral; }
                if (ramka.Dane == 0x15) { p15.BackColor = Color.Green; } else { p15.BackColor = Color.Coral; }
                if (ramka.Dane == 0x16) { p16.BackColor = Color.Green; } else { p16.BackColor = Color.Coral; }
                if (ramka.Dane == 0x17) { p17.BackColor = Color.Green; } else { p17.BackColor = Color.Coral; }
                if (ramka.Dane == 0x18) { p18.BackColor = Color.Green; } else { p18.BackColor = Color.Coral; }
                if (ramka.Dane == 0x19) { p19.BackColor = Color.Green; } else { p19.BackColor = Color.Coral; }
                if (ramka.Dane == 0x20) { p20.BackColor = Color.Green; } else { p20.BackColor = Color.Coral; }
                if (ramka.Dane == 0x21) { p21.BackColor = Color.Green; } else { p21.BackColor = Color.Coral; }
                if (ramka.Dane == 0x22) { p22.BackColor = Color.Green; } else { p22.BackColor = Color.Coral; }
                if (ramka.Dane == 0x23) { p23.BackColor = Color.Green; } else { p23.BackColor = Color.Coral; }
                if (ramka.Dane == 0x24) { p24.BackColor = Color.Green; } else { p24.BackColor = Color.Coral; }
                if (ramka.Dane == 0x25) { p25.BackColor = Color.Green; } else { p25.BackColor = Color.Coral; }
                if (ramka.Dane == 0x26) { p26.BackColor = Color.Green; } else { p26.BackColor = Color.Coral; }
                if (ramka.Dane == 0x27) { p27.BackColor = Color.Green; } else { p27.BackColor = Color.Coral; }
                if (ramka.Dane == 0x28) { p28.BackColor = Color.Green; } else { p28.BackColor = Color.Coral; }
                if (ramka.Dane == 0x29) { p29.BackColor = Color.Green; } else { p29.BackColor = Color.Coral; }
                if (ramka.Dane == 0x30) { p30.BackColor = Color.Green; } else { p30.BackColor = Color.Coral; }
                if (ramka.Dane == 0x31) { p31.BackColor = Color.Green; } else { p31.BackColor = Color.Coral; }
                if (ramka.Dane == 0x32) { p32.BackColor = Color.Green; } else { p32.BackColor = Color.Coral; }
                if (ramka.Dane == 0x33) { p33.BackColor = Color.Green; } else { p33.BackColor = Color.Coral; }
                if (ramka.Dane == 0x34) { p34.BackColor = Color.Green; } else { p34.BackColor = Color.Coral; }
                if (ramka.Dane == 0x35) { p35.BackColor = Color.Green; } else { p35.BackColor = Color.Coral; }
                if (ramka.Dane == 0x36) { p36.BackColor = Color.Green; } else { p36.BackColor = Color.Coral; }
                if (ramka.Dane == 0x37) { p37.BackColor = Color.Green; } else { p37.BackColor = Color.Coral; }
                if (ramka.Dane == 0x38) { p38.BackColor = Color.Green; } else { p38.BackColor = Color.Coral; }
                if (ramka.Dane == 0x39) { p39.BackColor = Color.Green; } else { p39.BackColor = Color.Coral; }
                if (ramka.Dane == 0x40) { p40.BackColor = Color.Green; } else { p40.BackColor = Color.Coral; }
                if (ramka.Dane == 0x41) { p41.BackColor = Color.Green; } else { p41.BackColor = Color.Coral; }
                if (ramka.Dane == 0x42) { p42.BackColor = Color.Green; } else { p42.BackColor = Color.Coral; }
                if (ramka.Dane == 0x43) { p43.BackColor = Color.Green; } else { p43.BackColor = Color.Coral; }
                if (ramka.Dane == 0x44) { p44.BackColor = Color.Green; } else { p44.BackColor = Color.Coral; }
                if (ramka.Dane == 0x45) { p45.BackColor = Color.Green; } else { p45.BackColor = Color.Coral; }
                if (ramka.Dane == 0x46) { p46.BackColor = Color.Green; } else { p46.BackColor = Color.Coral; }
                if (ramka.Dane == 0x47) { p47.BackColor = Color.Green; } else { p47.BackColor = Color.Coral; }
                if (ramka.Dane == 0x48) { p48.BackColor = Color.Green; } else { p48.BackColor = Color.Coral; }
                if (ramka.Dane == 0x49) { p49.BackColor = Color.Green; } else { p49.BackColor = Color.Coral; }
                if (ramka.Dane == 0x50) { p50.BackColor = Color.Green; } else { p50.BackColor = Color.Coral; }
           // }
        }
         void OdbiorDanych(Ramka ramka)
        {
            ///kontrola danych
            if(ramka.AdresUrzadzenia==0xf0)
            { 
                if (ramka.kontrolaDanych==0x68)
                 {
                label1.Text = "Connection is ok !!!";
                    button1.BackColor = Color.Green;
                    if (backgroundWorker1.IsBusy != true&& ramka.Dane>0)
                    {
                        // Start the asynchronous operation.
                        backgroundWorker1.RunWorkerAsync();
                    }



                }
                else
                {
                    button1.BackColor = Color.Red;
                }
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
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
                    DialogResult result = MessageBox.Show("Serial port name is not corectly", "ERROR", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        serial.Close();

                    }
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

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
          
            WskazPin(ramka.Dane);
        
        }

 
    }
}
