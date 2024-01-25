namespace EfAnalyze.Forms
{
    partial class ParentForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            옵션ToolStripMenuItem = new ToolStripMenuItem();
            tsmiDbItemInfoReload = new ToolStripMenuItem();
            tsmiLogShow = new ToolStripMenuItem();
            windowsMenu = new ToolStripMenuItem();
            tsmiWindow_DbInfo = new ToolStripMenuItem();
            tsmifromSaveChangesUpdateOrder = new ToolStripMenuItem();
            tsmiOptimisticConcurrency = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            cascadeToolStripMenuItem = new ToolStripMenuItem();
            tileVerticalToolStripMenuItem = new ToolStripMenuItem();
            tileHorizontalToolStripMenuItem = new ToolStripMenuItem();
            arrangeIconsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            panelLog = new Panel();
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtDb_TestOC2_Idx1_Str = new TextBox();
            txtDb_TestOC2_Idx1_Int = new TextBox();
            label2 = new Label();
            groupBox4 = new GroupBox();
            label5 = new Label();
            txtDb_TestOC2_Idx0_Str = new TextBox();
            txtDb_TestOC2_Idx0_Int = new TextBox();
            label6 = new Label();
            splitter1 = new Splitter();
            listView1 = new ListView();
            menuStrip.SuspendLayout();
            panelLog.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { 옵션ToolStripMenuItem, windowsMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.MdiWindowListItem = windowsMenu;
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(682, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // 옵션ToolStripMenuItem
            // 
            옵션ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiDbItemInfoReload, tsmiLogShow });
            옵션ToolStripMenuItem.Name = "옵션ToolStripMenuItem";
            옵션ToolStripMenuItem.Size = new Size(43, 20);
            옵션ToolStripMenuItem.Text = "옵션";
            // 
            // tsmiDbItemInfoReload
            // 
            tsmiDbItemInfoReload.Checked = true;
            tsmiDbItemInfoReload.CheckState = CheckState.Checked;
            tsmiDbItemInfoReload.Name = "tsmiDbItemInfoReload";
            tsmiDbItemInfoReload.Size = new Size(158, 22);
            tsmiDbItemInfoReload.Text = "DB Item Reload";
            // 
            // tsmiLogShow
            // 
            tsmiLogShow.Checked = true;
            tsmiLogShow.CheckState = CheckState.Checked;
            tsmiLogShow.Name = "tsmiLogShow";
            tsmiLogShow.Size = new Size(158, 22);
            tsmiLogShow.Text = "Log Show";
            // 
            // windowsMenu
            // 
            windowsMenu.DropDownItems.AddRange(new ToolStripItem[] { tsmiWindow_DbInfo, tsmifromSaveChangesUpdateOrder, tsmiOptimisticConcurrency, toolStripMenuItem2, cascadeToolStripMenuItem, tileVerticalToolStripMenuItem, tileHorizontalToolStripMenuItem, arrangeIconsToolStripMenuItem, toolStripMenuItem1, closeAllToolStripMenuItem });
            windowsMenu.Name = "windowsMenu";
            windowsMenu.Size = new Size(50, 20);
            windowsMenu.Text = "창(&W)";
            // 
            // tsmiWindow_DbInfo
            // 
            tsmiWindow_DbInfo.Name = "tsmiWindow_DbInfo";
            tsmiWindow_DbInfo.Size = new Size(253, 22);
            tsmiWindow_DbInfo.Text = "DB Info";
            tsmiWindow_DbInfo.Click += tsmiWindow_DbInfo_Click;
            // 
            // tsmifromSaveChangesUpdateOrder
            // 
            tsmifromSaveChangesUpdateOrder.Name = "tsmifromSaveChangesUpdateOrder";
            tsmifromSaveChangesUpdateOrder.Size = new Size(253, 22);
            tsmifromSaveChangesUpdateOrder.Text = "SaveChanges 업데이트 쿼리 확인";
            tsmifromSaveChangesUpdateOrder.Click += tsmifromSaveChangesUpdateOrder_Click;
            // 
            // tsmiOptimisticConcurrency
            // 
            tsmiOptimisticConcurrency.Name = "tsmiOptimisticConcurrency";
            tsmiOptimisticConcurrency.Size = new Size(253, 22);
            tsmiOptimisticConcurrency.Text = "낙관적 동시성 테스트";
            tsmiOptimisticConcurrency.Click += tsmiOptimisticConcurrency_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(250, 6);
            // 
            // cascadeToolStripMenuItem
            // 
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new Size(253, 22);
            cascadeToolStripMenuItem.Text = "계단식 배열(&C)";
            cascadeToolStripMenuItem.Click += CascadeToolStripMenuItem_Click;
            // 
            // tileVerticalToolStripMenuItem
            // 
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new Size(253, 22);
            tileVerticalToolStripMenuItem.Text = "세로 바둑판식 배열(&V)";
            tileVerticalToolStripMenuItem.Click += TileVerticalToolStripMenuItem_Click;
            // 
            // tileHorizontalToolStripMenuItem
            // 
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new Size(253, 22);
            tileHorizontalToolStripMenuItem.Text = "가로 바둑판식 배열(&H)";
            tileHorizontalToolStripMenuItem.Click += TileHorizontalToolStripMenuItem_Click;
            // 
            // arrangeIconsToolStripMenuItem
            // 
            arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            arrangeIconsToolStripMenuItem.Size = new Size(253, 22);
            arrangeIconsToolStripMenuItem.Text = "아이콘 정렬(&A)";
            arrangeIconsToolStripMenuItem.Click += ArrangeIconsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(250, 6);
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(253, 22);
            closeAllToolStripMenuItem.Text = "모두 닫기(&L)";
            closeAllToolStripMenuItem.Click += CloseAllToolStripMenuItem_Click;
            // 
            // panelLog
            // 
            panelLog.AutoSize = true;
            panelLog.Controls.Add(groupBox1);
            panelLog.Controls.Add(groupBox4);
            panelLog.Controls.Add(splitter1);
            panelLog.Controls.Add(listView1);
            panelLog.Dock = DockStyle.Bottom;
            panelLog.Location = new Point(0, 430);
            panelLog.Name = "panelLog";
            panelLog.Size = new Size(682, 156);
            panelLog.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtDb_TestOC2_Idx1_Str);
            groupBox1.Controls.Add(txtDb_TestOC2_Idx1_Int);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(3, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(232, 72);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "DB - TestOC2 - Index 1";
            // 
            // label1
            // 
            label1.Location = new Point(6, 42);
            label1.Name = "label1";
            label1.Size = new Size(41, 23);
            label1.TabIndex = 4;
            label1.Text = "Str : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDb_TestOC2_Idx1_Str
            // 
            txtDb_TestOC2_Idx1_Str.Location = new Point(53, 42);
            txtDb_TestOC2_Idx1_Str.Name = "txtDb_TestOC2_Idx1_Str";
            txtDb_TestOC2_Idx1_Str.ReadOnly = true;
            txtDb_TestOC2_Idx1_Str.Size = new Size(173, 23);
            txtDb_TestOC2_Idx1_Str.TabIndex = 4;
            // 
            // txtDb_TestOC2_Idx1_Int
            // 
            txtDb_TestOC2_Idx1_Int.Location = new Point(53, 19);
            txtDb_TestOC2_Idx1_Int.Name = "txtDb_TestOC2_Idx1_Int";
            txtDb_TestOC2_Idx1_Int.ReadOnly = true;
            txtDb_TestOC2_Idx1_Int.Size = new Size(173, 23);
            txtDb_TestOC2_Idx1_Int.TabIndex = 4;
            // 
            // label2
            // 
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(41, 23);
            label2.TabIndex = 4;
            label2.Text = "Int : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(txtDb_TestOC2_Idx0_Str);
            groupBox4.Controls.Add(txtDb_TestOC2_Idx0_Int);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(232, 72);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "DB - TestOC2 - Index 0";
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
            // txtDb_TestOC2_Idx0_Str
            // 
            txtDb_TestOC2_Idx0_Str.Location = new Point(53, 42);
            txtDb_TestOC2_Idx0_Str.Name = "txtDb_TestOC2_Idx0_Str";
            txtDb_TestOC2_Idx0_Str.ReadOnly = true;
            txtDb_TestOC2_Idx0_Str.Size = new Size(173, 23);
            txtDb_TestOC2_Idx0_Str.TabIndex = 4;
            // 
            // txtDb_TestOC2_Idx0_Int
            // 
            txtDb_TestOC2_Idx0_Int.Location = new Point(53, 19);
            txtDb_TestOC2_Idx0_Int.Name = "txtDb_TestOC2_Idx0_Int";
            txtDb_TestOC2_Idx0_Int.ReadOnly = true;
            txtDb_TestOC2_Idx0_Int.Size = new Size(173, 23);
            txtDb_TestOC2_Idx0_Int.TabIndex = 4;
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
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 156);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // listView1
            // 
            listView1.Location = new Point(241, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(441, 150);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ParentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 586);
            Controls.Add(panelLog);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ParentForm";
            Text = "ParentForm";
            Load += ParentForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelLog.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private ToolStripMenuItem windowsMenu;
        private ToolStripMenuItem cascadeToolStripMenuItem;
        private ToolStripMenuItem tileVerticalToolStripMenuItem;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem tsmiWindow_DbInfo;
        private ToolStripMenuItem tsmifromSaveChangesUpdateOrder;
        private ToolStripMenuItem 옵션ToolStripMenuItem;
        public ToolStripMenuItem tsmiDbItemInfoReload;
        public ToolStripMenuItem tsmiLogShow;
        private Panel panelLog;
        private Splitter splitter1;
        private ToolStripMenuItem tsmiOptimisticConcurrency;
        private ListView listView1;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtDb_TestOC2_Idx1_Str;
        private TextBox txtDb_TestOC2_Idx1_Int;
        private Label label2;
        private GroupBox groupBox4;
        private Label label5;
        private TextBox txtDb_TestOC2_Idx0_Str;
        private TextBox txtDb_TestOC2_Idx0_Int;
        private Label label6;
    }
}



