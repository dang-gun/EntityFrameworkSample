using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EfAnalyze.Global;
using Global.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ModelsDB;

namespace EfAnalyze.Forms
{
    public partial class SaveChangesUpdateOrderForm : Form
    {
        public SaveChangesUpdateOrderForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 정렬 없음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveChanges_NoOrderby_Click(object sender, EventArgs e)
        {
            string sStr = "입력 순서 확인 - 정렬 없음";

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                List<TestOC2> findTarget
                    = db1.TestOC2
                        .ToList();

                for (int i = 0; i < findTarget.Count; ++i)
                {
                    TestOC2 item = findTarget[i];
                    GlobalStatic.Log($"TestOC2 - sStr:{sStr}, findTarget.Str:{item.Str} ");

                    //값 변경
                    item.Int += 1;
                    item.Str = $"{sStr} - {item.Int}, {i}";
                }


                db1.SaveChanges();
            }

            GlobalStatic.DbItemInfoReload();
        }

        /// <summary>
        /// 정렬 있음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveChanges_Orderby_Click(object sender, EventArgs e)
        {
            string sStr = "입력 순서 확인 - 정렬 있음";

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                List<TestOC2> findTarget
                    = db1.TestOC2
                        .OrderByDescending(ob => ob.idTestOC2)
                        .ToList();

                for (int i = 0; i < findTarget.Count; ++i)
                {
                    TestOC2 item = findTarget[i];
                    GlobalStatic.Log($"TestOC2 - sStr:{sStr}, findTarget.Str:{item.Str} ");

                    //값 변경
                    item.Int += 1;
                    item.Str = $"{sStr} - {item.Int}, {i}";
                }


                db1.SaveChanges();
            }

            GlobalStatic.DbItemInfoReload();
        }

        /// <summary>
        /// 따로 검색
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchSeparately_Click(object sender, EventArgs e)
        {
            string sStr = "입력 순서 확인 - 따로 검색";

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                List<TestOC2> findTarget = new List<TestOC2>();

                findTarget.Add(db1.TestOC2.Where(w => w.idTestOC2 == 2).First());
                findTarget.Add(db1.TestOC2.Where(w => w.idTestOC2 == 1).First());

                for (int i = 0; i < findTarget.Count; ++i)
                {
                    TestOC2 item = findTarget[i];
                    GlobalStatic.Log($"TestOC2 - sStr:{sStr}, findTarget.Str:{item.Str} ");

                    //값 변경
                    item.Int += 1;
                    item.Str = $"{sStr} - {item.Int}, {i}";
                }


                db1.SaveChanges();
            }

            GlobalStatic.DbItemInfoReload();
        }

        private void btnEnterSeparately_Click(object sender, EventArgs e)
        {
            string sStr = "입력 순서 확인 - 따로 입력";

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                List<TestOC2> findTarget = new List<TestOC2>();

                findTarget.Add(db1.TestOC2.Where(w => w.idTestOC2 == 2).First());
                GlobalStatic.Log($"TestOC2 - sStr:{sStr}, findTarget.Str:{findTarget[0].Str} ");
                findTarget[0].Int += 1;
                findTarget[0].Str = $"{sStr} - {findTarget[0].Int}, {0}";

                findTarget.Add(db1.TestOC2.Where(w => w.idTestOC2 == 1).First());
                GlobalStatic.Log($"TestOC2 - sStr:{sStr}, findTarget.Str:{findTarget[1].Str} ");
                findTarget[1].Int += 1;
                findTarget[1].Str = $"{sStr} - {findTarget[1].Int}, {1}";


                db1.SaveChanges();
            }

            GlobalStatic.DbItemInfoReload();
        }


        /// <summary>
        /// 그만 추적하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopTracking_Click(object sender, EventArgs e)
        {
            string sStr = "그만 추적하기";

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                List<TestOC2> findTarget
                    = db1.TestOC2
                        .ToList();

                for (int i = 0; i < findTarget.Count; ++i)
                {
                    TestOC2 item = findTarget[i];
                    GlobalStatic.Log($"TestOC2 - sStr:{sStr}, findTarget.Str:{item.Str} ");

                    //값 변경
                    item.Int += 1;
                    item.Str = $"{sStr} - {item.Int}, {i}";
                }

                //0번 아이템 추적 멈추기
                EntityEntry eeTemp = db1.Entry(findTarget[0]);
                if (eeTemp.State != EntityState.Detached)
                {
                    eeTemp.State = EntityState.Detached;
                }


                db1.SaveChanges();
            }

            GlobalStatic.DbItemInfoReload();
        }
    }
}
