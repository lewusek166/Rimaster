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
            public string[] Dane;
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
            TopMost = true;
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

            SerialPort serial = new SerialPort();
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            Thread readThread = new Thread(Read);
            String wybranyPort = comboBox1.SelectedItem.ToString();
            label1.Text = wybranyPort;
            UstawieniaSerial(serial, wybranyPort);
            _continue = true;
            /// ramka danych
            ///

            Ramka ramka= new Ramka();
          
            ramka.Dane = new string[51];//kazdy pin ma swój odpowiednik w tablicy 
            for(int i = 1; i < 51; i++)//ustawinie wszystkich komorek na 0 ,1 to aktywny pin 
            {
                ramka.Dane[i] = "0x00";
            }
            ramka.AdresUrzadzenia = "0xff";//adres tma
            ramka.NrKomendy = "0x01";//Komenda test pin
            ramka.kontrolaDanych = "0x2868";//poprawnosc danych
            DaneDoWys.Append(ramka.AdresUrzadzenia);
            DaneDoWys.Append(ramka.NrKomendy);
            DaneDoWys.Append(ramka.kontrolaDanych);
            serial.Open();
            serial.WriteLine(DaneDoWys.ToString());//
            readThread.Start();





            





            readThread.Join();
            serial.Close();

            void Read()
            {
                while (_continue)
                {
                    try
                    {
                        string message = serial.ReadLine();

                    }
                    catch (TimeoutException) { }
                }





            }

        }
        public static void UstawieniaSerial(SerialPort serial, String wybranyPort)
        {
            serial.PortName = wybranyPort;
            serial.ReadTimeout = 500;
            serial.WriteTimeout = 500;
            
        }
    }
}
