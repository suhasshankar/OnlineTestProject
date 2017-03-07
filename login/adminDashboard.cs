using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login
{
    public partial class adminDashboard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=Suhas;Initial Catalog=project;User ID=sa;Password=admin");
        public adminDashboard()
        {
            InitializeComponent();
        }

        private void adminDashboard_Load(object sender, EventArgs e)
        {
            //error init to null
            clearFields();

            subjectList(checkedListBox1);//checked List 1
            displayStaffName(staffNameAdd);//dropdown 2
            unAllocatedDisp();//table to display for un-allocated staff
            tableDisplay();// full table display
            subjectList(checkedListBox2);//checked list 2
        }

        //To display the staff name and user Id
        public void displayStaffName(ComboBox cmbStaffName) //dropdown
        {
            SqlDataAdapter da = new SqlDataAdapter("select s.staffName from staffSubjectDetails s inner join userDetails u on s.staffId=u.userId where u.userType='staff'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow r = dt.NewRow();
            r[0] = "----Select Staff Name----";
            dt.Rows.InsertAt(r, 0);
            cmbStaffName.DataSource = dt;
            cmbStaffName.DisplayMember = "staffName";
            cmbStaffName.ValueMember = "staffName";
        }

        //to display all the subjects in the check list
        public void subjectList(CheckedListBox chkbx) //checked List
        {
            SqlDataAdapter da = new SqlDataAdapter("select subjectName from subjects", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow r = dt.NewRow();
            r[0] = "-----Select Subject------";
            dt.Rows.InsertAt(r, 0);

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    chkbx.Items.Add(dr[dc]);
                }
            }
        }

        //to display all un-allocated
        public void unAllocatedDisp() //table to display
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT  userId[Staff Id],userName[Staff Name] FROM userDetails u WHERE u.userType='staff' and u.userId NOT IN (SELECT s.staffId FROM staffSubjectDetails s where s.staffId=u.userId)", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffView.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (userIdLabel.Text == "Staff ID")
            {
                errorProvider1.SetError(userIdLabel, "Please select the staff Id to Allocate Add/Update");
                return;
            }
            else
                errorProvider1.Clear();

            if (label8.Text == "Staff Name")
            {
                errorProvider1.SetError(label8, "Please select the staff Name to Allocate Add/Update");
                return;
            }
            else
                errorProvider1.Clear();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "operationAdmin";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramuserId = new SqlParameter("@userId", SqlDbType.Int);
            SqlParameter paramsubId = new SqlParameter("@subjectId", SqlDbType.VarChar, 50);
            SqlParameter paramstaffName = new SqlParameter("@staffName", SqlDbType.VarChar, 50);
            SqlParameter paramstatus = new SqlParameter("@status", SqlDbType.VarChar, 50);
            SqlParameter paramAllocBy = new SqlParameter("@AllocBy", SqlDbType.VarChar, 50);
            SqlParameter paramOp = new SqlParameter("@op", SqlDbType.VarChar, 9);

            cmd.Parameters.Add(paramuserId);
            cmd.Parameters.Add(paramsubId);
            cmd.Parameters.Add(paramstaffName);
            cmd.Parameters.Add(paramstatus);
            cmd.Parameters.Add(paramAllocBy);
            cmd.Parameters.Add(paramOp);

            //user Id
            paramuserId.Value = Convert.ToInt32(userIdLabel.Text);           //1

            //To fetch and concat all the selected subjects                 //2
            String list = "";
            foreach (string str in checkedListBox1.CheckedItems)
            {
                list = list + str + "/";
            }
            paramsubId.Value = list.ToString();

            //staff Name
            paramstaffName.Value = label8.Text;                              //3

            //status
            if (checkBox1.Checked == true)                                  //4
            {
                paramstatus.Value = "Disabled";
            }
            else if (checkBox1.Checked == false)
            {
                paramstatus.Value = "Active";
            }
            paramAllocBy.Value = adminUserName.Text;                        //5

            if (checkPresentOrNot(Convert.ToInt32(userIdLabel.Text)))
            {
                paramOp.Value = "Update";                                   //6
                if (cmd.ExecuteNonQuery() == 1)
                {
                    label6.Text = "Updated Successfully.";
                    unAllocatedDisp();
                    tableDisplay();
                }
                else
                    label6.Text = "Error Uploading. Try Again!!";
            }
            else
            {
                paramOp.Value = "insert";
                if (cmd.ExecuteNonQuery() == 1)
                {
                    label6.Text = "1 Row Affected. Inserted Successfully.";
                    unAllocatedDisp();
                    tableDisplay();
                }
                else
                    label6.Text = "Error Uploading. Try Again!!";
            }

            clearFields();//clear fields
            checkedListBox1.ClearSelected();
        }

        //clear fields after add/update operation
        public void clearFields()
        {
            userIdLabel.Text = "Staff ID";
            label8.Text = "Staff Name";
            checkedListBox1.ClearSelected();
            label6.Text = "";
            adminres.Text = "";
            Result.Text = "";
        }

        //Allocated Table Display
        //To display all the table data of staffSubjectDetails
        public void tableDisplay()
        {
            SqlDataAdapter da = new SqlDataAdapter("select s.staffId[Staff ID],u.userName[staff Name],s.subjectName[Subject Allocated],u.emailId[Staff Email Id],s.status[Status],u.mobileNo[Mobile Number],u.userAddress[Staff Address],u.pwd[Password],s.AllocBy[Allocated By],s.AllocDate[Date Of Allocation] from staffSubjectDetails s inner join userDetails u on s.staffId=u.userId", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffview1.DataSource = dt;
        }

        //To identify whether to perform Insert/Update
        //if present return true(update)
        //if not found return false(insert)
        public bool checkPresentOrNot(int userId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.CommandText = "select count(*) from staffSubjectDetails where staffId=" + userId;
            if ((int)cmd.ExecuteScalar() == 1)
                return true;
            else
                return false;
        }

        //Un-Allocated staff table row click operation
        public int index;
        private void staffView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            errorProvider1.Clear();
            index = e.RowIndex;
            userIdLabel.Text = staffView.Rows[index].Cells[0].Value.ToString();
            label8.Text = staffView.Rows[index].Cells[1].Value.ToString();

            //to uncheck all the selected items
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginform login = new loginform();
            login.MdiParent = this.MdiParent;
            login.Show();
            this.Hide();
        }

        //Allocated Table row click action
        private void staffview1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            errorProvider1.Clear();
            int index = e.RowIndex;
            userIdLabel.Text = staffview1.Rows[index].Cells[0].Value.ToString();
            label8.Text = staffview1.Rows[index].Cells[1].Value.ToString();
            string subjectName = staffview1.Rows[index].Cells[2].Value.ToString();
            string[] array = subjectName.Split('/');
            for (int j = 0; j < array.Length; j++)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if ((string)checkedListBox1.Items[i] == array[j])
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }

            //To update the staff Details on Row Header Mouse Click
            adminlbl.Text = staffview1.Rows[index].Cells[0].Value.ToString();
            admintxt1.Text = staffview1.Rows[index].Cells[1].Value.ToString();
            admintxt2.Text = staffview1.Rows[index].Cells[3].Value.ToString();
            admintxt3.Text = staffview1.Rows[index].Cells[7].Value.ToString();
            admintxt4.Text = staffview1.Rows[index].Cells[5].Value.ToString();
            admintxt5.Text = staffview1.Rows[index].Cells[6].Value.ToString();
        }

        //Add or Update button for staff
        private void button3_Click(object sender, EventArgs e)
        {
            //---------------Validation of fields--------------------------
            if (admintxt1.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(admintxt1, "Please Enter Staff Name");
                return;
            }
            else
                errorProvider1.Clear();

            if (admintxt2.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(admintxt2, "Please Enter Mobile Number");
                return;
            }
            else
                errorProvider1.Clear();

            if (admintxt3.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(admintxt3, "Please Enter Email Id");
                return;
            }
            else
                errorProvider1.Clear();

            if (admintxt4.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(admintxt4, "Please Enter Password");
                return;
            }
            else
                errorProvider1.Clear();

            if (admintxt5.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(admintxt5, "Please Enter Address");
                return;
            }
            else
                errorProvider1.Clear();
            //----------------------------------------------------------------------------------------------
            
            string op = "";
            if (checkBox2.Checked == true)
                op = "insert";
            else op = "update";

            register update = new register();
            if (update.registerAddUpdate(op, adminlbl.Text, admintxt1.Text, admintxt2.Text, admintxt3.Text, admintxt4.Text, admintxt5.Text))
            {
                adminres.Text = "successfully updated";
                clearAddUpdateGrp();
            }
            else
            {
                adminres.Text = "Error Updating Data.Try Again!";
                clearAddUpdateGrp();
            }
            unAllocatedDisp();
            tableDisplay();
            update = null;
        }

        //clear all fields
        public void clearAddUpdateGrp()
        {
            admintxt1.Text = "";
            admintxt2.Text = "";
            admintxt3.Text = "";
            admintxt4.Text = "";
            admintxt5.Text = "";
        }

        //Add check box
        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked==true)
            {
                adminlbl.Text = "";
                label11.Text = "";
                clearAddUpdateGrp();
            }
            else if (checkBox2.Checked == false)
            {
                adminlbl.Text = "Staff Id";
                label11.Text = "Staff No";
                clearAddUpdateGrp();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string statement = "";
            if( statement=="" && staffNameAdd.SelectedIndex>0 && updateStatus.SelectedIndex>0 )
            {
                statement = "staffName = "+"'"+staffNameAdd.SelectedValue+"'" + " and status="+ "'"+updateStatus.SelectedItem+"'";
            }

            if (statement == "" && staffNameAdd.SelectedIndex > 0 )
            {
                statement = "staffName = " + "'"+staffNameAdd.SelectedValue+"'";
            }

            if (statement == "" &&  updateStatus.SelectedIndex > 0)
            {
                statement ="status=" + "'"+updateStatus.SelectedItem+"'";
            }


            if (statement == "" && checkedListBox2.CheckedItems.Count > 0)
            {
                foreach(string str in checkedListBox2.CheckedItems)
                {
                    statement = statement + str + "/";
                }
                statement = "subjectName like" + " '%[" + statement + "]%'";
            }

            if (statement == "" && checkedListBox2.CheckedItems.Count > 0 && statement == "" && staffNameAdd.SelectedIndex > 0 && updateStatus.SelectedIndex > 0)
            {
                foreach (string str in checkedListBox2.CheckedItems)
                {
                    statement = statement + str + "/";
                }
                statement = "subjectName like" + " '%[" + statement + "]%'" + " and staffName = " + "'" + staffNameAdd.SelectedValue + "'" + " and status=" + "'" + updateStatus.SelectedItem + "'";
            }

            SqlDataAdapter da = new SqlDataAdapter("select * from staffSubjectDetails where "+ statement+"", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            staffview1.DataSource = dt;
        }
    }
}
