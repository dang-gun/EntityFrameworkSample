namespace OptimisticConcurrencyTest
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
            groupBox1 = new GroupBox();
            btnMssql_Use = new Button();
            txtMssql_ConnectStriong = new TextBox();
            label1 = new Label();
            radioMssqlUse = new RadioButton();
            groupBox2 = new GroupBox();
            btnSqlite_Use = new Button();
            txtSqlite_ConnectStriong = new TextBox();
            label2 = new Label();
            radioSqliteUse = new RadioButton();
            btnNotConcurrency = new Button();
            groupBox3 = new GroupBox();
            label4 = new Label();
            txtDb_TestOC1_Str = new TextBox();
            txtDb_TestOC1_Int = new TextBox();
            label3 = new Label();
            groupBox4 = new GroupBox();
            label5 = new Label();
            txtDb_TestOC2_Str = new TextBox();
            txtDb_TestOC2_Int = new TextBox();
            label6 = new Label();
            groupBox5 = new GroupBox();
            label7 = new Label();
            txtDb_TestOC3_Str = new TextBox();
            txtDb_TestOC3_Int = new TextBox();
            label8 = new Label();
            btnServerConcurrency = new Button();
            btnApplicationConcurrency = new Button();
            groupBox6 = new GroupBox();
            btnServerConcurrency2 = new Button();
            btnMultUpdate = new Button();
            groupBox7 = new GroupBox();
            btnMultUpdateFunc = new Button();
            groupBox8 = new GroupBox();
            label9 = new Label();
            txtDb_TestOC2_2_Str = new TextBox();
            txtDb_TestOC2_2_Int = new TextBox();
            label10 = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnMssql_Use);
            groupBox1.Controls.Add(txtMssql_ConnectStriong);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(radioMssqlUse);
            groupBox1.Location = new Point(12, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(381, 86);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "MSSQL";
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
            txtMssql_ConnectStriong.Size = new Size(263, 23);
            txtMssql_ConnectStriong.TabIndex = 2;
            txtMssql_ConnectStriong.Text = "Server=192.168.0.222;DataBase=LocalTest;UId=LocalTest_Login;pwd=asdf1234@";
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
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSqlite_Use);
            groupBox2.Controls.Add(txtSqlite_ConnectStriong);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(radioSqliteUse);
            groupBox2.Location = new Point(12, 101);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(381, 81);
            groupBox2.TabIndex = 0;
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
            txtSqlite_ConnectStriong.Size = new Size(265, 23);
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
            radioSqliteUse.Text = "Use";
            radioSqliteUse.UseVisualStyleBackColor = true;
            // 
            // btnNotConcurrency
            // 
            btnNotConcurrency.Location = new Point(6, 172);
            btnNotConcurrency.Name = "btnNotConcurrency";
            btnNotConcurrency.Size = new Size(154, 23);
            btnNotConcurrency.TabIndex = 1;
            btnNotConcurrency.Text = "없음 - TestOC3";
            btnNotConcurrency.UseVisualStyleBackColor = true;
            btnNotConcurrency.Click += btnNotConcurrency_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(txtDb_TestOC1_Str);
            groupBox3.Controls.Add(txtDb_TestOC1_Int);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(12, 432);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(123, 72);
            groupBox3.TabIndex = 2;
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
            txtDb_TestOC1_Str.Size = new Size(64, 23);
            txtDb_TestOC1_Str.TabIndex = 4;
            // 
            // txtDb_TestOC1_Int
            // 
            txtDb_TestOC1_Int.Location = new Point(53, 19);
            txtDb_TestOC1_Int.Name = "txtDb_TestOC1_Int";
            txtDb_TestOC1_Int.ReadOnly = true;
            txtDb_TestOC1_Int.Size = new Size(64, 23);
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
            // groupBox4
            // 
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(txtDb_TestOC2_Str);
            groupBox4.Controls.Add(txtDb_TestOC2_Int);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(141, 432);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(123, 72);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "DB - TestOC2";
            // 
            // label5
            // 
            label5.Location = new Point(6, 42);
            label5.Name = "label5";
            label5.Size = new Size(41, 23);
            label5.TabIndex = 4;
            label5.Text = "Str : ";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDb_TestOC2_Str
            // 
            txtDb_TestOC2_Str.Location = new Point(53, 42);
            txtDb_TestOC2_Str.Name = "txtDb_TestOC2_Str";
            txtDb_TestOC2_Str.ReadOnly = true;
            txtDb_TestOC2_Str.Size = new Size(64, 23);
            txtDb_TestOC2_Str.TabIndex = 4;
            // 
            // txtDb_TestOC2_Int
            // 
            txtDb_TestOC2_Int.Location = new Point(53, 19);
            txtDb_TestOC2_Int.Name = "txtDb_TestOC2_Int";
            txtDb_TestOC2_Int.ReadOnly = true;
            txtDb_TestOC2_Int.Size = new Size(64, 23);
            txtDb_TestOC2_Int.TabIndex = 4;
            // 
            // label6
            // 
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(41, 23);
            label6.TabIndex = 4;
            label6.Text = "Int : ";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(txtDb_TestOC3_Str);
            groupBox5.Controls.Add(txtDb_TestOC3_Int);
            groupBox5.Controls.Add(label8);
            groupBox5.Location = new Point(270, 432);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(123, 72);
            groupBox5.TabIndex = 2;
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
            txtDb_TestOC3_Str.Size = new Size(64, 23);
            txtDb_TestOC3_Str.TabIndex = 4;
            // 
            // txtDb_TestOC3_Int
            // 
            txtDb_TestOC3_Int.Location = new Point(53, 19);
            txtDb_TestOC3_Int.Name = "txtDb_TestOC3_Int";
            txtDb_TestOC3_Int.ReadOnly = true;
            txtDb_TestOC3_Int.Size = new Size(64, 23);
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
            // btnServerConcurrency
            // 
            btnServerConcurrency.Location = new Point(6, 51);
            btnServerConcurrency.Name = "btnServerConcurrency";
            btnServerConcurrency.Size = new Size(154, 23);
            btnServerConcurrency.TabIndex = 3;
            btnServerConcurrency.Text = "서버 - TestOC2";
            btnServerConcurrency.UseVisualStyleBackColor = true;
            btnServerConcurrency.Click += btnServerConcurrency_Click;
            // 
            // btnApplicationConcurrency
            // 
            btnApplicationConcurrency.Location = new Point(6, 22);
            btnApplicationConcurrency.Name = "btnApplicationConcurrency";
            btnApplicationConcurrency.Size = new Size(154, 23);
            btnApplicationConcurrency.TabIndex = 4;
            btnApplicationConcurrency.Text = "애플리케이션 - TestOC1";
            btnApplicationConcurrency.UseVisualStyleBackColor = true;
            btnApplicationConcurrency.Click += btnApplicationConcurrency_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnApplicationConcurrency);
            groupBox6.Controls.Add(btnServerConcurrency2);
            groupBox6.Controls.Add(btnNotConcurrency);
            groupBox6.Controls.Add(btnServerConcurrency);
            groupBox6.Location = new Point(12, 188);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(173, 214);
            groupBox6.TabIndex = 5;
            groupBox6.TabStop = false;
            groupBox6.Text = "동시성 처리 방식";
            // 
            // btnServerConcurrency2
            // 
            btnServerConcurrency2.Location = new Point(6, 143);
            btnServerConcurrency2.Name = "btnServerConcurrency2";
            btnServerConcurrency2.Size = new Size(154, 23);
            btnServerConcurrency2.TabIndex = 6;
            btnServerConcurrency2.Text = "서버 - TestOC2 - 함수화";
            btnServerConcurrency2.UseVisualStyleBackColor = true;
            btnServerConcurrency2.Click += btnServerConcurrency2_Click;
            // 
            // btnMultUpdate
            // 
            btnMultUpdate.Location = new Point(7, 22);
            btnMultUpdate.Name = "btnMultUpdate";
            btnMultUpdate.Size = new Size(189, 23);
            btnMultUpdate.TabIndex = 6;
            btnMultUpdate.Text = "구현 테스트 - TestOC2";
            btnMultUpdate.UseVisualStyleBackColor = true;
            btnMultUpdate.Click += btnMultUpdate_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(button1);
            groupBox7.Controls.Add(btnMultUpdateFunc);
            groupBox7.Controls.Add(btnMultUpdate);
            groupBox7.Location = new Point(194, 188);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(202, 214);
            groupBox7.TabIndex = 7;
            groupBox7.TabStop = false;
            groupBox7.Text = "여러개 업데이트";
            // 
            // btnMultUpdateFunc
            // 
            btnMultUpdateFunc.Location = new Point(7, 51);
            btnMultUpdateFunc.Name = "btnMultUpdateFunc";
            btnMultUpdateFunc.Size = new Size(189, 61);
            btnMultUpdateFunc.TabIndex = 7;
            btnMultUpdateFunc.Text = "공통화 함수 - TestOC2\r\n각자 컨택스트 생성하여 처리함\r\n(순차 처리 동기)";
            btnMultUpdateFunc.UseVisualStyleBackColor = true;
            btnMultUpdateFunc.Click += btnMultUpdateFunc_Click;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(label9);
            groupBox8.Controls.Add(txtDb_TestOC2_2_Str);
            groupBox8.Controls.Add(txtDb_TestOC2_2_Int);
            groupBox8.Controls.Add(label10);
            groupBox8.Location = new Point(141, 510);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(123, 72);
            groupBox8.TabIndex = 2;
            groupBox8.TabStop = false;
            groupBox8.Text = "DB - TestOC2 - 2";
            // 
            // label9
            // 
            label9.Location = new Point(6, 42);
            label9.Name = "label9";
            label9.Size = new Size(41, 23);
            label9.TabIndex = 4;
            label9.Text = "Str : ";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDb_TestOC2_2_Str
            // 
            txtDb_TestOC2_2_Str.Location = new Point(53, 42);
            txtDb_TestOC2_2_Str.Name = "txtDb_TestOC2_2_Str";
            txtDb_TestOC2_2_Str.ReadOnly = true;
            txtDb_TestOC2_2_Str.Size = new Size(64, 23);
            txtDb_TestOC2_2_Str.TabIndex = 4;
            // 
            // txtDb_TestOC2_2_Int
            // 
            txtDb_TestOC2_2_Int.Location = new Point(53, 19);
            txtDb_TestOC2_2_Int.Name = "txtDb_TestOC2_2_Int";
            txtDb_TestOC2_2_Int.ReadOnly = true;
            txtDb_TestOC2_2_Int.Size = new Size(64, 23);
            txtDb_TestOC2_2_Int.TabIndex = 4;
            // 
            // label10
            // 
            label10.Location = new Point(6, 19);
            label10.Name = "label10";
            label10.Size = new Size(41, 23);
            label10.TabIndex = 4;
            label10.Text = "Int : ";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.Location = new Point(7, 118);
            button1.Name = "button1";
            button1.Size = new Size(189, 66);
            button1.TabIndex = 8;
            button1.Text = "공통화 함수 - TestOC2\r\n각자 컨택스트를 생성하여 처리\r\n저장 실패 리스트를 뒤로 보냄";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 590);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox8);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radioMssqlUse;
        private GroupBox groupBox2;
        private RadioButton radioSqliteUse;
        private Label label1;
        private TextBox txtMssql_ConnectStriong;
        private TextBox txtSqlite_ConnectStriong;
        private Label label2;
        private Button btnNotConcurrency;
        private Button btnMssql_Use;
        private Button btnSqlite_Use;
        private GroupBox groupBox3;
        private Label label4;
        private TextBox txtDb_TestOC1_Str;
        private TextBox txtDb_TestOC1_Int;
        private Label label3;
        private GroupBox groupBox4;
        private Label label5;
        private TextBox txtDb_TestOC2_Str;
        private TextBox txtDb_TestOC2_Int;
        private Label label6;
        private GroupBox groupBox5;
        private Label label7;
        private TextBox txtDb_TestOC3_Str;
        private TextBox txtDb_TestOC3_Int;
        private Label label8;
        private Button btnServerConcurrency;
        private Button btnApplicationConcurrency;
        private GroupBox groupBox6;
        private Button btnServerConcurrency2;
        private Button btnMultUpdate;
        private GroupBox groupBox7;
        private Button btnMultUpdateFunc;
        private GroupBox groupBox8;
        private Label label9;
        private TextBox txtDb_TestOC2_2_Str;
        private TextBox txtDb_TestOC2_2_Int;
        private Label label10;
        private Button button1;
    }
}