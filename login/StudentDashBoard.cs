using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login
{
    public partial class StudentDashBoard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=Suhas;Initial Catalog=project;User ID=sa;Password=admin");
        public StudentDashBoard()
        {
            InitializeComponent();
        }

        private void StudentDashBoard_Load(object sender, EventArgs e)
        {           
            subjectList(comboBox1);
            getuserName();
            showMarksList();
            checkPwdRequired();
        }

        public void showMarksList()
        {
            SqlDataAdapter da = new SqlDataAdapter("select subjectName[Subject Name],marks[Marks],dateoftaken[Date Of Taken] from marksList where userId=" +uId + "", con); ;
            DataTable dt = new DataTable();
            da.Fill(dt);
            label10.Text = dt.Rows.Count.ToString();
            dataGridView1.DataSource = dt;
        }

        public void subjectList(ComboBox combo)
        {
            SqlDataAdapter da = new SqlDataAdapter("select subjectName from subjects", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //insert -----select subject------- at first row first col
            DataRow r = dt.NewRow();
            r[0] = "-----Select Subject------";
            dt.Rows.InsertAt(r, 0);

            combo.DataSource = dt;
            combo.DisplayMember = "subjectName";
            combo.ValueMember = "subjectName";
        }

        public int uId = 0;
        public void getuserName()
        {
            //To get the user name to the staff DashBoard for further use and store it in label
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select userName,userId from userDetails where emailId='" + label7.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                welcomeUserName.Text = Convert.ToString(dr[0]);
                uId = (int)dr[1];
            }
            dr.Close();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginform login = new loginform();
            login.MdiParent = this.MdiParent;
            login.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkPwdRequired();
        }

        public void checkPwdRequired()
        {
            if (chkpwd.Checked == false)
            {
                txtoldpwd.ReadOnly = true;
                txtnewpwd.ReadOnly = true;
                txtconfirmnewpwd.ReadOnly = true;
            }
            else
            {
                txtoldpwd.ReadOnly = false;
                txtnewpwd.ReadOnly = false;
                txtconfirmnewpwd.ReadOnly = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //------------------------------------------------------------------
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBox1, "Please Select the Subject to Take Test.");
                return;
            }
            else
                errorProvider1.Clear();

            DialogResult result = MessageBox.Show("Do you want to continue to take up the test?", "Test Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                testWindow test = new testWindow();
                test.MdiParent = this.MdiParent;
                test.label15.Text = uId.ToString();
                test.label29.Text = label7.Text;
                test.label31.Text = comboBox1.SelectedValue.ToString();
                test.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //-----------------validation---------------------------
            if (txtname.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtname, "Please Enter the Name.");
                return;
            }
            else
                errorProvider1.Clear();
            if (chkpwd.Checked == true)
            {
                if (txtoldpwd.Text.Trim().Length < 1)
                {
                    errorProvider1.SetError(txtoldpwd, "Please Enter the Name.");
                    return;
                }
                else
                    errorProvider1.Clear();

                if (txtnewpwd.Text.Trim().Length < 1)
                {
                    errorProvider1.SetError(txtnewpwd, "Please Enter the Name.");
                    return;
                }
                else
                    errorProvider1.Clear();

                if (txtconfirmnewpwd.Text.Trim().Length < 1)
                {
                    errorProvider1.SetError(txtconfirmnewpwd, "Please Enter the Name.");
                    return;
                }
                else
                    errorProvider1.Clear();
            }
            if (txtaddress.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtaddress, "Please Enter the Name.");
                return;
            }
            else
                errorProvider1.Clear();

            if (txtmobno.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtmobno, "Please Enter the Name.");
                return;
            }
            else
                errorProvider1.Clear();
            //----------------------------------------------------------------------------------

            SqlConnection con = new SqlConnection("Data Source=Suhas;Initial Catalog=project;User ID=sa;Password=admin");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "registerOperation";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramuserId = new SqlParameter("@staffId", SqlDbType.Int);
            SqlParameter paramusername = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            SqlParameter paramemailid = new SqlParameter("@emailId", SqlDbType.VarChar, 50);
            SqlParameter parampwd = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
            SqlParameter parammobno = new SqlParameter("@mobileNo", SqlDbType.BigInt);
            SqlParameter paramaddr = new SqlParameter("@userAddress", SqlDbType.VarChar, 50);
            SqlParameter paramtype = new SqlParameter("@userType", SqlDbType.VarChar, 50);
            SqlParameter paramop = new SqlParameter("@op", SqlDbType.VarChar, 20);

            cmd.Parameters.Add(paramuserId);
            cmd.Parameters.Add(paramusername);
            cmd.Parameters.Add(paramemailid);
            cmd.Parameters.Add(parampwd);
            cmd.Parameters.Add(parammobno);
            cmd.Parameters.Add(paramaddr);
            cmd.Parameters.Add(paramtype);
            cmd.Parameters.Add(paramop);
        
            if (chkpwd.Checked == true)
            {
                paramusername.Value = txtname.Text;
                paramemailid.Value = label7.Text;
                parammobno.Value = txtmobno.Text;
                paramaddr.Value = txtaddress.Text;
                paramtype.Value = "students";
                paramuserId.Value = uId;
                parampwd.Value = txtnewpwd.Text;
                paramop.Value = "update";
                if (cmd.ExecuteNonQuery() >= 0)
                    MessageBox.Show("Password changed successfully.");
                else
                    MessageBox.Show("Failed to change Password.Try Again Later.");
            }
            else
            {
                paramusername.Value = txtname.Text;
                paramemailid.Value = label7.Text;
                parammobno.Value = txtmobno.Text;
                paramaddr.Value = txtaddress.Text;
                paramtype.Value = "students";
                paramuserId.Value = uId;
                parampwd.Value = 0;
                paramop.Value = "studentUpdate";
                if (cmd.ExecuteNonQuery() >= 0)
                    MessageBox.Show("Details Updated Successfully.");
                else
                    MessageBox.Show("Failed to Update Info.Try Again Later.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you want to download Report Card?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }
    }
}

