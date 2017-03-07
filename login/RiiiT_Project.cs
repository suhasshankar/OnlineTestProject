using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class RiiiT_Project : Form
    {
        public RiiiT_Project()
        {
            InitializeComponent();
        }

        private void RiiiT_Project_Load(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginform login = new loginform();
            login.Show();
            login.MdiParent = this;           
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
