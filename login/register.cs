using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(validateRegister())
            {
                registerAddUpdate(null, null, null, null, null, null,null);
            } else
            {
                validateRegister();
            }
        }

        public bool registerAddUpdate(string operation,string label,string txt1,string txt2,string txt3,string txt4,string txt5)
        {
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

            if (operation==null) //insert for registration page
            {
                paramop.Value = "insert";
                paramuserId.Value = 0;
                paramusername.Value = txtname.Text.ToString();
                paramemailid.Value = txtemailid.Text.ToString();
                parampwd.Value = txtpwd.Text.ToString();
                parammobno.Value = Convert.ToInt64(txtmobileno.Text);
                paramaddr.Value = txtaddress.Text.ToString();
                paramtype.Value = "students";

                if (cmd.ExecuteNonQuery() >= 0)
                {
                    MessageBox.Show("Welcome " + txtname.Text.ToString() + " .Your Account has been created.");
                    loginform login = new loginform();
                    login.txtname.Text = txtemailid.Text.ToString();
                    login.MdiParent = this.MdiParent;
                    login.Show();
                    this.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Try Again!!");
                    return false;
                }
            }
            else //Add or update for admin page
            {              
                paramusername.Value = txt1;
                paramemailid.Value = txt2;
                parampwd.Value = txt3;
                parammobno.Value = txt4;
                paramaddr.Value = txt5;
                paramtype.Value = "staff";
                if (operation=="insert")
                {
                    paramuserId.Value = 0;
                    paramop.Value = "insert";
                    if (cmd.ExecuteNonQuery() >= 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    paramuserId.Value = Convert.ToString(label);
                    paramop.Value = "update";
                    if (cmd.ExecuteNonQuery() >= 0)
                        return true;
                    else
                        return false;
                }
                
            }
        }


        public bool validateRegister()
        {
            bool result = true;
            if(txtname.Text.Trim().Length<1)
            {
                errorProvider1.SetError(txtname, "Please Enter the Name.");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            if (txtemailid.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtemailid, "Please Enter the Name.");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            if (txtmobileno.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtmobileno, "Please Enter the Name.");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            if (txtaddress.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtaddress, "Please Enter the Name.");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            if (txtpwd.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtpwd, "Please Enter the Name.");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            if (txtconfirmpwd.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtconfirmpwd, "Please Enter the Name.");
                result = false;
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            
            return result;
        }
        
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginform login = new loginform();
            login.MdiParent = this.MdiParent;
            login.Show();
            this.Hide();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }
    }
}
