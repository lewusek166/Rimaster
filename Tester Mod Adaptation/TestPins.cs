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
            public String AdresUrzadzenia;
            public String NrKomendy;
            public String kontrolaDanych;
            public String Dane;
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
         void OdbiorDanych(Ramka ramka)
        {
            ///kontrola danych
            if(ramka.AdresUrzadzenia=="0xf0\r")
            { 
                if (ramka.kontrolaDanych=="0x68\r")
                 {
                label1.Text = "Connection is ok !!!";
                    if (ramka.Dane == "0x01/r")
                    {
                        p1.BackColor = Color.Green;
                    }
                  }
            }
            else
            {
                button1.BackColor = Color.Red;
                label1.Text = "Error DATA";
                _continue = false;
                
                
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Ramka ramka = new Ramka();
            DaneDoWys = new StringBuilder();
            SerialPort serial = new SerialPort();
            StringComparer StringComparer = StringComparer.OrdinalIgnoreCase;
           
            string portnazwa;
            

            foreach (string s in SerialPort.GetPortNames())
            {
                portnazwa = s;

                UstawieniaSerial(serial, s);
            }
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
                catch (Exception) { }
            }
          
            _continue = true;
            /// ramka danych
            ramka.Dane = "0x00";
            ramka.AdresUrzadzenia = "0xff";//adres tma
            ramka.NrKomendy = "0x01";//Komenda test pin
            ramka.kontrolaDanych = "0x68";//poprawnosc danych
            _ = DaneDoWys.Append(ramka.AdresUrzadzenia);
            _ = DaneDoWys.Append(ramka.NrKomendy);
            _ = DaneDoWys.Append(ramka.kontrolaDanych);


            serial.WriteLine("1");
            //String d = serial.ReadLine();
            Read();
            serial.Close();

            void Read()
            {
                
                while (_continue)
                {
                    //if (serial.Read.Equals(0) { }
                    try
                    {
                        
                        ramka.AdresUrzadzenia = serial.ReadLine();
                        ramka.Dane = serial.ReadLine();
                        ramka.kontrolaDanych = serial.ReadLine();
                        OdbiorDanych(ramka);
                        
                       

                    }
                    catch (TimeoutException) { }
                }

                



            }
        }
    }
}
