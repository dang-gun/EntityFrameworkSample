namespace MultiMigrations_Test
{
    partial class Form1
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
            btnDbData1Model_Add = new Button();
            label2 = new Label();
            label1 = new Label();
            txtDbData1Model_Age = new TextBox();
            txtDbData1Model_Name = new TextBox();
            groupBox2 = new GroupBox();
            panel2 = new Panel();
            panel1 = new Panel();
            btnSelectAll = new Button();
            txtDbData1Model_Log = new TextBox();
            radioMssql = new RadioButton();
            radioSqlite = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDbData1Model_Add
            // 
            btnDbData1Model_Add.Location = new Point(319, 13);
            btnDbData1Model_Add.Name = "btnDbData1Model_Add";
            btnDbData1Model_Add.Size = new Size(53, 23);
            btnDbData1Model_Add.TabIndex = 5;
            btnDbData1Model_Add.Text = "Add";
            btnDbData1Model_Add.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(panel1);
            groupBox2.Controls.Add(txtDbData1Model_Log);
            groupBox2.Location = new Point(8, 60);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 264);
            groupBox2.TabIndex = 7;
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
            panel2.Location = new Point(6, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(387, 45);
            panel2.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSelectAll);
            panel1.Location = new Point(6, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(387, 37);
            panel1.TabIndex = 6;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(3, 8);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(75, 23);
            btnSelectAll.TabIndex = 0;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // txtDbData1Model_Log
            // 
            txtDbData1Model_Log.Location = new Point(6, 119);
            txtDbData1Model_Log.Multiline = true;
            txtDbData1Model_Log.Name = "txtDbData1Model_Log";
            txtDbData1Model_Log.ScrollBars = ScrollBars.Both;
            txtDbData1Model_Log.Size = new Size(387, 137);
            txtDbData1Model_Log.TabIndex = 1;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(radioMssql);
            groupBox1.Controls.Add(radioSqlite);
            groupBox1.Location = new Point(8, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 47);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "DB Select";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 333);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnDbData1Model_Add;
        private Label label2;
        private Label label1;
        private TextBox txtDbData1Model_Age;
        private TextBox txtDbData1Model_Name;
        private GroupBox groupBox2;
        private Panel panel2;
        private TextBox txtDbData1Model_Log;
        private Button btnSelectAll;
        private Panel panel1;
        private RadioButton radioMssql;
        private RadioButton radioSqlite;
        private GroupBox groupBox1;
    }
}
