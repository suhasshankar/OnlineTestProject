using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            dropDownList(txtuserType);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(validateLogin())
            {
                SqlConnection con = new SqlConnection("Data Source=Suhas;Initial Catalog=project;User ID=sa;Password=admin");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText= "select count(*) from userDetails where emailId='" + txtname.Text + "' and pwd='" + txtpwd.Text + "' and userType='" + txtuserType.SelectedValue + "'";
                //if ((int)cmd.ExecuteScalar() == 1)
                //{
                    if (txtuserType.SelectedValue.ToString() == "admin")
                    {
                        adminDashboard admin = new adminDashboard();
                        admin.MdiParent = this.MdiParent;
                        admin.adminUserName.Text = txtname.Text;
                        admin.Show();
                        this.Hide();
                    }
                    else if (txtuserType.SelectedValue.ToString() == "staff")
                    {
                        staffDashBoard staff = new staffDashBoard();
                        staff.MdiParent = this.MdiParent;
                        staff.label22.Text = txtname.Text;
                        staff.Show();
                        this.Hide();
                    }
                    else if (txtuserType.SelectedValue.ToString() == "student")
                    {
                        StudentDashBoard student = new StudentDashBoard();
                        student.MdiParent = this.MdiParent;
                        student.label7.Text = txtname.Text;
                        student.Show();
                        this.Hide();
                    }
                //}
                //else MessageBox.Show("Please Enter the Valid Email Id and Password");
            }
            else
            {
                validateLogin();
            }
        }

        public bool validateLogin()
        {           
           
            bool result = true;
            if (txtname.Text.Trim().Length <= 1)
            {
                errorProvider1.SetError(txtname, "Please Enter the Valid UserName/Email Id");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }

            if (txtpwd.Text.Trim().Length <= 1)
            {
                errorProvider1.SetError(txtpwd, "Empty Password. Please Enter the Password.");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            if(txtuserType.SelectedValue.ToString()== "----Select Login Type----")
            {
                errorProvider1.SetError(txtuserType, "Please Select the Login Type");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register register = new register();
            register.MdiParent = this.MdiParent;
            register.Show();
            this.Hide();
        }

        public bool dropDownList(ComboBox txtuserType)
        {
            SqlConnection con = new SqlConnection("Data Source=Suhas;Initial Catalog=project;User ID=sa;Password=admin");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from userTypes", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow r = dt.NewRow();
            r[0] = "----Select Login Type----";
            dt.Rows.InsertAt(r, 0);
            txtuserType.DataSource = dt;
            txtuserType.DisplayMember = "userType";
            txtuserType.ValueMember = "userType";
            return true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPwd frgpwd = new ForgotPwd();
            frgpwd.MdiParent = this.MdiParent;
            frgpwd.Show();
            this.Hide() ;
        }

        
    }
}
