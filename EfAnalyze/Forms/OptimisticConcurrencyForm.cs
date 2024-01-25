using EfAnalyze.Global;
using EfAnalyze.Globals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public partial class OptimisticConcurrencyForm : Form
    {
        public OptimisticConcurrencyForm()
        {
            InitializeComponent();
        }

        #region 동시성 없음 - 에러
        private void btnNoOc_Click(object sender, EventArgs e)
        {
            this.DB_Update_NoOC(1, 3000, "첫번째");
            this.DB_Update_NoOC(1, 0, "두번째");
        }

        /// <summary>
        /// 동시성 없음
        /// </summary>
        /// <param name="idTestOC2"></param>
        /// <param name="nDelay"></param>
        /// <param name="sStr"></param>
        private void DB_Update_NoOC(
            int idTestOC2
            , int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                //수정할 개체
                TestOC2? findTarget = null;

                using (ModelsDbContext db1 = new ModelsDbContext())
                {

                    //수정할 대상 찾기
                    findTarget = db1.TestOC2.Where(w => w.idTestOC2 == idTestOC2).FirstOrDefault();

                    if (null != findTarget)
                    {//수정할 대상이 있다.
                        GlobalStatic.Log($"TestOC2 findTarget.Str:{findTarget.Str}, sStr:{sStr}");

                        //값 변경
                        findTarget.Int += 1;
                        findTarget.Str = sStr;

                        //테스트를 위한 딜레이
                        Thread.Sleep(nDelay);

                        //DB에 업데이트 요청
                        db1.SaveChanges();
                        GlobalStatic.Log($"TestOC2 db1.SaveChanges - findTarget.Str:{findTarget.Str}, sStr:{sStr}");
                    }



                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }

        #endregion

        #region 동시성 애플리케이션
        /// <summary>
        /// 동시성 애플리케이션
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplicationConcurrency_Click(object sender, EventArgs e)
        {
            this.DB_Update_ApplicationConcurrency(1, 3000, "첫번째");
            this.DB_Update_ApplicationConcurrency(1, 0, "두번째");
        }

        /// <summary>
        /// 동시성 애플리케이션 처리
        /// </summary>
        /// <remarks>
        /// 애플리케이션 관리 동시성 토큰
        /// https://learn.microsoft.com/ko-kr/ef/core/saving/concurrency?tabs=data-annotations#application-managed-concurrency-tokens
        /// </remarks>
        /// <param name="idTestOC1"></param>
        /// <param name="nDelay"></param>
        /// <param name="sStr"></param>
        private void DB_Update_ApplicationConcurrency(
            int idTestOC1
            , int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                //수정할 개체
                TestOC1? findTarget = null;

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //저장이 실패했는지 여부
                    bool bSave = true;
                    //수정할 대상 찾기
                    findTarget = db1.TestOC1.Where(w => w.idTestOC1 == idTestOC1).FirstOrDefault();

                    do
                    {
                        bSave = true;
                        try
                        {
                            if (null != findTarget)
                            {//수정할 대상이 있다.
                                GlobalStatic.Log("TestOC1 findTarget : " + findTarget.Str);

                                //값 변경
                                findTarget.Int += 1;
                                findTarget.Str = sStr;

                                //☆☆☆☆ 저장할때 항상 GUID를 변경해야 한다.
                                findTarget.Version = Guid.NewGuid();

                                //테스트를 위한 딜레이
                                Thread.Sleep(nDelay);

                                //DB에 업데이트 요청
                                db1.SaveChanges();
                                GlobalStatic.Log("TestOC1 db1.SaveChanges : " + sStr);
                            }
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            bSave = false;

                            // Update the values of the entity that failed to save from the store
                            // 수정하려던 요소를 다시 로드 한다.
                            // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
                            ex.Entries.Single().Reload();
                        }

                        //저장에 실패했다면 다시 시도
                    } while (false == bSave);

                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }
        #endregion

        #region 동시성 서버

        /// <summary>
        /// 동시성 서버
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerConcurrency_Click(object sender, EventArgs e)
        {
            this.DB_Update_ServerConcurrency(1, 3000, "첫번째-동시성 서버");
            this.DB_Update_ServerConcurrency(1, 0, "두번째-동시성 서버");
        }

        /// <summary>
        /// 동시성 서버
        /// </summary>
        /// <remarks>
        /// 다시 로드를 사용하여 낙관적 동시성 예외 해결(데이터베이스 승리)
        /// https://learn.microsoft.com/ko-kr/ef/ef6/saving/concurrency#resolving-optimistic-concurrency-exceptions-with-reload-database-wins
        /// </remarks>
        /// <param name="idTestOC2"></param>
        /// <param name="nDelay"></param>
        /// <param name="sStr"></param>
        private void DB_Update_ServerConcurrency(
            int idTestOC2
            , int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                //수정할 개체
                TestOC2? findTarget = null;

                string sTitle = $"DB_Update_ServerConcurrency call - sStr:{sStr} : ";

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //저장이 실패했는지 여부
                    bool bSave = true;
                    //수정할 대상 찾기
                    findTarget = db1.TestOC2.Where(w => w.idTestOC2 == idTestOC2).FirstOrDefault();

                    do
                    {
                        bSave = true;
                        try
                        {
                            if (null != findTarget)
                            {//수정할 대상이 있다.
                                GlobalStatic.Log($"{sTitle} findTarget.Str:{findTarget.Str}, sStr:{sStr}");

                                //값 변경
                                findTarget.Int += 1;
                                findTarget.Str = sStr;

                                //테스트를 위한 딜레이
                                Thread.Sleep(nDelay);

                                //DB에 업데이트 요청
                                db1.SaveChanges();
                                GlobalStatic.Log($"{sTitle}  db1.SaveChanges - findTarget.Str:{findTarget.Str}, sStr:{sStr}");
                            }
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            bSave = false;

                            // Update the values of the entity that failed to save from the store
                            // 수정하려던 요소를 다시 로드 한다.
                            // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
                            ex.Entries.Single().Reload();
                            GlobalStatic.Log($"{sTitle} ex  sStr:{sStr} =");
                        }

                    } while (false == bSave);

                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }

        #endregion

        #region 동시성 서버2

        /// <summary>
        /// 동시성 서버
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerConcurrency2_Click(object sender, EventArgs e)
        {
            this.DB_Update_ServerConcurrency2(1, 3000, "첫번째");
            this.DB_Update_ServerConcurrency2(1, 0, "두번째");
        }

        /// <summary>
        /// 동시성 서버
        /// </summary>
        /// <remarks>
        /// 동시성 처리용 함수를 만들어 처리
        /// </remarks>
        /// <param name="idTestOC2"></param>
        /// <param name="nDelay"></param>
        /// <param name="sStr"></param>
        private void DB_Update_ServerConcurrency2(
            int idTestOC2
            , int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                TestOC2? findTarget = null;

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    findTarget = db1.TestOC2.Where(w => w.idTestOC2 == idTestOC2).FirstOrDefault();

                    if (null != findTarget)
                    {
                        GlobalDb_OC.SaveChanges_UpdateConcurrency(
                            db1
                            , -1
                            , () =>
                            {
                                findTarget.Int += 1;
                                findTarget.Str = sStr;

                                Thread.Sleep(nDelay);

                                return true;
                            });
                    }

                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }

        #endregion

        #region 동시성 없음
        /// <summary>
        /// 동시성 없음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNotConcurrency_Click(object sender, EventArgs e)
        {
            this.DB_Update_NoConcurrency(3000, "첫번째");
            this.DB_Update_NoConcurrency(0, "두번째");
        }


        /// <summary>
        /// 동시성 없음
        /// </summary>
        /// <param name="nDelay">저장 직전 딜레이</param>
        /// <param name="sStr"></param>
        private void DB_Update_NoConcurrency(
            int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                TestOC3? findTarget = null;

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    findTarget = db1.TestOC3.Where(w => w.idTestOC3 == 1).FirstOrDefault();


                    if (null != findTarget)
                    {
                        GlobalStatic.Log("TestOC3 findTarget : " + findTarget.Str);

                        findTarget.Int += 1;
                        findTarget.Str = sStr;

                        Thread.Sleep(nDelay);
                        db1.SaveChanges();
                        GlobalStatic.Log("TestOC3 db1.SaveChanges : " + sStr);
                    }

                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }

        #endregion

        #region 여러개 업데이트 : 구현 테스트 - TestOC2
        private void btnMultUpdate_Click(object sender, EventArgs e)
        {
            this.DB_Update_ServerConcurrency3<TestOC2>(3000, "첫번째");
            this.DB_Update_ServerConcurrency(1, 0, "두번째");
        }

        private void DB_Update_ServerConcurrency3<T>(
            int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                //수정할 개체
                List<TestOC2>? findTarget = null;

                GlobalStatic.Log($"DB_Update_ServerConcurrency3 call - sStr:{sStr}");

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //저장이 실패했는지 여부
                    bool bSave = true;
                    //수정할 대상 찾기
                    findTarget
                        = db1.TestOC2
                            .ToList();


                    //남은 리스트
                    List<TestOC2> listLeft = new List<TestOC2>();
                    listLeft.AddRange(findTarget);

                    do
                    {
                        bSave = true;

                        try
                        {
                            if (null != listLeft)
                            {
                                for (int i = 0; i < listLeft.Count; ++i)
                                {
                                    TestOC2 item = listLeft[i];

                                    GlobalStatic.Log($"TestOC2 - sStr:{sStr}, findTarget.Str:{item.Str} ");

                                    //값 변경
                                    item.Int += 1;
                                    item.Str = sStr + " - " + i;
                                }

                                //테스트를 위한 딜레이
                                Thread.Sleep(nDelay);

                                //DB에 업데이트 요청
                                db1.SaveChanges();
                                GlobalStatic.Log($"TestOC2 db1.SaveChanges - sStr:{sStr}");
                            }

                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            bSave = false;

                            // Update the values of the entity that failed to save from the store
                            // 수정하려던 요소를 다시 로드 한다.
                            // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
                            var aaa = ex.Entries.Single();
                            aaa.Reload();
                            //listSuccess.Add(aaa.Entity as TestOC2);
                            var bbb = aaa.Entity as TestOC2;
                            GlobalStatic.Log($"ex  sStr:{sStr} = idTestOC2 : {bbb!.idTestOC2}, Int : {bbb.Int}, Str : {bbb.Str}");


                            int nIdx = listLeft!.IndexOf(bbb);

                            if (-1 != nIdx)
                            {//업데이트에 실패한 개체가 있다.

                                //인덱스 전까지 있는 
                                listLeft.RemoveRange(0, nIdx);
                                //리스트의 맨끝으로 이동한다.
                                TestOC2 tData = listLeft[0];
                                listLeft.RemoveAt(0);
                                listLeft.Add(tData);

                            }

                        }

                    } while (false == bSave);

                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }
        #endregion

        #region 여러개 업데이트 : 공통화 함수 - TestOC2
        private void btnMultUpdateFunc_Click(object sender, EventArgs e)
        {
            this.DB_Update_ServerMultiConcurrency(3000, "첫번째");

            //this.DB_Update_ServerMultiConcurrency(0, "두번째");
            //this.DB_Update_ServerConcurrency(1, 0, "두번째");
            this.DB_Update_ServerConcurrency(2, 0, "두번째");
        }

        /// <summary>
        /// 동시성 여러개 업데이트 함수화
        /// </summary>
        /// <remarks>
        /// 동시성 처리용 함수를 만들어 처리
        /// </remarks>
        /// <param name="nDelay"></param>
        /// <param name="sStr"></param>
        private void DB_Update_ServerMultiConcurrency(
            int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                List<TestOC2> findTarget;

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //대상 리스트
                    findTarget = db1.TestOC2.ToList();

                    if (null != findTarget)
                    {
                        GlobalDb_OC.SaveChanges_MultiUpdateConcurrency<TestOC2>(
                            db1
                            , -1
                            , ref findTarget
                            , (TestOC2 item) =>
                            {//각 아이템에 대한 동작

                                item.Int += 1;
                                item.Str = sStr;

                                return true;
                            }
                            , nDelay);
                    }

                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }
        #endregion



        #region 여러개 업데이트 : 동시성 없음
        private void btnMultUpdateNoOc_Click(object sender, EventArgs e)
        {
            this.DB_MultUpdate_NoOC<TestOC2>(3000, "첫번째-여러개 업데이트 : 동시성 없음");
            this.DB_Update_ServerConcurrency(4, 0, "두번째-여러개 업데이트 : 동시성 없음");
        }



        /// <summary>
        /// 동시성 없음
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nDelay"></param>
        /// <param name="sStr"></param>
        private void DB_MultUpdate_NoOC<T>(
            int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                //수정할 개체
                List<TestOC2>? findTarget = null;

                string sTitle = $"DB_MultUpdate_NoOC call - sStr:{sStr}";

                GlobalStatic.Log(sTitle);

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //수정할 대상 찾기
                    findTarget = db1.TestOC2.ToList();


                    //남은 리스트
                    List<TestOC2> listLeft = new List<TestOC2>();
                    listLeft.AddRange(findTarget);

                    try
                    {
                        if (null != listLeft)
                        {
                            for (int i = 0; i < listLeft.Count; ++i)
                            {
                                TestOC2 item = listLeft[i];

                                GlobalStatic.Log($"{sTitle}, findTarget.Str:{item.Str} ");

                                //값 변경
                                item.Int += 1;
                                item.Str = sStr + " - " + i;
                            }

                            //테스트를 위한 딜레이
                            Thread.Sleep(nDelay);

                            GlobalStatic.Log($"{sTitle} db1.SaveChanges");
                            //DB에 업데이트 요청
                            db1.SaveChanges();

                        }

                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        TestOC2 exEE = (TestOC2)ex.Entries.Single().Entity;

                        //별도의 에러처림 없이 넘긴다.
                        GlobalStatic.Log($"----- Exception = {sTitle} db1.SaveChanges - idTestOC2:{exEE.idTestOC2} -----");
                        GlobalStatic.Log(ex.Message);
                        GlobalStatic.Log($"----- end Exception -----");
                    }

                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }
        #endregion


        private void btnMultUpdate_MultContext_Click(object sender, EventArgs e)
        {
            this.DB_Update_ServerMultiContext(3000, "첫번째-컨택스트 멀티");

            //this.DB_Update_ServerMultiConcurrency(0, "두번째-컨택스트 멀티");
            //this.DB_Update_ServerConcurrency(1, 0, "두번째-컨택스트 멀티");
            this.DB_Update_ServerConcurrency(2, 0, "두번째-컨택스트 멀티");
        }

        /// <summary>
        /// 동시성 여러개 업데이트 함수화
        /// </summary>
        /// <remarks>
        /// 동시성 처리용 함수를 만들어 처리
        /// </remarks>
        /// <param name="nDelay"></param>
        /// <param name="sStr"></param>
        private void DB_Update_ServerMultiContext(
            int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                List<TestOC2> findTarget;

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //대상 리스트
                    findTarget = db1.TestOC2.ToList();
                    //findTarget = db1.TestOC2.Where(w => w.idTestOC2 == 1).ToList();

                    if (null != findTarget)
                    {
                        GlobalDb_OC.SaveChanges_MultiContext<TestOC2>(
                            -1
                            , ref findTarget
                            , (TestOC2 item) =>
                            {//각 아이템에 대한 동작

                                //item.Int += 1;
                                item.Str = $"{sStr} : {item.idTestOC2}";

                                return true;
                            }
                            , nDelay);
                    }

                }//end using db1

                GlobalStatic.DbItemInfoReload();
            });
        }

        private void btnMultUpdate_MultContext_Select_Click(object sender, EventArgs e)
        {
            this.DB_Update_ServerMultiContext_Select(3000, "첫번째-컨택스트 멀티(select)");

            //this.DB_Update_ServerMultiConcurrency(0, "두번째-컨택스트 멀티(select)");
            //this.DB_Update_ServerConcurrency(1, 0, "두번째-컨택스트 멀티(select)");
            this.DB_Update_ServerConcurrency(1, 0, "두번째-컨택스트 멀티(select)");
        }

        private void DB_Update_ServerMultiContext_Select(
            int nDelay
            , string sStr)
        {
            //비동기 처리
            Task.Run(() =>
            {
                List<TestOC2> findTarget;

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //대상 리스트
                    findTarget
                    = db1.TestOC2
                        .Select(s => new TestOC2() { idTestOC2 = s.idTestOC2, Str = s.Str })
                        .ToList();
                    //findTarget = db1.TestOC2.Where(w => w.idTestOC2 == 1).ToList();

                }//end using db1

                if (null != findTarget)
                {
                    GlobalDb_OC.SaveChanges_MultiContext<TestOC2>(
                        -1
                        , ref findTarget
                        , (TestOC2 item) =>
                        {//각 아이템에 대한 동작

                            //item.Int += 1;
                            item.Str = $"{sStr} : {item.idTestOC2}";

                            return true;
                        }
                        , nDelay);
                }

                GlobalStatic.DbItemInfoReload();
            });
        }

        #region 한개 업데이트

        /// <summary>
        /// 컬럼 한개씩 업데이트
        /// </summary>
        /// <remarks>
        /// 같은 로우의 다른 컬럼을 동시에 수정하려고 할때 테스트
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOneColumn_Click(object sender, EventArgs e)
        {
            this.DB_Update_ServerMultiContext_OneData(3000, "첫번째-컨택스트 멀티", 0);
            this.DB_Update_ServerMultiContext_OneData(2, "두번째-컨택스트 멀티", 1);
        }

        /// <summary>
        /// 데이터 한개 수정
        /// </summary>
        /// <param name="nDelay"></param>
        /// <param name="sStr"></param>
        /// <param name="nTarget"></param>
        private void DB_Update_ServerMultiContext_OneData(
            int nDelay
            , string sStr
            , int nTarget)
        {
            //비동기 처리
            Task.Run(() =>
            {

                //테스트를 위한 딜레이
                Thread.Sleep(nDelay);

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //대상 리스트
                    TestOC2 findTarget = db1.TestOC2.First();
                    //findTarget = db1.TestOC2.Where(w => w.idTestOC2 == 1).ToList();

                    if (null != findTarget)
                    {
                        GlobalDb_OC.SaveChanges_UpdateConcurrency(
                            db1
                            , -1
                            , () =>
                            {//각 아이템에 대한 동작

                                switch (nTarget)
                                {
                                    case 0:
                                        findTarget.Str = $"{sStr} : {findTarget.idTestOC2}, {findTarget.Int}";
                                        break;

                                    case 1:
                                        findTarget.Int += 1;
                                        break;
                                }

                                return true;
                            });
                    }

                }//end using db1

                

                GlobalStatic.DbItemInfoReload();
            });
        }

        #endregion
    }
}
