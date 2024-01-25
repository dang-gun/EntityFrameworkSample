namespace EfAnalyze.Forms
{
    partial class OptimisticConcurrencyForm
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
            groupBox7 = new GroupBox();
            btnMultUpdate_MultContext_Select = new Button();
            btnMultUpdate_MultContext = new Button();
            btnMultUpdateFunc = new Button();
            btnMultUpdateNoOc = new Button();
            btnMultUpdate = new Button();
            groupBox6 = new GroupBox();
            btnApplicationConcurrency = new Button();
            btnNoOc = new Button();
            btnServerConcurrency2 = new Button();
            btnOneColumn = new Button();
            btnNotConcurrency = new Button();
            btnServerConcurrency = new Button();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(btnMultUpdate_MultContext_Select);
            groupBox7.Controls.Add(btnMultUpdate_MultContext);
            groupBox7.Controls.Add(btnMultUpdateFunc);
            groupBox7.Controls.Add(btnMultUpdateNoOc);
            groupBox7.Controls.Add(btnMultUpdate);
            groupBox7.Location = new Point(186, 12);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(206, 185);
            groupBox7.TabIndex = 9;
            groupBox7.TabStop = false;
            groupBox7.Text = "여러줄 업데이트";
            // 
            // btnMultUpdate_MultContext_Select
            // 
            btnMultUpdate_MultContext_Select.Location = new Point(6, 155);
            btnMultUpdate_MultContext_Select.Name = "btnMultUpdate_MultContext_Select";
            btnMultUpdate_MultContext_Select.Size = new Size(189, 23);
            btnMultUpdate_MultContext_Select.TabIndex = 7;
            btnMultUpdate_MultContext_Select.Text = "DB 컨택스트 생성(Select)";
            btnMultUpdate_MultContext_Select.UseVisualStyleBackColor = true;
            btnMultUpdate_MultContext_Select.Click += btnMultUpdate_MultContext_Select_Click;
            // 
            // btnMultUpdate_MultContext
            // 
            btnMultUpdate_MultContext.Location = new Point(6, 126);
            btnMultUpdate_MultContext.Name = "btnMultUpdate_MultContext";
            btnMultUpdate_MultContext.Size = new Size(189, 23);
            btnMultUpdate_MultContext.TabIndex = 7;
            btnMultUpdate_MultContext.Text = "DB 컨택스트 생성";
            btnMultUpdate_MultContext.UseVisualStyleBackColor = true;
            btnMultUpdate_MultContext.Click += btnMultUpdate_MultContext_Click;
            // 
            // btnMultUpdateFunc
            // 
            btnMultUpdateFunc.Location = new Point(6, 80);
            btnMultUpdateFunc.Name = "btnMultUpdateFunc";
            btnMultUpdateFunc.Size = new Size(189, 23);
            btnMultUpdateFunc.TabIndex = 7;
            btnMultUpdateFunc.Text = "공통화 함수(테스트중)";
            btnMultUpdateFunc.UseVisualStyleBackColor = true;
            btnMultUpdateFunc.Click += btnMultUpdateFunc_Click;
            // 
            // btnMultUpdateNoOc
            // 
            btnMultUpdateNoOc.Location = new Point(6, 22);
            btnMultUpdateNoOc.Name = "btnMultUpdateNoOc";
            btnMultUpdateNoOc.Size = new Size(189, 23);
            btnMultUpdateNoOc.TabIndex = 6;
            btnMultUpdateNoOc.Text = "동시성 없음";
            btnMultUpdateNoOc.UseVisualStyleBackColor = true;
            btnMultUpdateNoOc.Click += btnMultUpdateNoOc_Click;
            // 
            // btnMultUpdate
            // 
            btnMultUpdate.Location = new Point(6, 51);
            btnMultUpdate.Name = "btnMultUpdate";
            btnMultUpdate.Size = new Size(189, 23);
            btnMultUpdate.TabIndex = 6;
            btnMultUpdate.Text = "구현 테스트";
            btnMultUpdate.UseVisualStyleBackColor = true;
            btnMultUpdate.Click += btnMultUpdate_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnApplicationConcurrency);
            groupBox6.Controls.Add(btnNoOc);
            groupBox6.Controls.Add(btnServerConcurrency2);
            groupBox6.Controls.Add(btnOneColumn);
            groupBox6.Controls.Add(btnNotConcurrency);
            groupBox6.Controls.Add(btnServerConcurrency);
            groupBox6.Location = new Point(12, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(168, 231);
            groupBox6.TabIndex = 8;
            groupBox6.TabStop = false;
            groupBox6.Text = "동시성 처리 방식";
            // 
            // btnApplicationConcurrency
            // 
            btnApplicationConcurrency.Location = new Point(6, 51);
            btnApplicationConcurrency.Name = "btnApplicationConcurrency";
            btnApplicationConcurrency.Size = new Size(154, 23);
            btnApplicationConcurrency.TabIndex = 4;
            btnApplicationConcurrency.Text = "애플리케이션 - TestOC1";
            btnApplicationConcurrency.UseVisualStyleBackColor = true;
            btnApplicationConcurrency.Click += btnApplicationConcurrency_Click;
            // 
            // btnNoOc
            // 
            btnNoOc.Location = new Point(6, 22);
            btnNoOc.Name = "btnNoOc";
            btnNoOc.Size = new Size(154, 23);
            btnNoOc.TabIndex = 6;
            btnNoOc.Text = "동시성 없음 - 에러";
            btnNoOc.UseVisualStyleBackColor = true;
            btnNoOc.Click += btnNoOc_Click;
            // 
            // btnServerConcurrency2
            // 
            btnServerConcurrency2.Location = new Point(6, 109);
            btnServerConcurrency2.Name = "btnServerConcurrency2";
            btnServerConcurrency2.Size = new Size(154, 23);
            btnServerConcurrency2.TabIndex = 6;
            btnServerConcurrency2.Text = "서버 - TestOC2 - 함수화";
            btnServerConcurrency2.UseVisualStyleBackColor = true;
            btnServerConcurrency2.Click += btnServerConcurrency2_Click;
            // 
            // btnOneColumn
            // 
            btnOneColumn.Location = new Point(6, 179);
            btnOneColumn.Name = "btnOneColumn";
            btnOneColumn.Size = new Size(154, 42);
            btnOneColumn.TabIndex = 1;
            btnOneColumn.Text = "한개 씩 컬럼 업데이트 - TestOC2";
            btnOneColumn.UseVisualStyleBackColor = true;
            btnOneColumn.Click += btnOneColumn_Click;
            // 
            // btnNotConcurrency
            // 
            btnNotConcurrency.Location = new Point(6, 138);
            btnNotConcurrency.Name = "btnNotConcurrency";
            btnNotConcurrency.Size = new Size(154, 23);
            btnNotConcurrency.TabIndex = 1;
            btnNotConcurrency.Text = "없음 - TestOC3";
            btnNotConcurrency.UseVisualStyleBackColor = true;
            btnNotConcurrency.Click += btnNotConcurrency_Click;
            // 
            // btnServerConcurrency
            // 
            btnServerConcurrency.Location = new Point(6, 80);
            btnServerConcurrency.Name = "btnServerConcurrency";
            btnServerConcurrency.Size = new Size(154, 23);
            btnServerConcurrency.TabIndex = 3;
            btnServerConcurrency.Text = "서버 - TestOC2";
            btnServerConcurrency.UseVisualStyleBackColor = true;
            btnServerConcurrency.Click += btnServerConcurrency_Click;
            // 
            // OptimisticConcurrencyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 264);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OptimisticConcurrencyForm";
            Text = "OptimisticConcurrencyForm";
            groupBox7.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox7;
        private Button btnMultUpdateFunc;
        private Button btnMultUpdate;
        private GroupBox groupBox6;
        private Button btnApplicationConcurrency;
        private Button btnServerConcurrency2;
        private Button btnNotConcurrency;
        private Button btnServerConcurrency;
        private Button btnNoOc;
        private Button btnMultUpdateNoOc;
        private Button btnMultUpdate_MultContext;
        private Button btnMultUpdate_MultContext_Select;
        private Button btnOneColumn;
    }
}