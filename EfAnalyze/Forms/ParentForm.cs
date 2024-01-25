using EfAnalyze.Global;
using ModelsDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfAnalyze.Forms
{
    public partial class ParentForm : Form
    {
        #region 외부 공개 함수

        public void ViewUi_Data(List<TestOC2>? findOC2)
        {
            if (true == InvokeRequired)
            {//다른 쓰래드다.
                this.Invoke(new Action(
                    delegate ()
                    {
                        this.ViewUi_This(findOC2);
                    }));
            }
            else
            {//같은 쓰래드다.
                this.ViewUi_This(findOC2);
            }
        }


        /// <summary>
        /// 데이터를 표시한다.
        /// </summary>
        /// <param name="findOC2"></param>
        private void ViewUi_This(List<TestOC2>? findOC2)
        {
            if (null != findOC2)
            {
                this.txtDb_TestOC2_Idx0_Int.Text = findOC2[0].Int.ToString();
                this.txtDb_TestOC2_Idx0_Str.Text = findOC2[0].Str;

                this.txtDb_TestOC2_Idx1_Int.Text = findOC2[1].Int.ToString();
                this.txtDb_TestOC2_Idx1_Str.Text = findOC2[1].Str;
            }
        }
        #endregion

        public ParentForm()
        {
            InitializeComponent();

            GlobalStatic.frmParent = this;

            GlobalStatic.frmDbInfo.MdiParent = this;
            GlobalStatic.frmSaveChangesUpdateOrder.MdiParent = this;
            GlobalStatic.frmOptimisticConcurrency.MdiParent = this;
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            GlobalStatic.frmDbInfo.Show();
        }




        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        #region 메뉴 - 창
        private void tsmiWindow_DbInfo_Click(object sender, EventArgs e)
        {
            GlobalStatic.frmDbInfo.Show();
            GlobalStatic.frmDbInfo.Activate();
            GlobalStatic.frmDbInfo.BringToFront();
        }

        private void tsmifromSaveChangesUpdateOrder_Click(object sender, EventArgs e)
        {
            GlobalStatic.frmSaveChangesUpdateOrder.Show();
            GlobalStatic.frmSaveChangesUpdateOrder.Activate();
            GlobalStatic.frmSaveChangesUpdateOrder.BringToFront();
        }

        private void tsmiOptimisticConcurrency_Click(object sender, EventArgs e)
        {
            GlobalStatic.frmOptimisticConcurrency.Show();
            GlobalStatic.frmOptimisticConcurrency.Activate();
            GlobalStatic.frmOptimisticConcurrency.BringToFront();
        }
        #endregion



    }
}
