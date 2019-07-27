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
            public string AdresUrzadzenia;
            public string NrKomendy;
            public string kontrolaDanych;
            public string Dane;
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
            comboBox1.Text = "--Select--";
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

        private void Button1_Click(object sender, EventArgs e)
        {
            Ramka ramka= new Ramka();
            DaneDoWys = new StringBuilder();
            SerialPort serial = new SerialPort();
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            Thread readThread = new Thread(Read);
            string wybranyPort = comboBox1.SelectedItem.ToString();
            label1.Text = wybranyPort;
            UstawieniaSerial(serial, wybranyPort);
            _continue = true;
            /// ramka danych
            ///





            ramka.Dane = "0x00";
            ramka.AdresUrzadzenia = "0xff";//adres tma
            ramka.NrKomendy = "0x01";//Komenda test pin
            ramka.kontrolaDanych = "0x68";//poprawnosc danych
            _ = DaneDoWys.Append(ramka.AdresUrzadzenia);
            _ = DaneDoWys.Append(ramka.NrKomendy);
            _ = DaneDoWys.Append(ramka.kontrolaDanych);
            serial.Open();
            serial.WriteLine(DaneDoWys.ToString());//wysyłamy całą 
            readThread.Start();
            readThread.Join();
            serial.Close();

            void Read()
            {
                while (_continue)
                {
                    try
                    {
                       ramka.AdresUrzadzenia= serial.ReadLine();
                       ramka.NrKomendy = serial.ReadLine();
                       ramka.Dane = serial.ReadLine();
                       ramka.kontrolaDanych = serial.ReadLine();

                    }
                    catch (TimeoutException) { }
                }





            }

        }
        void UstawieniaSerial(SerialPort serial, String wybranyPort)
        {
            serial.PortName = wybranyPort;
            serial.ReadTimeout = 500;
            serial.WriteTimeout = 500;
            
        }
         void OdbiorDanych(Ramka ramka)
        {
            ///kontrola danych
            if (ramka.kontrolaDanych == "68")
            {
                
            }else
            {

                button1.BackColor = Color.Red;
                label1.AutoSize = true;
                label1.Text = "Connection Error " +
                    "Select the correct port COM";
            }
        }

    
    }
}
