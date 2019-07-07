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
            ///DataTable table = new DataTable();
          
            
            for(int i = 1; i < 51; i++)
            {
                dataGridView1.Rows.Add(i, "");
            }

           

        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
