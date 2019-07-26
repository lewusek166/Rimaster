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
    public partial class TestPins : Form
    {
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

      
    }
}
