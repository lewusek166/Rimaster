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

    public partial class Connection : Form
    {
        
        public Connection()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            Polaczenia po = new Polaczenia();
            po.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            TestPins test = new TestPins();
            test.ShowDialog();

        }
    }
}
