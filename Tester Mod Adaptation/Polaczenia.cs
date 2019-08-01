using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tester_Mod_Adaptation
{
    public partial class Polaczenia : Form
    {
        String[] NPin;
        public Polaczenia()
        {
            InitializeComponent();
            NPin = new string[50];
        }

        private void Polaczenia_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            for (int i = 1; i < 51; i++)
            {
                dataGridView1.Rows.Add(i, "");
                dataGridView2.Rows.Add("", "");
            }
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            
           
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
                NPin[i] = result.Trim(charsToTrim);
             }//pobranie danych do stringa z data grid

            for(int i = 0; i < 50; i++)
            {
                for(int k = i+1; k < 50; k++)
                {
                    if (NPin[i] == NPin[k] && NPin[i] != "")
                    {
                        kontrol = false;
                        dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;
                        dataGridView1.Rows[k].Cells[1].Style.BackColor = Color.Red;
                    }

                } 
                    

                
            }  //sprawdzenie czy nie ma takich samych nazw
            if (kontrol == false)
            {
                MessageBox.Show("Name Pins isn't correctly ", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else
            {
                for(int i = 0; i < 50; i++)
                {
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.GreenYellow;
                }

            }
        }
    }

}
