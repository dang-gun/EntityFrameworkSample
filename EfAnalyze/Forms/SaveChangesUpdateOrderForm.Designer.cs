namespace EfAnalyze.Forms
{
    partial class SaveChangesUpdateOrderForm
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
            groupBox1 = new GroupBox();
            btnEnterSeparately = new Button();
            btnSearchSeparately = new Button();
            btnSaveChanges_Orderby = new Button();
            btnSaveChanges_NoOrderby = new Button();
            groupBox2 = new GroupBox();
            btnStopTracking = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEnterSeparately);
            groupBox1.Controls.Add(btnSearchSeparately);
            groupBox1.Controls.Add(btnSaveChanges_Orderby);
            groupBox1.Controls.Add(btnSaveChanges_NoOrderby);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 142);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "순서 테스트";
            // 
            // btnEnterSeparately
            // 
            btnEnterSeparately.Location = new Point(6, 109);
            btnEnterSeparately.Name = "btnEnterSeparately";
            btnEnterSeparately.Size = new Size(188, 23);
            btnEnterSeparately.TabIndex = 0;
            btnEnterSeparately.Text = "입력 따로";
            btnEnterSeparately.UseVisualStyleBackColor = true;
            btnEnterSeparately.Click += btnEnterSeparately_Click;
            // 
            // btnSearchSeparately
            // 
            btnSearchSeparately.Location = new Point(6, 80);
            btnSearchSeparately.Name = "btnSearchSeparately";
            btnSearchSeparately.Size = new Size(188, 23);
            btnSearchSeparately.TabIndex = 0;
            btnSearchSeparately.Text = "검색 따로";
            btnSearchSeparately.UseVisualStyleBackColor = true;
            btnSearchSeparately.Click += btnSearchSeparately_Click;
            // 
            // btnSaveChanges_Orderby
            // 
            btnSaveChanges_Orderby.Location = new Point(6, 51);
            btnSaveChanges_Orderby.Name = "btnSaveChanges_Orderby";
            btnSaveChanges_Orderby.Size = new Size(188, 23);
            btnSaveChanges_Orderby.TabIndex = 0;
            btnSaveChanges_Orderby.Text = "정렬 있음";
            btnSaveChanges_Orderby.UseVisualStyleBackColor = true;
            btnSaveChanges_Orderby.Click += btnSaveChanges_Orderby_Click;
            // 
            // btnSaveChanges_NoOrderby
            // 
            btnSaveChanges_NoOrderby.Location = new Point(6, 22);
            btnSaveChanges_NoOrderby.Name = "btnSaveChanges_NoOrderby";
            btnSaveChanges_NoOrderby.Size = new Size(188, 23);
            btnSaveChanges_NoOrderby.TabIndex = 0;
            btnSaveChanges_NoOrderby.Text = "정렬 없음";
            btnSaveChanges_NoOrderby.UseVisualStyleBackColor = true;
            btnSaveChanges_NoOrderby.Click += btnSaveChanges_NoOrderby_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnStopTracking);
            groupBox2.Location = new Point(218, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(199, 142);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "속성에 따른 동작";
            // 
            // btnStopTracking
            // 
            btnStopTracking.Location = new Point(6, 22);
            btnStopTracking.Name = "btnStopTracking";
            btnStopTracking.Size = new Size(188, 23);
            btnStopTracking.TabIndex = 0;
            btnStopTracking.Text = "그만 추적하기";
            btnStopTracking.UseVisualStyleBackColor = true;
            btnStopTracking.Click += btnStopTracking_Click;
            // 
            // SaveChangesUpdateOrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 167);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaveChangesUpdateOrderForm";
            Text = "SaveChanges에서 업데이트 호출시 쿼리 생성 순서";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnSaveChanges_NoOrderby;
        private Button btnSaveChanges_Orderby;
        private Button btnSearchSeparately;
        private Button btnEnterSeparately;
        private GroupBox groupBox2;
        private Button btnStopTracking;
    }
}