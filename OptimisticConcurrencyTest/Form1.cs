using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

using OptimisticConcurrency.Global;

using EntityFrameworkSample.DB.Models;
using EntityFrameworkSample.DB;
using OptimisticConcurrencyTest.TableModels;

namespace OptimisticConcurrencyTest;

public partial class Form1 : Form
{

    public Form1()
    {
        InitializeComponent();

        string sDbString = GlobalDb.DbStringLoad(UseDbType.MSSQL);

        //MSSQL 정보
        if (string.Empty != sDbString)
        {
            this.txtMssql_ConnectStriong.Text = sDbString;
        }
        else
        {
            this.txtMssql_ConnectStriong.Text = string.Empty;
        }


        //sqlite를 기본으로 사용한다.
        this.btnSqlite_Use_Click(null, null);
        //this.btnMssql_Use_Click(null, null);

    }


    #region SQLite
    private void btnSqlite_Use_Click(object? sender, EventArgs? e)
    {
        GlobalDb.DBType = UseDbType.SQLite;
        if (true == this.checkSqlite_UseDefult.Checked)
        {
            GlobalDb.DBString = string.Empty;
        }
        else
        {
            GlobalDb.DBString = this.txtSqlite_ConnectStriong.Text;
        }

        this.DbSetting();

        radioMssqlUse.Checked = false;
        radioSqliteUse.Checked = true;
    }
    #endregion


    #region MSSQL
    /// <summary>
    /// mssql 사용
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMssql_Use_Click(object? sender, EventArgs? e)
    {
        GlobalDb.DBType = UseDbType.MSSQL;
        if(true == this.checkMssql_UseDefult.Checked)
        {
            GlobalDb.DBString = string.Empty;
        }
        else
        {
            GlobalDb.DBString = this.txtMssql_ConnectStriong.Text;
        }
        
        this.DbSetting();

        radioMssqlUse.Checked = true;
        radioSqliteUse.Checked = false;
    }
    #endregion

    private void DbSetting()
    {
        //DB 정보가 없으면 기본 정보 불러오기
        GlobalDb.DbStringReload(true);

        this.Text = $"Select DB : {GlobalDb.DBType.ToString()}";

        //db 마이그레이션 적용
        switch (GlobalDb.DBType)
        {
            case UseDbType.SQLite:
                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
            case UseDbType.MSSQL:
                using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
        }
    }


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
    /// <para>애플리케이션이 직접 동시성 토큰을 갱신하여 처리한다.</para>
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

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
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

                            Log("TestOC1 findTarget : " + findTarget.Str);

                            //값 변경
                            findTarget.Int += 1;
                            findTarget.Str = sStr;

                            //☆☆☆☆ 저장할때 항상 GUID를 변경해야 한다.
                            findTarget.Version = Guid.NewGuid();

                            //테스트를 위한 딜레이
                            Thread.Sleep(nDelay);

                            //DB에 업데이트 요청
                            db1.SaveChanges();
                            Log("TestOC1 db1.SaveChanges : " + sStr);
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

            this.ReloadDB();
        });
    }
    #endregion


    #region 동시성 서버

    /// <summary>
    /// 동시성 서버
    /// </summary>
    /// <remarks>
    /// 동시성 토큰을 DB에서 관리한다.
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnServerConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerConcurrency(1, 3000, "첫번째");
        this.DB_Update_ServerConcurrency(1, 0, "두번째");
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

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
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
                            Log($"TestOC2 findTarget.Str:{findTarget.Str}, sStr:{sStr}");

                            //값 변경
                            findTarget.Int += 1;
                            findTarget.Str = sStr;

                            //테스트를 위한 딜레이
                            Thread.Sleep(nDelay);

                            //DB에 업데이트 요청
                            db1.SaveChanges();
                            Log($"TestOC2 db1.SaveChanges - findTarget.Str:{findTarget.Str}, sStr:{sStr}");
                        }
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        bSave = false;

                        // Update the values of the entity that failed to save from the store
                        // 수정하려던 요소를 다시 로드 한다.
                        // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
                        ex.Entries.Single().Reload();
                        Log($"ex  sStr:{sStr} =");
                    }

                } while (false == bSave);

            }//end using db1

            this.ReloadDB();
        });
    }

    #endregion

    #region 동시성 서버2

    /// <summary>
    /// 동시성 서버
    /// </summary>
    /// <remarks>
    /// 동시성 토큰을 DB에서 관리한다.
    /// <para>다른 곳에 이식이 편하도록 함수화 된 코드를 호출한다.</para>
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnServerConcurrency2_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerConcurrency_Func(1, 3000, "첫번째");
        this.DB_Update_ServerConcurrency_Func(1, 0, "두번째");
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
    private void DB_Update_ServerConcurrency_Func(
        int idTestOC2
        , int nDelay
        , string sStr)
    {
        //비동기 처리
        Task.Run(() =>
        {
            TestOC2? findTarget = null;

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
            {
                findTarget = db1.TestOC2.Where(w => w.idTestOC2 == idTestOC2).FirstOrDefault();

                if (null != findTarget)
                {
                    GlobalStatic.OC_Util.SaveChanges_UpdateConcurrency(
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

            this.ReloadDB();
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

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
            {
                findTarget = db1.TestOC3.Where(w => w.idTestOC3 == 1).FirstOrDefault();


                if (null != findTarget)
                {
                    Log("TestOC3 findTarget : " + findTarget.Str);

                    findTarget.Int += 1;
                    findTarget.Str = sStr;

                    Thread.Sleep(nDelay);
                    db1.SaveChanges();
                    Log("TestOC3 db1.SaveChanges : " + sStr);
                }

            }//end using db1

            this.ReloadDB();
        });
    }

    #endregion


    #region 여러개 업데이트 : 구현 테스트 - TestOC2
    private void btnMultUpdate_Click(object sender, EventArgs e)
    {
        this.DB_Update_MultiServerConcurrency_Test(3000, "첫번째");
        this.DB_Update_ServerConcurrency(1, 0, "두번째");
    }

    /// <summary>
    /// 여러 개체를 찾아 업데이트 한다.
    /// </summary>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_MultiServerConcurrency_Test(
        int nDelay
        , string sStr)
    {
        //비동기 처리
        Task.Run(() =>
        {
            //수정할 개체
            List<TestOC2>? findTarget = null;

            Log($"DB_Update_ServerConcurrency3 call - sStr:{sStr}");

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
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

                                Log($"TestOC2 - sStr:{sStr}, findTarget.Str:{item.Str} ");

                                //값 변경
                                item.Int += 1;
                                item.Str = sStr + " - " + i;
                            }

                            //테스트를 위한 딜레이
                            Thread.Sleep(nDelay);

                            //DB에 업데이트 요청
                            db1.SaveChanges();
                            Log($"TestOC2 db1.SaveChanges - sStr:{sStr}");
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
                        Log($"ex  sStr:{sStr} = idTestOC2 : {bbb!.idTestOC2}, Int : {bbb.Int}, Str : {bbb.Str}");


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

            this.ReloadDB();
        });
    }
    #endregion


    #region 여러개 업데이트 : 각자 컨택스트 생성하여 처리함(순차 처리 동기) - TestOC2
    private void btnMultUpdateFunc_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerMultiConcurrency(3000, "첫번째");

        //this.DB_Update_ServerMultiConcurrency(0, "두번째");
        //this.DB_Update_ServerConcurrency(1, 0, "두번째");
        this.DB_Update_ServerConcurrency(2, 0, "두번째");
    }

    /// <summary>
    /// 동시성 여러개 업데이트 함수화
    /// <para>각자 컨택스트 생성하여 처리함(순차 처리 동기)</para>
    /// </summary>
    /// <remarks>
    /// 동시성 처리용 함수를 만들어 처리한다.
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

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
            {
                //대상 리스트
                findTarget = db1.TestOC2.ToList();

                if (null != findTarget)
                {
                    GlobalStatic.OC_Util.SaveChanges_Update_MultiDbContext<TestOC2>(
                        -1
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

            this.ReloadDB();
        });
    }
    #endregion

    /// <summary>
    /// 화면에 데이터를 표시한다.
    /// </summary>
    private void ReloadDB()
    {

        TestOC1? findOC1 = null;
        TestOC2? findOC2 = null;
        TestOC2? findOC2_2 = null;
        TestOC3? findOC3 = null;

        using (ModelsDbContextTable db1 = new ModelsDbContextTable())
        {
            findOC1 = db1.TestOC1.Where(w => w.idTestOC1 == 1).FirstOrDefault();
            findOC2 = db1.TestOC2.Where(w => w.idTestOC2 == 1).FirstOrDefault();
            findOC2_2 = db1.TestOC2.Where(w => w.idTestOC2 == 2).FirstOrDefault();
            findOC3 = db1.TestOC3.Where(w => w.idTestOC3 == 1).FirstOrDefault();
        }

        if (true == InvokeRequired)
        {//다른 쓰래드다.
            this.Invoke(new Action(
                delegate ()
                {
                    this.ViewUi(findOC1, findOC2, findOC2_2, findOC3);
                }));
        }
        else
        {//같은 쓰래드다.
            this.ViewUi(findOC1, findOC2, findOC2_2, findOC3);
        }
    }

    private void ViewUi(
        TestOC1? findOC1
        , TestOC2? findOC2
        , TestOC2? findOC2_2
        , TestOC3? findOC3)
    {
        if (null != findOC1)
        {
            this.txtDb_TestOC1_Int.Text = findOC1.Int.ToString();
            this.txtDb_TestOC1_Str.Text = findOC1.Str;
        }

        if (null != findOC2)
        {
            this.txtDb_TestOC2_Int.Text = findOC2.Int.ToString();
            this.txtDb_TestOC2_Str.Text = findOC2.Str;
        }

        if (null != findOC2_2)
        {
            this.txtDb_TestOC2_2_Int.Text = findOC2_2.Int.ToString();
            this.txtDb_TestOC2_2_Str.Text = findOC2_2.Str;
        }

        if (null != findOC3)
        {
            this.txtDb_TestOC3_Int.Text = findOC3.Int.ToString();
            this.txtDb_TestOC3_Str.Text = findOC3.Str;
        }
    }

    private void Log(string sMsg)
    {
        Debug.WriteLine(string.Format("[{0}] {1}"
            , DateTime.Now.ToString("HH:mm:ss")
            , sMsg));
    }

    
}