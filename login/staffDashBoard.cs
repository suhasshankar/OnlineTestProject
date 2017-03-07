using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace login
{
    public partial class staffDashBoard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=Suhas;Initial Catalog=project;User ID=sa;Password=admin");
        
        public staffDashBoard()
        {
            InitializeComponent();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //menu strip and assigning the MDI parent
            loginform login = new loginform();
            login.MdiParent = this.MdiParent;
            login.Show();
            this.Show();
        }

        private void staffDashBoard_Load(object sender, EventArgs e)
        {
            //error init 
            label15.Text = "";
            label11.Text = "";
            label28.Text = "";

            //on load of this form calls below methods
            questionBankDisp();//table display
            getstaffId();//to get staff Id
            subjectList(comboBox1);//drop down list 1 
            subjectList(subjectNameList);//drop down list 2  
            qNosDisplay();
            AnswerKeyList.SelectedIndex = 0;
            keysList.SelectedIndex = 0;

            //hide add/search by/update grid
            addgrid.Hide();
            updategrid.Hide();
            groupBox1.Hide();
        }

        public void qNosDisplay()
        {
            SqlDataAdapter sd = new SqlDataAdapter("select QuestionId from QuestionBank where staffId=" +label20.Text+"", con);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            DataRow dr = dt.NewRow();
            dr[0] =0;
            dt.Rows.InsertAt(dr, 0);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "QuestionId";
            comboBox2.ValueMember = "QuestionId";           
        }

        //to display all the table in grid view
        public void questionBankDisp()
        {           
            SqlDataAdapter ds = new SqlDataAdapter("select QuestionId[Question No],subjectName[Subject Name],question[Question],optionA[Option A],optionB[Option B],optionC[Option C],optionD[Option D],answer[Answer Key],DateOfTaken[Date of Submission] from QuestionBank where staffId =" + label20.Text+"", con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //To get the staff Id and Email Id to the staff DashBoard for further use and store it in label
        public void getstaffId()
        {         
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select userId[User Id],userName[User Name] from userDetails where emailId='" + label22.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
                label20.Text =Convert.ToString(dr[0]);//user Id
                label2.Text = Convert.ToString(dr[1]);//user Name           
            }
            dr.Close();
        }

        //drop down to list all the subjects from dB
        public void subjectList(ComboBox combo)
        {
            SqlDataAdapter da = new SqlDataAdapter("select subjectName from staffSubjectDetails where staffId='"+label20.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //insert -----select subject------- at first row first col
            DataRow r = dt.NewRow();
            r[0] = "-----Select Subject------/";
            dt.Rows.InsertAt(r, 0);

            //concat all the subject name with '/'
            string list = "";
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    list = list + dr[dc].ToString();
                }
            }
            string[] arrayList = list.Split('/');

            //to show in subject in-charge for staff
            string emptyStr = "";
            for (int i = 1; i < arrayList.Length - 1; i++)
            {
                emptyStr = emptyStr + arrayList[i] + " ";
                label4.Text = emptyStr;
            }

            //to add subject name in drop list
            for (int i = 0; i < arrayList.Length - 1; i++)
                combo.Items.Add(arrayList[i]);

            combo.ValueMember = "subjectName";
            combo.SelectedIndex = 0;
        }

        private string operation;
        private void button1_Click(object sender, EventArgs e)
        {
           //-----------------------valiadation------------------------------------------------
            if (questions.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(questions, "Please Enter the valid Question.");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (optionA.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(optionA, "Please Enter the valid Option A.");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (optionB.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(optionB, "Please Enter the valid Option B.");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (optionC.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(optionC, "Please Enter the valid Option C.");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (optionD.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(optionD, "Please Enter the valid Option D.");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (keysList.SelectedIndex == 0)
            {
                errorProvider1.SetError(keysList, "Please Enter the valid Option D.");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            //---------------------------------------------------------------------------

            //below performs both insert as well as update
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "questionBankOperation";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter paramQuestionId = new SqlParameter("@QuestionId", SqlDbType.Int);
            SqlParameter paramsubId = new SqlParameter("@subjectId", SqlDbType.VarChar, 100);
            SqlParameter paramstaffId = new SqlParameter("@staffId", SqlDbType.Int);
            SqlParameter paramquestion = new SqlParameter("@question", SqlDbType.VarChar, 200);
            SqlParameter paramopA = new SqlParameter("@optionA", SqlDbType.VarChar, 100);
            SqlParameter paramopB = new SqlParameter("@optionB", SqlDbType.VarChar, 100);
            SqlParameter paramopC = new SqlParameter("@optionC", SqlDbType.VarChar, 100);
            SqlParameter paramopD = new SqlParameter("@optionD", SqlDbType.VarChar, 100);
            SqlParameter paramAns = new SqlParameter("@answer", SqlDbType.VarChar, 50);
            SqlParameter paramop = new SqlParameter("@op", SqlDbType.VarChar, 20);

            cmd.Parameters.Add(paramQuestionId);
            cmd.Parameters.Add(paramsubId);
            cmd.Parameters.Add(paramstaffId);
            cmd.Parameters.Add(paramquestion);
            cmd.Parameters.Add(paramopA);
            cmd.Parameters.Add(paramopB);
            cmd.Parameters.Add(paramopC);
            cmd.Parameters.Add(paramopD);
            cmd.Parameters.Add(paramAns);
            cmd.Parameters.Add(paramop);

            
            paramstaffId.Value = Convert.ToInt32(label20.Text);
            paramquestion.Value = questions.Text.ToString();
            paramopA.Value = optionA.Text.ToString();
            paramopB.Value = optionB.Text.ToString();
            paramopC.Value = optionC.Text.ToString();
            paramopD.Value = optionD.Text.ToString();
            paramAns.Value = keysList.SelectedItem.ToString();

            //method called to check to check the whether question is present or not 
            //if present update else insert
            if ( operation=="update")
            {
                comboBox1.Visible = false;
                paramsubId.Value = label26.Text;//subject Name can't be changed so used stored subName
                paramQuestionId.Value = questionNo;//required to identify the Row 
                paramop.Value = "update";
                if (cmd.ExecuteNonQuery() >= 1)
                {
                    label11.Text = "Updated Successfully.";
                    comboBox1.SelectedIndex = 0;
                    clearFields();
                    questionBankDisp();
                }
                else
                    label11.Text = "Error Uploading. Try Again!!";
            }
            else
            {
                if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == -1)
                {
                    errorProvider1.SetError(comboBox1, "Please select the Subject Name");
                    return;
                }
                else
                {
                    errorProvider1.Clear();
                }
                paramsubId.Value = comboBox1.SelectedItem.ToString();
                paramQuestionId.Value = 0;//Not required for Insert so 0 is sent
                paramop.Value = "insert";
                if (cmd.ExecuteNonQuery() >= 1)
                {
                    comboBox1.SelectedIndex = 0;
                    label11.Text = "1 Row Affected.Inserted Successfully.";
                    clearFields();
                    questionBankDisp();
                }
                else
                    label11.Text = "Error Inserting. Try Again!!";
            }
        }

        int questionNo;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            questionNo = (int) dataGridView1.Rows[index].Cells[0].Value; //for insert operation

            //update Operation 
            label5.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            label17.Text = "Selected Subject Name : ";
            label26.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            questions.Text= dataGridView1.Rows[index].Cells[2].Value.ToString();
            optionA.Text= dataGridView1.Rows[index].Cells[3].Value.ToString();
            optionB.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            optionC.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            optionD.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();                     
            label27.Text = " Selected Option : " + dataGridView1.Rows[index].Cells[7].Value.ToString();           
        }

        public void clearFields()
        {
            questions.Text ="";
            optionA.Text = "";
            optionB.Text = "";
            optionC.Text = "";
            optionD.Text = "";
            label5.Text = "";
        }
       
        //below are toggle effects
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            questionBankDisp();
            //toggle effects
            if (chkadd.Checked == false)
            {
                chkupdate.Checked = false;
                addgrid.Hide();
                clearFields();               
            }
            else
            {
                chkupdate.Checked = false;
                addgrid.Show();
                operation = "insert";
                clearFields();
                label5.Text = "QNo";
                label27.Text = "";
                label17.Text = "";
                label26.Text = "";
                keysList.SelectedIndex = 0;
                comboBox1.Enabled = true;
            }
        }

        //toggle effects
        private void chkupdate_CheckedChanged(object sender, EventArgs e)
        {
            questionBankDisp();           
            if (chkupdate.Checked == false)
            {
                chkadd.Checked = false;
                updategrid.Hide();
                addgrid.Hide();
                groupBox1.Hide();
                clearFields();
            }
            else
            {
                chkadd.Checked = false;
                updategrid.Show();
                addgrid.Show();
                groupBox1.Show();
                operation = "update";
                clearFields();
                comboBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //-------------------validation-----------------------
            if (textBox1.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(textBox1, "Please enter valid Old Password");
                return;
            }
            else
                errorProvider1.Clear();

            if (textBox2.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(textBox2, "Please enter valid New Password");
                return;
            }
            else
                errorProvider1.Clear();

            if (textBox3.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(textBox3, "Please enter valid New Password");
                return;
            }
            else
                errorProvider1.Clear();
            //----------------------------------------------------------------------------------

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText="select pwd from userDetails where userId="+label20.Text+"";
            string pwd = cmd.ExecuteScalar().ToString();

            if (textBox1.Text == pwd)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandText = "changePassword";
                    cmd1.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramid = new SqlParameter("@userId", SqlDbType.Int);
                    SqlParameter parampwd = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
                    SqlParameter paramtype = new SqlParameter("@type", SqlDbType.VarChar, 50);

                    cmd1.Parameters.Add(paramid);
                    cmd1.Parameters.Add(parampwd);
                    cmd1.Parameters.Add(paramtype);

                    paramid.Value = Convert.ToInt32(label20.Text);
                    parampwd.Value = textBox2.Text;
                    paramtype.Value = "staff";

                    if (cmd1.ExecuteNonQuery() >= 0)
                    {
                        label15.Text = "Password Updated Successfully";
                        clearPwdFields();
                    }
                    else
                    {
                        label15.Text = "Failed to Password.Try Again!!";
                        clearPwdFields();
                    }
                }
                else
                {
                    label15.Text = "Password Do not Match.Try Again!!";
                    textBox2.Text = ""; textBox3.Text = "";
                    textBox2.Focus();
                }
            }
            else
            {
                label15.Text = "Invalid Old Password.Try Again!!";
                textBox1.Text = "";
                textBox1.Focus();
            }
            
        }

        //to clear feilds 
        public void clearPwdFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0 && AnswerKeyList.SelectedIndex<=0 && subjectNameList.SelectedIndex == 0)
            {
                label28.Text = "Please Select Atleast One Option";
                return;
            }

            string statement = "";
            if (statement == "" && AnswerKeyList.SelectedIndex > 0 && comboBox2.SelectedIndex > 0)
                statement = "answer=" + "'" + AnswerKeyList.SelectedItem + "'" + " and QuestionId=" + comboBox2.SelectedValue;

            if (statement == "" && comboBox2.SelectedIndex > 0 && subjectNameList.SelectedIndex > 0)
                statement = "QuestionId=" + comboBox2.SelectedValue + " and subjectName=" + "'" + subjectNameList.SelectedItem + "'";

            if (statement == "" && AnswerKeyList.SelectedIndex > 0 && subjectNameList.SelectedIndex > 0)
                statement = "answer=" + "'" + AnswerKeyList.SelectedItem + "'" + " and subjectName=" + "'" + subjectNameList.SelectedItem + "'";

            if (statement=="" && AnswerKeyList.SelectedIndex>0 && comboBox2.SelectedIndex>0 && subjectNameList.SelectedIndex>0)
                statement = "answer=" + "'"+AnswerKeyList.SelectedItem+"'"  + " and QuestionId=" + comboBox2.SelectedValue + " and subjectName=" + "'" + subjectNameList.SelectedItem + "'";

            if (statement == "" && AnswerKeyList.SelectedIndex > 0 )
                statement = "answer=" + "'" + AnswerKeyList.SelectedItem + "'";

            if (statement == "" &&  comboBox2.SelectedIndex > 0 )
                statement = "questionId=" +  comboBox2.SelectedValue;

            if (statement == "" && subjectNameList.SelectedIndex > 0)
                statement = "subjectName=" + "'" + subjectNameList.SelectedItem + "'";

            SqlDataAdapter da = new SqlDataAdapter("select * from QuestionBank where " + statement + "", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            label28.Text = dataGridView1.Rows.Count.ToString()+" Rows Found.Shown Below." ;
        }
    }
}
