using System; 
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace login
{
    public partial class testWindow : Form
    {
        SqlConnection con = new SqlConnection("Data Source=Suhas;Initial Catalog=project;User ID=sa;Password=admin");
        public testWindow()
        {
            InitializeComponent();
        }

        ArrayList questionNos = new ArrayList();
        Hashtable qkey = new Hashtable();
 
        private void testWindow_Load(object sender, EventArgs e)
        {
            //to hide both question display grp box and answer key preview grp box intially
            groupBox2.Hide();
            groupBox1.Hide();

            //select only question Id from the table
            SqlDataAdapter da = new SqlDataAdapter("select QuestionId from QuestionBank where subjectName='"+label31.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //to store the question number           
            foreach(DataRow r in dt.Rows)
            {
                questionNos.Add(r[0]);
            }            
        }

        private void button24_Click(object sender, EventArgs e)
        {           
            groupBox1.Show();
            timer1.Start();
            button24.Enabled = false;
            next();
            clearOption();
        }

        static int counterPrev = 0;
        static int counterNext = 0;
      
        //next button
        private void button2_Click(object sender, EventArgs e) 
        {            
            qkey.Add(deletedQuestion[counterNext-1],getOption());            
            next();         
            clearOption();
        }

        //next button
        ArrayList deletedQuestion = new ArrayList();
        public void next()
        {
            //on next click
            //to loop through 20 question to follow Condition
            int index = 0;
            int qNo = 0;
            //counts the no of clicks of button next
            //to maintain 20 question

            counterNext++;
            while (counterNext == counterPrev)
            {
                counterPrev++;
                displayToTestWindow((int)deletedQuestion[counterPrev]);
            }

            if (counterNext <= 20 && questionNos.Count != 0)
            {
                label1.Text = counterNext.ToString();
                index = randomGenerator(questionNos);//gets random number
                qNo = (int)questionNos[index]; // To get the Question Id
                displayToTestWindow(qNo);//display using Question Id 
                deletedQuestion.Add(qNo);
                questionNos.RemoveAt(index);
            }
            else
            {
                button2.Enabled = false;
            }
        }

        //generate random numbers
        Random random = new Random();
        public int randomGenerator(ArrayList questionIds)
        {
            return random.Next(0, questionIds.Count);
        }

        //to display question and options int test window using Question Id
        public void displayToTestWindow(int questionId)
        {
            SqlDataAdapter da = new SqlDataAdapter("select question,optionA,optionB,optionC,optionD from QuestionBank where subjectName='" + label31.Text + "' and QuestionId='" + questionId + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                label2.Text = dr[0].ToString();
                radioButton1.Text = dr[1].ToString();
                radioButton2.Text = dr[2].ToString();
                radioButton3.Text = dr[3].ToString();
                radioButton4.Text = dr[4].ToString();
            }
        }

        //final submit button
        private void button25_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            for (int i = 0; i < questionNo2.Count; i++)
            {
                qkey[questionNo2[i]] = choice2[i+1];
            }
            checkSubmit();
        }

        public void insertMarks()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "marksInsert";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramId = new SqlParameter("@userId", SqlDbType.Int);
            SqlParameter paramSubjectName= new SqlParameter("@subjectName", SqlDbType.VarChar,50);
            SqlParameter paramMarks = new SqlParameter("@marks", SqlDbType.BigInt);

            cmd.Parameters.Add(paramId);
            cmd.Parameters.Add(paramSubjectName);
            cmd.Parameters.Add(paramMarks);

            paramId.Value =Convert.ToInt32(label15.Text);           
            paramSubjectName.Value = label31.Text.ToString();
            paramMarks.Value = Convert.ToInt32(correctAnswer);

            if (cmd.ExecuteNonQuery() == 0) 
                MessageBox.Show("Insert Failed.");
        }


        //submit/preview Button
        private void button26_Click(object sender, EventArgs e)
        {
            button24.Enabled = false;
            DialogResult res = MessageBox.Show("Do you want to Preview Answer?", "Answer Preview", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (qkey.Count == 0)
                {
                    MessageBox.Show("Unable Process Preview Request.Reason: No Options Selected.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkSubmit();
                }
                else
                {
                    button2.Enabled = false;
                    button1.Enabled = false;
                    button26.Enabled = false;
                    groupBox2.Show();
                    ICollection value = qkey.Values;
                    foreach (string choice in value)
                        choices.Add(choice);
                    button24.Enabled = false;
                }
            }
            else
            {
                checkSubmit();
            }
        }

        public void checkSubmit()
        {
            button24.Enabled = false;
            DialogResult res = MessageBox.Show("Do you want to Submit Answer?", "Submission of Test Answer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                groupBox1.Hide();
                groupBox2.Hide();
                readHashTable(qkey);
                DialogResult result= MessageBox.Show("Your score is " + correctAnswer + " .For more Info login again.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(result==DialogResult.OK)
                {
                    DialogResult check = MessageBox.Show("Click ok to login.", "Login Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    if(check==DialogResult.OK)
                    {
                        loginform log = new loginform();
                        log.MdiParent = this.MdiParent;
                        log.txtname.Text = label29.Text;
                        log.Show();
                        this.Close();
                    }
                }

            }
        }

        //Read Hash Table to check for Result
        public static int unAnsweredCount=0;
        ArrayList choices = new ArrayList();
        ArrayList finalChoices = new ArrayList();
        public void readHashTable(Hashtable qkey)
        {
            ICollection key = qkey.Keys;
            ArrayList qNos =new ArrayList();
            foreach (int qNo in key)
                qNos.Add(qNo);//stores all question No

            //stores all choices
            ICollection value = qkey.Values;
            foreach (string choice in value)
                finalChoices.Add(choice);

            //to check for un-answered question
            for (int i = 0; i < counterNext-1; i++)
            {
                if (qkey.ContainsValue("X"))
                    unAnsweredCount++;
            }

            //get each qno ans choice to check for coorect answer
            for (int i = 0; i < 20; i++)
            {
                 checkAnswer((int)qNos[i], finalChoices[i].ToString());
            }                                                
        }

        //Check whether qNo-Answer pair is matching with database Answer
        private static int correctAnswer = 0;
        public void checkAnswer(int qNo,string answer)
        {
            SqlDataAdapter da = new SqlDataAdapter("select QuestionId,answer from QuestionBank where subjectName='"+label31.Text+"'", con);
            DataTable dt =new DataTable();
            da.Fill(dt);

            foreach(DataRow r in dt.Rows)
            {                
                if(qNo== Convert.ToInt32(r[0].ToString()))
                {
                    if (answer == r[1].ToString())
                        correctAnswer++;
                }
            }
        }

        //prev button
        private void button1_Click(object sender, EventArgs e)
        { 
            counterNext--;
            if (counterNext!=0)
            {
                displayToTestWindow(1);                
            }
        }

        //returns options selected
        public string getOption()
        {
            if (radioButton1.Checked == true)
                return "A";
            else if (radioButton2.Checked == true)
                return "B";
            else if (radioButton3.Checked == true)
                return "C";
            else if (radioButton4.Checked == true)
                return "D";
            else
                return "X";
        }

        //clears option for next question
        public void clearOption()
        {
            if (radioButton1.Checked == true)
                radioButton1.Checked = false;
            else if (radioButton2.Checked == true)
                radioButton2.Checked = false;
            else if (radioButton3.Checked == true)
                radioButton3.Checked = false;
            else if (radioButton4.Checked == true)
                radioButton4.Checked = false;
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            int min;
            int sec;
            label3.Text = "19:59";
            string[] time = label3.Text.Split(':');
            min = Convert.ToInt32(time[0]);
            sec = Convert.ToInt32(time[1]);

            while (min!=0)
            {
                if (sec==0)
                {
                    min--;
                    sec = 59;
                    label3.Text = min.ToString() + sec.ToString();
                }
                else
                {
                    sec--;
                    label3.Text = min.ToString() + sec.ToString();
                }
            }
        }        
           
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            insertMarks();
            loginform student = new loginform();
            student.txtname.Text = label29.Text;
            student.Show();
            student.MdiParent = this.MdiParent;
            this.Close();
        }

        //Answer preview 
        private void button3_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[0]);
            setOption(qkey[deletedQuestion[0]].ToString(), (int)deletedQuestion[0]);          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[1]);
            setOption(qkey[deletedQuestion[1]].ToString(), (int)deletedQuestion[1]);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[2]);
            setOption(qkey[deletedQuestion[2]].ToString(), (int)deletedQuestion[2]);            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[3]);
            setOption(qkey[deletedQuestion[3]].ToString(), (int)deletedQuestion[3]);            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[4]);
            setOption(qkey[deletedQuestion[4]].ToString(), (int)deletedQuestion[4]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[5]);
            setOption(qkey[deletedQuestion[5]].ToString(), (int)deletedQuestion[5]);            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[6]);
            setOption(qkey[deletedQuestion[6]].ToString(), (int)deletedQuestion[6]);            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[7]);
            setOption(qkey[deletedQuestion[7]].ToString(), (int)deletedQuestion[7]);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[8]);
            setOption(qkey[deletedQuestion[8]].ToString(), (int)deletedQuestion[8]);
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[9]);
            setOption(qkey[deletedQuestion[9]].ToString(), (int)deletedQuestion[9]);
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[10]);
            setOption(qkey[deletedQuestion[10]].ToString(), (int)deletedQuestion[10]);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[11]);
            setOption(qkey[deletedQuestion[11]].ToString(), (int)deletedQuestion[11]);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[12]);
            setOption(qkey[deletedQuestion[12]].ToString(), (int)deletedQuestion[12]);            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[13]);
            setOption(qkey[deletedQuestion[13]].ToString(), (int)deletedQuestion[13]);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption()); displayToTestWindow((int)deletedQuestion[14]);
            setOption(qkey[deletedQuestion[14]].ToString(), (int)deletedQuestion[14]);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[15]);
            setOption(qkey[deletedQuestion[15]].ToString(), (int)deletedQuestion[15]);            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[16]);
            setOption(qkey[deletedQuestion[16]].ToString(), (int)deletedQuestion[16]);            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[17]);
            setOption(qkey[deletedQuestion[17]].ToString(), (int)deletedQuestion[17]);            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[18]);
            setOption(qkey[deletedQuestion[18]].ToString(), (int)deletedQuestion[18]);            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            choice2.Add(getOption());
            displayToTestWindow((int)deletedQuestion[19]);
            setOption(qkey[deletedQuestion[19]].ToString(), (int)deletedQuestion[19]);            
        }

        ArrayList questionNo2 = new ArrayList();
        ArrayList choice2 = new ArrayList();
        public void setOption(string index,int Qno)
        {
            //qkey[Qno] = choice2[index+1];
            updateChoices();
            setChoices(index);
            questionNo2.Add(Qno);
            choices.Clear();
        }

        //Set the Choice as per stored Choices
        public void setChoices(string index)
        {
            if (index == "A")
                radioButton1.Checked = true;
            else if (index == "B")
                radioButton2.Checked = true;
            else if (index == "C")
                radioButton3.Checked = true;
            else if (index == "D")
                radioButton4.Checked = true;
            else
                clearOption();
        }

        public void updateChoices()
        {
            for (int i = 0; i < questionNo2.Count; i++)
            {
                qkey[questionNo2[i]] = choice2[i + 1];
            }
            ICollection value = qkey.Values;
            foreach (string choice in value)
                choices.Add(choice);
        }
    }
}
