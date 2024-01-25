namespace EfAnalyze.Forms
{
    partial class DbInfoForm
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
            groupBox5 = new GroupBox();
            label7 = new Label();
            txtDb_TestOC3_Str = new TextBox();
            txtDb_TestOC3_Int = new TextBox();
            label8 = new Label();
            groupBox3 = new GroupBox();
            label4 = new Label();
            txtDb_TestOC1_Str = new TextBox();
            txtDb_TestOC1_Int = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            btnSqlite_Use = new Button();
            txtSqlite_ConnectStriong = new TextBox();
            label2 = new Label();
            radioSqliteUse = new RadioButton();
            groupBox6 = new GroupBox();
            btnMssql_Use = new Button();
            txtMssql_ConnectStriong = new TextBox();
            label1 = new Label();
            radioMssqlUse = new RadioButton();
            groupBox5.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(txtDb_TestOC3_Str);
            groupBox5.Controls.Add(txtDb_TestOC3_Int);
            groupBox5.Controls.Add(label8);
            groupBox5.Location = new Point(12, 269);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(232, 72);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "DB - TestOC3";
            // 
            // label7
            // 
            label7.Location = new Point(6, 42);
            label7.Name = "label7";
            label7.Size = new Size(41, 23);
            label7.TabIndex = 4;
            label7.Text = "Str : ";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDb_TestOC3_Str
            // 
            txtDb_TestOC3_Str.Location = new Point(53, 42);
            txtDb_TestOC3_Str.Name = "txtDb_TestOC3_Str";
            txtDb_TestOC3_Str.ReadOnly = true;
            txtDb_TestOC3_Str.Size = new Size(173, 23);
            txtDb_TestOC3_Str.TabIndex = 4;
            // 
            // txtDb_TestOC3_Int
            // 
            txtDb_TestOC3_Int.Location = new Point(53, 19);
            txtDb_TestOC3_Int.Name = "txtDb_TestOC3_Int";
            txtDb_TestOC3_Int.ReadOnly = true;
            txtDb_TestOC3_Int.Size = new Size(173, 23);
            txtDb_TestOC3_Int.TabIndex = 4;
            // 
            // label8
            // 
            label8.Location = new Point(6, 19);
            label8.Name = "label8";
            label8.Size = new Size(41, 23);
            label8.TabIndex = 4;
            label8.Text = "Int : ";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(txtDb_TestOC1_Str);
            groupBox3.Controls.Add(txtDb_TestOC1_Int);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(12, 191);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(232, 72);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "DB - TestOC1";
            // 
            // label4
            // 
            label4.Location = new Point(6, 42);
            label4.Name = "label4";
            label4.Size = new Size(41, 23);
            label4.TabIndex = 4;
            label4.Text = "Str : ";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDb_TestOC1_Str
            // 
            txtDb_TestOC1_Str.Location = new Point(53, 42);
            txtDb_TestOC1_Str.Name = "txtDb_TestOC1_Str";
            txtDb_TestOC1_Str.ReadOnly = true;
            txtDb_TestOC1_Str.Size = new Size(173, 23);
            txtDb_TestOC1_Str.TabIndex = 4;
            // 
            // txtDb_TestOC1_Int
            // 
            txtDb_TestOC1_Int.Location = new Point(53, 19);
            txtDb_TestOC1_Int.Name = "txtDb_TestOC1_Int";
            txtDb_TestOC1_Int.ReadOnly = true;
            txtDb_TestOC1_Int.Size = new Size(173, 23);
            txtDb_TestOC1_Int.TabIndex = 4;
            // 
            // label3
            // 
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(41, 23);
            label3.TabIndex = 4;
            label3.Text = "Int : ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSqlite_Use);
            groupBox2.Controls.Add(txtSqlite_ConnectStriong);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(radioSqliteUse);
            groupBox2.Location = new Point(12, 104);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(232, 81);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "SQLite";
            // 
            // btnSqlite_Use
            // 
            btnSqlite_Use.Location = new Point(56, 20);
            btnSqlite_Use.Name = "btnSqlite_Use";
            btnSqlite_Use.Size = new Size(75, 23);
            btnSqlite_Use.TabIndex = 3;
            btnSqlite_Use.Text = "사용 시작";
            btnSqlite_Use.UseVisualStyleBackColor = true;
            btnSqlite_Use.Click += btnSqlite_Use_Click;
            // 
            // txtSqlite_ConnectStriong
            // 
            txtSqlite_ConnectStriong.Location = new Point(110, 45);
            txtSqlite_ConnectStriong.Name = "txtSqlite_ConnectStriong";
            txtSqlite_ConnectStriong.Size = new Size(116, 23);
            txtSqlite_ConnectStriong.TabIndex = 4;
            txtSqlite_ConnectStriong.Text = "Data Source=Test.db";
            // 
            // label2
            // 
            label2.Location = new Point(4, 44);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 3;
            label2.Text = "Connect String : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // radioSqliteUse
            // 
            radioSqliteUse.AutoSize = true;
            radioSqliteUse.Enabled = false;
            radioSqliteUse.Location = new Point(6, 22);
            radioSqliteUse.Name = "radioSqliteUse";
            radioSqliteUse.Size = new Size(44, 19);
            radioSqliteUse.TabIndex = 1;
            radioSqliteUse.TabStop = true;
            radioSqliteUse.Text = "Use";
            radioSqliteUse.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnMssql_Use);
            groupBox6.Controls.Add(txtMssql_ConnectStriong);
            groupBox6.Controls.Add(label1);
            groupBox6.Controls.Add(radioMssqlUse);
            groupBox6.Location = new Point(12, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(232, 86);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "MSSQL";
            // 
            // btnMssql_Use
            // 
            btnMssql_Use.Location = new Point(56, 20);
            btnMssql_Use.Name = "btnMssql_Use";
            btnMssql_Use.Size = new Size(75, 23);
            btnMssql_Use.TabIndex = 3;
            btnMssql_Use.Text = "사용 시작";
            btnMssql_Use.UseVisualStyleBackColor = true;
            btnMssql_Use.Click += btnMssql_Use_Click;
            // 
            // txtMssql_ConnectStriong
            // 
            txtMssql_ConnectStriong.Location = new Point(112, 45);
            txtMssql_ConnectStriong.Name = "txtMssql_ConnectStriong";
            txtMssql_ConnectStriong.Size = new Size(114, 23);
            txtMssql_ConnectStriong.TabIndex = 2;
            txtMssql_ConnectStriong.Text = "Server=192.168.0.222,5501;DataBase=LocalTest;UId=LocalTest_Login;pwd=asdf1234@";
            // 
            // label1
            // 
            label1.Location = new Point(6, 44);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 1;
            label1.Text = "Connect String : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // radioMssqlUse
            // 
            radioMssqlUse.AutoSize = true;
            radioMssqlUse.Checked = true;
            radioMssqlUse.Enabled = false;
            radioMssqlUse.Location = new Point(6, 22);
            radioMssqlUse.Name = "radioMssqlUse";
            radioMssqlUse.Size = new Size(44, 19);
            radioMssqlUse.TabIndex = 0;
            radioMssqlUse.TabStop = true;
            radioMssqlUse.Text = "Use";
            radioMssqlUse.UseVisualStyleBackColor = true;
            // 
            // DbInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 344);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DbInfoForm";
            Text = "DB Info";
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox5;
        private Label label7;
        private TextBox txtDb_TestOC3_Str;
        private TextBox txtDb_TestOC3_Int;
        private Label label8;
        private GroupBox groupBox3;
        private Label label4;
        private TextBox txtDb_TestOC1_Str;
        private TextBox txtDb_TestOC1_Int;
        private Label label3;
        private GroupBox groupBox2;
        private Button btnSqlite_Use;
        private TextBox txtSqlite_ConnectStriong;
        private Label label2;
        private RadioButton radioSqliteUse;
        private GroupBox groupBox6;
        private Button btnMssql_Use;
        private TextBox txtMssql_ConnectStriong;
        private Label label1;
        private RadioButton radioMssqlUse;
    }
}