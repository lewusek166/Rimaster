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
        public Polaczenia()
        {
            InitializeComponent();
        }

        private void Polaczenia_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            
                
            

            for (int i = 1; i < 51; i++)
            {
                dataGridView1.Rows.Add(i, "");
            }

           

        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteClipboard();
        }

        /// <summary>
        /// This will be moved to the util class so it can service any paste into a DGV
        /// </summary>
        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0, iRow = dataGridView1.CurrentCell.RowIndex;
                int iCol = dataGridView1.CurrentCell.ColumnIndex;
                DataGridViewCell oCell;
                foreach (string line in lines)
                {
                    if (iRow < dataGridView1.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < this.dataGridView1.ColumnCount)
                            {
                                oCell = dataGridView1[iCol + i, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    if (oCell.Value.ToString() != sCells[i])
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[i], oCell.ValueType);
                                        //oCell.Style.BackColor = Color.Tomato;
                                    }
                                    else
                                        iFail++;//only traps a fail if the data has changed and you are pasting into a read only cell
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
                PasteClipboard();
            }
        }
    }
}
