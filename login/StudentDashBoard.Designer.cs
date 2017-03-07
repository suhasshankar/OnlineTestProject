namespace login
{
    partial class StudentDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkpwd = new System.Windows.Forms.CheckBox();
            this.txtoldpwd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtmobno = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtnewpwd = new System.Windows.Forms.TextBox();
            this.txtconfirmnewpwd = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.welcomeUserName = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkpwd);
            this.groupBox1.Controls.Add(this.txtoldpwd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtmobno);
            this.groupBox1.Controls.Add(this.txtaddress);
            this.groupBox1.Controls.Add(this.txtnewpwd);
            this.groupBox1.Controls.Add(this.txtconfirmnewpwd);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 524);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Details";
            // 
            // chkpwd
            // 
            this.chkpwd.AutoSize = true;
            this.chkpwd.Location = new System.Drawing.Point(67, 37);
            this.chkpwd.Name = "chkpwd";
            this.chkpwd.Size = new System.Drawing.Size(275, 25);
            this.chkpwd.TabIndex = 16;
            this.chkpwd.Text = "Do you want to change Password?";
            this.chkpwd.UseVisualStyleBackColor = true;
            this.chkpwd.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtoldpwd
            // 
            this.txtoldpwd.Location = new System.Drawing.Point(290, 155);
            this.txtoldpwd.Name = "txtoldpwd";
            this.txtoldpwd.PasswordChar = '*';
            this.txtoldpwd.Size = new System.Drawing.Size(238, 28);
            this.txtoldpwd.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "Old Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "abc@123.com";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(461, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtmobno
            // 
            this.txtmobno.Location = new System.Drawing.Point(290, 396);
            this.txtmobno.Name = "txtmobno";
            this.txtmobno.Size = new System.Drawing.Size(238, 28);
            this.txtmobno.TabIndex = 11;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(290, 319);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(238, 54);
            this.txtaddress.TabIndex = 10;
            // 
            // txtnewpwd
            // 
            this.txtnewpwd.Location = new System.Drawing.Point(290, 207);
            this.txtnewpwd.Name = "txtnewpwd";
            this.txtnewpwd.PasswordChar = '*';
            this.txtnewpwd.Size = new System.Drawing.Size(238, 28);
            this.txtnewpwd.TabIndex = 9;
            // 
            // txtconfirmnewpwd
            // 
            this.txtconfirmnewpwd.Location = new System.Drawing.Point(290, 260);
            this.txtconfirmnewpwd.Name = "txtconfirmnewpwd";
            this.txtconfirmnewpwd.PasswordChar = '*';
            this.txtconfirmnewpwd.Size = new System.Drawing.Size(238, 28);
            this.txtconfirmnewpwd.TabIndex = 8;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(290, 82);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(238, 28);
            this.txtname.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Re-Type New Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mobile Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.takeTestToolStripMenuItem,
            this.resultsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1279, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.updateToolStripMenuItem.MergeIndex = 0;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(74, 25);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeTestToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.takeTestToolStripMenuItem.MergeIndex = 1;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(87, 25);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.resultsToolStripMenuItem.MergeIndex = 2;
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(74, 25);
            this.resultsToolStripMenuItem.Text = "Results";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.helpToolStripMenuItem.MergeIndex = 3;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.logOutToolStripMenuItem.MergeIndex = 4;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(622, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 524);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(544, 277);
            this.dataGridView1.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 23);
            this.label9.TabIndex = 1;
            this.label9.Text = "Number Of Test Taken :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(544, 36);
            this.button2.TabIndex = 0;
            this.button2.Text = "DownLoad Report Card";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(32, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1208, 46);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(43, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 24);
            this.label11.TabIndex = 4;
            this.label11.Text = "Welcome";
            // 
            // welcomeUserName
            // 
            this.welcomeUserName.AutoSize = true;
            this.welcomeUserName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.welcomeUserName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeUserName.ForeColor = System.Drawing.Color.Crimson;
            this.welcomeUserName.Location = new System.Drawing.Point(146, 69);
            this.welcomeUserName.Name = "welcomeUserName";
            this.welcomeUserName.Size = new System.Drawing.Size(97, 24);
            this.welcomeUserName.TabIndex = 5;
            this.welcomeUserName.Text = "UserName";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(35, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1205, 148);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Take Test";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(677, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(259, 21);
            this.label15.TabIndex = 5;
            this.label15.Text = "2. Time Alloted is 20 Minutes Only.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(677, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(432, 21);
            this.label14.TabIndex = 4;
            this.label14.Text = "1. There are 20 MCQ\'s Question based on Subject Selected.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(583, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 21);
            this.label13.TabIndex = 3;
            this.label13.Text = "Paper Pattern : ";
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(290, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "Take Test Now!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(290, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 29);
            this.comboBox1.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 21);
            this.label12.TabIndex = 0;
            this.label12.Text = "Select Subject";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // StudentDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 810);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.welcomeUserName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StudentDashBoard";
            this.Text = "Student DashBoard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StudentDashBoard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtmobno;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtnewpwd;
        private System.Windows.Forms.TextBox txtconfirmnewpwd;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtoldpwd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkpwd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label welcomeUserName;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}