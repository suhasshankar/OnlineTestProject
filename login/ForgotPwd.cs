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
    public partial class ForgotPwd : Form
    {
        public ForgotPwd()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginform login = new loginform();
            login.MdiParent = this.MdiParent;
            login.Show();
            this.Hide();
        }
    }
}
