using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tester_Mod_Adaptation
{
    public partial class Polaczenia : Form
    {
        public String[,] PolTMT;
        public String[,] NazwyTMT;
        public int[,] WynikPol;
        SerialPort serial;
        bool _continue;
        string message;
        int IsplitA,IsplitB;

        public Polaczenia()
        {
            InitializeComponent();

            PolTMT = new string[50,2];
            NazwyTMT = new string[50, 2];
            WynikPol = new int[50,2];
            for(int i = 0; i < 50; i++)//czyszczenie tablic 
            {

                for(int k = 0; k < 2; k++)
                {
                    PolTMT[i,k] = "";
                    NazwyTMT[i, k] = "";
                    WynikPol[i, k] = 2;
                }
                
            }//czyszczenie teablic

        }

        private void Polaczenia_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            for (int i = 1; i < 51; i++)
            {
                dataGridView1.Rows.Add(i, "");
                dataGridView2.Rows.Add("", "");
            }
        }
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                cell.Value = "";
            }
            e.Handled = true;
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboard(dataGridView1);
            }
        }

        private void DataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
                {
                    cell.Value = "";
                }
            e.Handled = true;
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboard(dataGridView2);
            }
        }

        private void PasteClipboard(DataGridView grid)
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0, iRow = grid.CurrentCell.RowIndex;
                int iCol = grid.CurrentCell.ColumnIndex;
                DataGridViewCell oCell;
                foreach (string line in lines)
                {
                    if (iRow < grid.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < grid.ColumnCount)
                            {
                                oCell = grid[iCol + i, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    if (oCell.Value.ToString() != sCells[i])
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[i], oCell.ValueType);
                                        //oCell.Style.BackColor = Color.Tomato;
                                    }
                                    else
                                        iFail++;
                                }
                            }
                            else
                            { break; }
                        }
                        iRow++;
                    }
                    else
                    { break; }
                    if (iFail > 0)
                        MessageBox.Show(string.Format("{0} updates failed due to read only column setting", iFail));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            DialogResult result;
            result = MessageBox.Show("Exit Aplication ?", "", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
            Application.Exit();
            }  
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Connection connection = new Connection();
            connection.Visible = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            char[] charsToTrim = { '\r', ' ', '\'' };//usuwanie znakow nie potrzebnych w nazwach 
            String result;
            for (int i = 0; i < 50; i++)
             {
                 result= (string)dataGridView1.Rows[i].Cells[1].Value;
                dataGridView1.Rows[i].Cells[1].Value= result.Trim(charsToTrim);
             }//pobranie danych do stringa z data grid

            for(int i = 0; i < 50; i++)
            {
                for(int k = i+1; k < 50; k++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() == dataGridView1.Rows[k].Cells[1].Value.ToString() && (string)dataGridView1.Rows[i].Cells[1].Value != "")
                    {
                        kontrol = false;
                        dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;
                        dataGridView1.Rows[k].Cells[1].Style.BackColor = Color.Red;
                    }

                }

               
                button2.Enabled = true;

            }  //sprawdzenie czy nie ma takich samych nazw
            if (kontrol == false)
            {   
                MessageBox.Show("Name Pins isn't correctly!!! ", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else
            {
                for(int i = 0; i < 50; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.Equals(""))
                    { }
                    else
                    {
                        dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.GreenYellow;
                    }
                    
                   
                }

            }
        }

        void UstawieniaSerial(SerialPort serial, String wybranyPort)
        {
            serial.PortName = wybranyPort;
            serial.ReadTimeout = 500;
            serial.WriteTimeout = 500;

        }
        private void Button6_Click(object sender, EventArgs e)
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
                        label1.BackColor = Color.LawnGreen;
                    }
                    serial.Open();
                }
                catch (Exception)
                {
                    DialogResult dialog= MessageBox.Show("Serial port name isn't correctly or TMT does't connected", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (dialog == DialogResult.Cancel)
                    {
                       
                        backgroundWorker1.CancelAsync();////////////////////////////////////do poprawy  
                        this.Visible = false;
                        Application.Exit();
                        this.Close();
                        serial.Close();
                        
                    }
                }
            }

            serial.Write("2");
            backgroundWorker1.RunWorkerAsync();
           // serial.Close();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            string result;
            char charsToTrim = ' ';
            bool istniejeA = false;
            bool istniejeB = false;
            bool bledy = false;
            bool kontrola = true;
            ///czyszczenie białych znaków
            for (int i = 0; i < 50; i++)
            {
                for (int k = 0; k < 50; k++)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.Equals(""))
                        { }
                        else
                        {
                            result = (string)dataGridView1.Rows[i].Cells[1].Value;
                            dataGridView1.Rows[i].Cells[1].Value = result.Trim(charsToTrim);
                            result = (string)dataGridView2.Rows[k].Cells[z].Value;
                            dataGridView2.Rows[k].Cells[z].Value = result.Trim(charsToTrim);

                        }
                    }

                }
            }
            ///sprawdzenie czy w danym polaczeniu nie ma tych samych pinow 
            for (int i = 0; i < 50; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value.ToString() == dataGridView2.Rows[i].Cells[1].Value.ToString() && dataGridView2.Rows[i].Cells[0].Value.ToString() != "")
                {

                    dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    dataGridView2.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    bledy = true;

                }
            }
            /// sprawdzenie czy polaczenia są zawarte w liscie pinow 
            if (bledy == false)
            {
                for (int i = 0; i < 50; i++)
                {
                    istniejeA = false;
                    istniejeB = false;
                    for (int z = 0; z < 50; z++)
                    {
                        if (dataGridView2.Rows[i].Cells[0].Value.ToString() != "" && dataGridView1.Rows[z].Cells[1].Value.ToString() != "")//ominięcie pustych miejsc
                        {
                            if (dataGridView2.Rows[i].Cells[0].Value.ToString() == dataGridView1.Rows[z].Cells[1].Value.ToString())
                            {
                                istniejeA = true;
                                dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.GreenYellow;
                            }
                        }
                        if (dataGridView2.Rows[i].Cells[1].Value.ToString() != "" && dataGridView1.Rows[z].Cells[1].Value.ToString() != "")//ominięcie pustych miejsc
                        {
                            if (dataGridView2.Rows[i].Cells[1].Value.ToString() == dataGridView1.Rows[z].Cells[1].Value.ToString())
                            {
                                istniejeB = true;
                                dataGridView2.Rows[i].Cells[1].Style.BackColor = Color.GreenYellow;
                            }
                        }

                    }
                    if (istniejeA == false && dataGridView2.Rows[i].Cells[0].Value.ToString() != "")
                    {
                        kontrola = false;
                        dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    }
                    if (istniejeB == false && dataGridView2.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        kontrola = false;
                        dataGridView2.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    }
                }
                if (kontrola == false)
                {
                    MessageBox.Show("Wire isn't correctly!!! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                }else
                {
                button5.Enabled = true;
                button6.Enabled = true;
                }

            }
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ///Przetwozenie nazw pinów 
           for(int i = 0; i < 50; i++)
            {
              for(int k = 0; k < 2; k++)
                {
                    if (PolTMT[i, k] != "")
                    { 
                    int Iter = Convert.ToInt16(PolTMT[i, k])- 1;
                    NazwyTMT[i,k] = dataGridView1.Rows[Iter].Cells[1].Value.ToString(); 
                    }
                }
            }
            ///sprawdzenie połaćzeń 
            bool pass = false;
           
            for (int i = 0; i < 50; i++)
            {
                pass = false;
                
                for (int k = 0; k < 50; k++)
                {
                    if ((dataGridView2.Rows[i].Cells[0].Value.ToString() == NazwyTMT[k, 0] && dataGridView2.Rows[i].Cells[1].Value.ToString() == NazwyTMT[k, 1] && dataGridView2.Rows[i].Cells[0].Value.ToString() != "" && NazwyTMT[k, 0] != "") ||
                    (dataGridView2.Rows[i].Cells[0].Value.ToString() == NazwyTMT[k, 1] && dataGridView2.Rows[i].Cells[1].Value.ToString() == NazwyTMT[k, 0] && dataGridView2.Rows[i].Cells[0].Value.ToString() != "" && NazwyTMT[k, 0] != ""))
                    {
                        WynikPol[i, 0] = 1;
                        pass = true;
                    }
                }
                 if (pass == false&& dataGridView2.Rows[i].Cells[0].Value.ToString() != "")
                    {
                    WynikPol[i,0] = 0;
                    }
                   
            }
            for (int i = 0; i < 50; i++)
            {
                pass = false;

                for (int k = 0; k < 50; k++)
                {
                    if ((NazwyTMT[i, 0] == dataGridView2.Rows[k].Cells[0].Value.ToString() && NazwyTMT[i, 1] == dataGridView2.Rows[k].Cells[1].Value.ToString() && dataGridView2.Rows[k].Cells[0].Value.ToString() != "" && NazwyTMT[i, 0] != "") ||
                    (NazwyTMT[i, 1] == dataGridView2.Rows[k].Cells[0].Value.ToString() && NazwyTMT[i, 0] == dataGridView2.Rows[k].Cells[1].Value.ToString() && dataGridView2.Rows[k].Cells[0].Value.ToString() != "" && NazwyTMT[i, 0] != ""))
                    {
                        WynikPol[i, 1] = 1;
                        pass = true;
                    }
                }
                if (pass == false && NazwyTMT[i, 0] != "")
                {
                    WynikPol[i, 1] = 0;
                }
            }
            ///wynik
            pass = true;
            for (int i = 0; i < 50; i++)
            {
                if(WynikPol[i,0]==0)
                {
                    label4.Text += "OPEN  " + dataGridView2.Rows[i].Cells[0].Value.ToString() + " --- " + dataGridView2.Rows[i].Cells[1].Value.ToString() + "\n";
                    pass = false;
                }
                if (WynikPol[i, 1] == 0)
                {
                    label4.Text += "SHORT  " + NazwyTMT[i, 0] + " --- " + NazwyTMT[i, 1] + "\n";
                    pass = false;
                }
            }
            if (pass)
            {
                label4.Font = new System.Drawing.Font("Arial", 70.1F, System.Drawing.FontStyle.Bold);
                label4.ForeColor = Color.GreenYellow;
                label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label4.Text = "PASS";
            }


        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            IsplitA = 0;
          
            while (_continue)
            {
                try
                {
                    message = serial.ReadLine();
                    IsplitB = 0;
                    char[] charsToTrim = { '\r', ' ', '\'' };//usuwanie znakow niepotrzebnych w nazwach 
                    String result;
                    result = message;
                    message = result.Trim(charsToTrim);
                    string[] split = message.Split('-'); 
                    foreach (var item in split)
                    {
                        result = item;
                        result = result.Trim(charsToTrim);
                        PolTMT[IsplitA , IsplitB] = result;
                        IsplitB++;
                    }
                    IsplitA++;
                    if (IsplitA == 50)
                    {
                        IsplitA = 0;
                    }
                }
                catch (TimeoutException) { }
                
            }
        }
    }
}


