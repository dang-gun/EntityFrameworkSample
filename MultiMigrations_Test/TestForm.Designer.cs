namespace MultiMigrations_Test
{
    partial class TestForm
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
            btnDbData2Model_Add = new Button();
            label2 = new Label();
            txtDbData2Model_Index = new TextBox();
            groupBox2 = new GroupBox();
            panel2 = new Panel();
            btnDbData1Model_Add = new Button();
            panel1 = new Panel();
            btnSelectAll = new Button();
            txtDbData1Model_Log = new TextBox();
            radioMssql = new RadioButton();
            radioSqlite = new RadioButton();
            groupBox1 = new GroupBox();
            radioInMemory = new RadioButton();
            radioPostgresql = new RadioButton();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDbData2Model_Add
            // 
            btnDbData2Model_Add.Location = new Point(325, 4);
            btnDbData2Model_Add.Name = "btnDbData2Model_Add";
            btnDbData2Model_Add.Size = new Size(53, 23);
            btnDbData2Model_Add.TabIndex = 5;
            btnDbData2Model_Add.Text = "Add";
            btnDbData2Model_Add.UseVisualStyleBackColor = true;
            btnDbData2Model_Add.Click += btnDbData2Model_Add_Click;
            // 
            // label2
            // 
            label2.Location = new Point(160, 3);
            label2.Name = "label2";
            label2.Size = new Size(90, 23);
            label2.TabIndex = 4;
            label2.Text = "Parent Index : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDbData2Model_Index
            // 
            txtDbData2Model_Index.Location = new Point(256, 4);
            txtDbData2Model_Index.Name = "txtDbData2Model_Index";
            txtDbData2Model_Index.Size = new Size(63, 23);
            txtDbData2Model_Index.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(panel1);
            groupBox2.Location = new Point(8, 60);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 91);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDbData1Model_Add);
            panel2.Controls.Add(btnDbData2Model_Add);
            panel2.Controls.Add(txtDbData2Model_Index);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(6, 51);
            panel2.Name = "panel2";
            panel2.Size = new Size(387, 30);
            panel2.TabIndex = 3;
            // 
            // btnDbData1Model_Add
            // 
            btnDbData1Model_Add.Location = new Point(3, 3);
            btnDbData1Model_Add.Name = "btnDbData1Model_Add";
            btnDbData1Model_Add.Size = new Size(151, 23);
            btnDbData1Model_Add.TabIndex = 5;
            btnDbData1Model_Add.Text = "DbData1Model Add";
            btnDbData1Model_Add.UseVisualStyleBackColor = true;
            btnDbData1Model_Add.Click += btnDbData1Model_Add_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSelectAll);
            panel1.Location = new Point(6, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(387, 29);
            panel1.TabIndex = 6;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(3, 3);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(75, 23);
            btnSelectAll.TabIndex = 0;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // txtDbData1Model_Log
            // 
            txtDbData1Model_Log.Location = new Point(8, 157);
            txtDbData1Model_Log.Multiline = true;
            txtDbData1Model_Log.Name = "txtDbData1Model_Log";
            txtDbData1Model_Log.ScrollBars = ScrollBars.Both;
            txtDbData1Model_Log.Size = new Size(400, 388);
            txtDbData1Model_Log.TabIndex = 1;
            txtDbData1Model_Log.WordWrap = false;
            // 
            // radioMssql
            // 
            radioMssql.AutoSize = true;
            radioMssql.Location = new Point(151, 18);
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
            radioSqlite.Location = new Point(90, 18);
            radioSqlite.Name = "radioSqlite";
            radioSqlite.Size = new Size(60, 19);
            radioSqlite.TabIndex = 0;
            radioSqlite.Text = "SQLite";
            radioSqlite.UseVisualStyleBackColor = true;
            radioSqlite.CheckedChanged += radioSqlite_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioPostgresql);
            groupBox1.Controls.Add(radioInMemory);
            groupBox1.Controls.Add(radioMssql);
            groupBox1.Controls.Add(radioSqlite);
            groupBox1.Location = new Point(8, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 47);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "DB Select";
            // 
            // radioInMemory
            // 
            radioInMemory.AutoSize = true;
            radioInMemory.Checked = true;
            radioInMemory.Location = new Point(4, 18);
            radioInMemory.Name = "radioInMemory";
            radioInMemory.Size = new Size(80, 19);
            radioInMemory.TabIndex = 2;
            radioInMemory.TabStop = true;
            radioInMemory.Text = "InMemory";
            radioInMemory.UseVisualStyleBackColor = true;
            radioInMemory.CheckedChanged += radioInMemory_CheckedChanged;
            // 
            // radioPostgresql
            // 
            radioPostgresql.AutoSize = true;
            radioPostgresql.Location = new Point(222, 18);
            radioPostgresql.Name = "radioPostgresql";
            radioPostgresql.Size = new Size(87, 19);
            radioPostgresql.TabIndex = 3;
            radioPostgresql.Text = "PostgreSQL";
            radioPostgresql.UseVisualStyleBackColor = true;
            radioPostgresql.CheckedChanged += radioPostgresql_CheckedChanged;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 557);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtDbData1Model_Log);
            Name = "TestForm";
            Text = "Form1";
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDbData1Model_Add;
        private Label label2;
        private Label label1;
        private TextBox txtDbData2Model_Index;
        private TextBox txtDbData1Model_Name;
        private GroupBox groupBox2;
        private Panel panel2;
        private TextBox txtDbData1Model_Log;
        private Button btnSelectAll;
        private Panel panel1;
        private RadioButton radioMssql;
        private RadioButton radioSqlite;
        private GroupBox groupBox1;
        private RadioButton radioInMemory;
        private Panel panel3;
        private Button button1;
        private TextBox textBox1;
        private Button btnDbData2Model_Add;
        private RadioButton radioPostgresql;
    }
}
