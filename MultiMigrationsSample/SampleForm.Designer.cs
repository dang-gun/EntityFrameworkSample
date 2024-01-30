namespace MultiMigrationsSample
{
    partial class SampleForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            radioMssql = new RadioButton();
            radioSqlite = new RadioButton();
            txtDbData1Model_Log = new TextBox();
            panel1 = new Panel();
            btnSelectAll = new Button();
            groupBox2 = new GroupBox();
            panel2 = new Panel();
            btnDbData1Model_Add = new Button();
            label2 = new Label();
            label1 = new Label();
            txtDbData1Model_Age = new TextBox();
            txtDbData1Model_Name = new TextBox();
            groupBox3 = new GroupBox();
            panel3 = new Panel();
            btnDbData2Model_Add = new Button();
            label3 = new Label();
            label4 = new Label();
            txtDbData2Model_LastName = new TextBox();
            txtDbData2Model_FirstName = new TextBox();
            txtDbData2Model_Log = new TextBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioMssql);
            groupBox1.Controls.Add(radioSqlite);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(134, 47);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "DB Select";
            // 
            // radioMssql
            // 
            radioMssql.AutoSize = true;
            radioMssql.Location = new Point(67, 22);
            radioMssql.Name = "radioMssql";
            radioMssql.Size = new Size(65, 19);
            radioMssql.TabIndex = 1;
            radioMssql.Text = "MSSQL";
            radioMssql.UseVisualStyleBackColor = true;
            radioMssql.CheckedChanged += radioMssql_CheckedChanged;
            // 
            // radioSqlite
            // 
            radioSqlite.AutoSize = true;
            radioSqlite.Checked = true;
            radioSqlite.Location = new Point(6, 22);
            radioSqlite.Name = "radioSqlite";
            radioSqlite.Size = new Size(55, 19);
            radioSqlite.TabIndex = 0;
            radioSqlite.TabStop = true;
            radioSqlite.Text = "Sqlite";
            radioSqlite.UseVisualStyleBackColor = true;
            radioSqlite.CheckedChanged += radioSqlite_CheckedChanged;
            // 
            // txtDbData1Model_Log
            // 
            txtDbData1Model_Log.Location = new Point(6, 73);
            txtDbData1Model_Log.Multiline = true;
            txtDbData1Model_Log.Name = "txtDbData1Model_Log";
            txtDbData1Model_Log.ScrollBars = ScrollBars.Both;
            txtDbData1Model_Log.Size = new Size(387, 137);
            txtDbData1Model_Log.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSelectAll);
            panel1.Location = new Point(152, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 37);
            panel1.TabIndex = 2;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(3, 8);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(75, 23);
            btnSelectAll.TabIndex = 0;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(txtDbData1Model_Log);
            groupBox2.Location = new Point(12, 65);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 221);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "DbData1Model";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDbData1Model_Add);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtDbData1Model_Age);
            panel2.Controls.Add(txtDbData1Model_Name);
            panel2.Location = new Point(6, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(387, 45);
            panel2.TabIndex = 3;
            // 
            // btnDbData1Model_Add
            // 
            btnDbData1Model_Add.Location = new Point(319, 13);
            btnDbData1Model_Add.Name = "btnDbData1Model_Add";
            btnDbData1Model_Add.Size = new Size(53, 23);
            btnDbData1Model_Add.TabIndex = 5;
            btnDbData1Model_Add.Text = "Add";
            btnDbData1Model_Add.UseVisualStyleBackColor = true;
            btnDbData1Model_Add.Click += btnDbData1Model_Add_Click;
            // 
            // label2
            // 
            label2.Location = new Point(180, 12);
            label2.Name = "label2";
            label2.Size = new Size(61, 23);
            label2.TabIndex = 4;
            label2.Text = "Age : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Location = new Point(7, 12);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 3;
            label1.Text = "Name : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDbData1Model_Age
            // 
            txtDbData1Model_Age.Location = new Point(247, 13);
            txtDbData1Model_Age.Name = "txtDbData1Model_Age";
            txtDbData1Model_Age.Size = new Size(63, 23);
            txtDbData1Model_Age.TabIndex = 2;
            // 
            // txtDbData1Model_Name
            // 
            txtDbData1Model_Name.Location = new Point(74, 13);
            txtDbData1Model_Name.Name = "txtDbData1Model_Name";
            txtDbData1Model_Name.Size = new Size(100, 23);
            txtDbData1Model_Name.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel3);
            groupBox3.Controls.Add(txtDbData2Model_Log);
            groupBox3.Location = new Point(12, 292);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(400, 221);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "DbData2Model";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnDbData2Model_Add);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtDbData2Model_LastName);
            panel3.Controls.Add(txtDbData2Model_FirstName);
            panel3.Location = new Point(6, 22);
            panel3.Name = "panel3";
            panel3.Size = new Size(387, 45);
            panel3.TabIndex = 3;
            // 
            // btnDbData2Model_Add
            // 
            btnDbData2Model_Add.Location = new Point(319, 13);
            btnDbData2Model_Add.Name = "btnDbData2Model_Add";
            btnDbData2Model_Add.Size = new Size(53, 23);
            btnDbData2Model_Add.TabIndex = 5;
            btnDbData2Model_Add.Text = "Add";
            btnDbData2Model_Add.UseVisualStyleBackColor = true;
            btnDbData2Model_Add.Click += btnDbData2Model_Add_Click;
            // 
            // label3
            // 
            label3.Location = new Point(180, 7);
            label3.Name = "label3";
            label3.Size = new Size(61, 33);
            label3.TabIndex = 4;
            label3.Text = "Last   \r\nName : ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new Point(7, 7);
            label4.Name = "label4";
            label4.Size = new Size(61, 33);
            label4.TabIndex = 3;
            label4.Text = "First   \r\nName : ";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDbData2Model_LastName
            // 
            txtDbData2Model_LastName.Location = new Point(242, 13);
            txtDbData2Model_LastName.Name = "txtDbData2Model_LastName";
            txtDbData2Model_LastName.Size = new Size(70, 23);
            txtDbData2Model_LastName.TabIndex = 2;
            // 
            // txtDbData2Model_FirstName
            // 
            txtDbData2Model_FirstName.Location = new Point(74, 13);
            txtDbData2Model_FirstName.Name = "txtDbData2Model_FirstName";
            txtDbData2Model_FirstName.Size = new Size(100, 23);
            txtDbData2Model_FirstName.TabIndex = 2;
            // 
            // txtDbData2Model_Log
            // 
            txtDbData2Model_Log.Location = new Point(6, 73);
            txtDbData2Model_Log.Multiline = true;
            txtDbData2Model_Log.Name = "txtDbData2Model_Log";
            txtDbData2Model_Log.ScrollBars = ScrollBars.Both;
            txtDbData2Model_Log.Size = new Size(387, 137);
            txtDbData2Model_Log.TabIndex = 1;
            // 
            // SampleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 523);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SampleForm";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radioMssql;
        private RadioButton radioSqlite;
        private TextBox txtDbData1Model_Log;
        private Panel panel1;
        private Button btnSelectAll;
        private GroupBox groupBox2;
        private Panel panel2;
        private Button btnDbData1Model_Add;
        private Label label2;
        private Label label1;
        private TextBox txtDbData1Model_Age;
        private TextBox txtDbData1Model_Name;
        private GroupBox groupBox3;
        private Panel panel3;
        private Button btnDbData2Model_Add;
        private Label label3;
        private Label label4;
        private TextBox txtDbData2Model_LastName;
        private TextBox txtDbData2Model_FirstName;
        private TextBox txtDbData2Model_Log;
    }
}
