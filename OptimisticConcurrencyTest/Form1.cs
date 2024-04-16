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

        //MSSQL ����
        if (string.Empty != sDbString)
        {
            this.txtMssql_ConnectStriong.Text = sDbString;
        }
        else
        {
            this.txtMssql_ConnectStriong.Text = string.Empty;
        }


        //sqlite�� �⺻���� ����Ѵ�.
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
    /// mssql ���
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
        //DB ������ ������ �⺻ ���� �ҷ�����
        GlobalDb.DbStringReload(true);

        this.Text = $"Select DB : {GlobalDb.DBType.ToString()}";

        //db ���̱׷��̼� ����
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


    #region ���ü� ���ø����̼�
    /// <summary>
    /// ���ü� ���ø����̼�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnApplicationConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_ApplicationConcurrency(1, 3000, "ù��°");
        this.DB_Update_ApplicationConcurrency(1, 0, "�ι�°");
    }

    /// <summary>
    /// ���ü� ���ø����̼� ó��
    /// </summary>
    /// <remarks>
    /// ���ø����̼� ���� ���ü� ��ū
    /// <para>���ø����̼��� ���� ���ü� ��ū�� �����Ͽ� ó���Ѵ�.</para>
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
        //�񵿱� ó��
        Task.Run(() =>
        {
            //������ ��ü
            TestOC1? findTarget = null;

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
            {
                //������ �����ߴ��� ����
                bool bSave = true;
                //������ ��� ã��
                findTarget = db1.TestOC1.Where(w => w.idTestOC1 == idTestOC1).FirstOrDefault();

                do
                {
                    bSave = true;
                    try
                    {
                        if (null != findTarget)
                        {//������ ����� �ִ�.

                            Log("TestOC1 findTarget : " + findTarget.Str);

                            //�� ����
                            findTarget.Int += 1;
                            findTarget.Str = sStr;

                            //�١١١� �����Ҷ� �׻� GUID�� �����ؾ� �Ѵ�.
                            findTarget.Version = Guid.NewGuid();

                            //�׽�Ʈ�� ���� ������
                            Thread.Sleep(nDelay);

                            //DB�� ������Ʈ ��û
                            db1.SaveChanges();
                            Log("TestOC1 db1.SaveChanges : " + sStr);
                        }
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        bSave = false;

                        // Update the values of the entity that failed to save from the store
                        // �����Ϸ��� ��Ҹ� �ٽ� �ε� �Ѵ�.
                        // �����Ϸ��� ���� �ʱ�ȭ �ǹǷ� �������� ���� �ٽ� ����ؾ� �Ѵ�.
                        ex.Entries.Single().Reload();
                    }

                    //���忡 �����ߴٸ� �ٽ� �õ�
                } while (false == bSave);

            }//end using db1

            this.ReloadDB();
        });
    }
    #endregion


    #region ���ü� ����

    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <remarks>
    /// ���ü� ��ū�� DB���� �����Ѵ�.
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnServerConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerConcurrency(1, 3000, "ù��°");
        this.DB_Update_ServerConcurrency(1, 0, "�ι�°");
    }

    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <remarks>
    /// �ٽ� �ε带 ����Ͽ� ������ ���ü� ���� �ذ�(�����ͺ��̽� �¸�)
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
        //�񵿱� ó��
        Task.Run(() =>
        {
            //������ ��ü
            TestOC2? findTarget = null;

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
            {
                //������ �����ߴ��� ����
                bool bSave = true;
                //������ ��� ã��
                findTarget = db1.TestOC2.Where(w => w.idTestOC2 == idTestOC2).FirstOrDefault();

                do
                {
                    bSave = true;
                    try
                    {
                        if (null != findTarget)
                        {//������ ����� �ִ�.
                            Log($"TestOC2 findTarget.Str:{findTarget.Str}, sStr:{sStr}");

                            //�� ����
                            findTarget.Int += 1;
                            findTarget.Str = sStr;

                            //�׽�Ʈ�� ���� ������
                            Thread.Sleep(nDelay);

                            //DB�� ������Ʈ ��û
                            db1.SaveChanges();
                            Log($"TestOC2 db1.SaveChanges - findTarget.Str:{findTarget.Str}, sStr:{sStr}");
                        }
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        bSave = false;

                        // Update the values of the entity that failed to save from the store
                        // �����Ϸ��� ��Ҹ� �ٽ� �ε� �Ѵ�.
                        // �����Ϸ��� ���� �ʱ�ȭ �ǹǷ� �������� ���� �ٽ� ����ؾ� �Ѵ�.
                        ex.Entries.Single().Reload();
                        Log($"ex  sStr:{sStr} =");
                    }

                } while (false == bSave);

            }//end using db1

            this.ReloadDB();
        });
    }

    #endregion

    #region ���ü� ����2

    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <remarks>
    /// ���ü� ��ū�� DB���� �����Ѵ�.
    /// <para>�ٸ� ���� �̽��� ���ϵ��� �Լ�ȭ �� �ڵ带 ȣ���Ѵ�.</para>
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnServerConcurrency2_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerConcurrency_Func(1, 3000, "ù��°");
        this.DB_Update_ServerConcurrency_Func(1, 0, "�ι�°");
    }

    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <remarks>
    /// ���ü� ó���� �Լ��� ����� ó��
    /// </remarks>
    /// <param name="idTestOC2"></param>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_ServerConcurrency_Func(
        int idTestOC2
        , int nDelay
        , string sStr)
    {
        //�񵿱� ó��
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

    #region ���ü� ����
    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNotConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_NoConcurrency(3000, "ù��°");
        this.DB_Update_NoConcurrency(0, "�ι�°");
    }


    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <param name="nDelay">���� ���� ������</param>
    /// <param name="sStr"></param>
    private void DB_Update_NoConcurrency(
        int nDelay
        , string sStr)
    {
        //�񵿱� ó��
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


    #region ������ ������Ʈ : ���� �׽�Ʈ - TestOC2
    private void btnMultUpdate_Click(object sender, EventArgs e)
    {
        this.DB_Update_MultiServerConcurrency_Test(3000, "ù��°");
        this.DB_Update_ServerConcurrency(1, 0, "�ι�°");
    }

    /// <summary>
    /// ���� ��ü�� ã�� ������Ʈ �Ѵ�.
    /// </summary>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_MultiServerConcurrency_Test(
        int nDelay
        , string sStr)
    {
        //�񵿱� ó��
        Task.Run(() =>
        {
            //������ ��ü
            List<TestOC2>? findTarget = null;

            Log($"DB_Update_ServerConcurrency3 call - sStr:{sStr}");

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
            {
                //������ �����ߴ��� ����
                bool bSave = true;
                //������ ��� ã��
                findTarget
                    = db1.TestOC2
                        .ToList();


                //���� ����Ʈ
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

                                //�� ����
                                item.Int += 1;
                                item.Str = sStr + " - " + i;
                            }

                            //�׽�Ʈ�� ���� ������
                            Thread.Sleep(nDelay);

                            //DB�� ������Ʈ ��û
                            db1.SaveChanges();
                            Log($"TestOC2 db1.SaveChanges - sStr:{sStr}");
                        }

                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        bSave = false;

                        // Update the values of the entity that failed to save from the store
                        // �����Ϸ��� ��Ҹ� �ٽ� �ε� �Ѵ�.
                        // �����Ϸ��� ���� �ʱ�ȭ �ǹǷ� �������� ���� �ٽ� ����ؾ� �Ѵ�.
                        var aaa = ex.Entries.Single();
                        aaa.Reload();
                        //listSuccess.Add(aaa.Entity as TestOC2);
                        var bbb = aaa.Entity as TestOC2;
                        Log($"ex  sStr:{sStr} = idTestOC2 : {bbb!.idTestOC2}, Int : {bbb.Int}, Str : {bbb.Str}");


                        int nIdx = listLeft!.IndexOf(bbb);

                        if (-1 != nIdx)
                        {//������Ʈ�� ������ ��ü�� �ִ�.

                            //�ε��� ������ �ִ� 
                            listLeft.RemoveRange(0, nIdx);
                            //����Ʈ�� �ǳ����� �̵��Ѵ�.
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


    #region ������ ������Ʈ : ���� ���ý�Ʈ �����Ͽ� ó����(���� ó�� ����) - TestOC2
    private void btnMultUpdateFunc_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerMultiConcurrency(3000, "ù��°");

        //this.DB_Update_ServerMultiConcurrency(0, "�ι�°");
        //this.DB_Update_ServerConcurrency(1, 0, "�ι�°");
        this.DB_Update_ServerConcurrency(2, 0, "�ι�°");
    }

    /// <summary>
    /// ���ü� ������ ������Ʈ �Լ�ȭ
    /// <para>���� ���ý�Ʈ �����Ͽ� ó����(���� ó�� ����)</para>
    /// </summary>
    /// <remarks>
    /// ���ü� ó���� �Լ��� ����� ó���Ѵ�.
    /// </remarks>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_ServerMultiConcurrency(
        int nDelay
        , string sStr)
    {
        //�񵿱� ó��
        Task.Run(() =>
        {
            List<TestOC2> findTarget;

            using (ModelsDbContextTable db1 = new ModelsDbContextTable())
            {
                //��� ����Ʈ
                findTarget = db1.TestOC2.ToList();

                if (null != findTarget)
                {
                    GlobalStatic.OC_Util.SaveChanges_Update_MultiDbContext<TestOC2>(
                        -1
                        , ref findTarget
                        , (TestOC2 item) =>
                        {//�� �����ۿ� ���� ����

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
    /// ȭ�鿡 �����͸� ǥ���Ѵ�.
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
        {//�ٸ� �������.
            this.Invoke(new Action(
                delegate ()
                {
                    this.ViewUi(findOC1, findOC2, findOC2_2, findOC3);
                }));
        }
        else
        {//���� �������.
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