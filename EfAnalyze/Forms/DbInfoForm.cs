using Microsoft.EntityFrameworkCore;

using EfAnalyze.Global;
using Global.DB;
using ModelsDB;
using System.Diagnostics;
using EfAnalyze.Globals;

namespace EfAnalyze.Forms;

public partial class DbInfoForm : Form
{

    public DbInfoForm()
    {
        InitializeComponent();

    }
    private void DbSetting()
    {
        //db 마이그레이션 적용
        switch (GlobalDb.DBType)
        {
            case UseDbType.Sqlite:
                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
            case UseDbType.Mssql:
                using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;

            default://기본
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
        }
    }

    #region MSSQL
    /// <summary>
    /// mssql 사용
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMssql_Use_Click(object sender, EventArgs e)
    {
        GlobalDb.DBType = UseDbType.Mssql;
        GlobalDb.DBString = txtMssql_ConnectStriong.Text;

        this.DbSetting();

        radioMssqlUse.Checked = true;
        radioSqliteUse.Checked = false;
    }
    #endregion

    #region SQLite
    private void btnSqlite_Use_Click(object sender, EventArgs e)
    {
        GlobalDb.DBType = UseDbType.Sqlite;
        GlobalDb.DBString = txtSqlite_ConnectStriong.Text;

        this.DbSetting();

        radioMssqlUse.Checked = false;
        radioSqliteUse.Checked = true;
    }
    #endregion

    public void ReloadDB()
    {

        TestOC1? findOC1 = null;
        List<TestOC2>? findOC2 = null;
        TestOC3? findOC3 = null;

        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            findOC1 = db1.TestOC1.Where(w => w.idTestOC1 == 1).FirstOrDefault();
            findOC2 = db1.TestOC2.ToList();
            findOC3 = db1.TestOC3.Where(w => w.idTestOC3 == 1).FirstOrDefault();
        }

        if (true == InvokeRequired)
        {//다른 쓰래드다.
            this.Invoke(new Action(
                delegate ()
                {
                    this.ViewUi(findOC1, findOC2, findOC3);
                }));
        }
        else
        {//같은 쓰래드다.
            this.ViewUi(findOC1, findOC2, findOC3);
        }
    }

    /// <summary>
    /// UI에 데이터 표시
    /// </summary>
    /// <param name="findOC1"></param>
    /// <param name="findOC2"></param>
    /// <param name="findOC3"></param>
    private void ViewUi(TestOC1? findOC1, TestOC2? findOC2, TestOC3? findOC3)
    {
        List<TestOC2>? listTemp = null;
        if(null != findOC2)
        {
            listTemp = new TestOC2[] { findOC2 }.ToList();
        }

        this.ViewUi(findOC1, listTemp, findOC3);
    }
    /// <summary>
    /// UI에 데이터 표시
    /// </summary>
    /// <param name="findOC1"></param>
    /// <param name="findOC2"></param>
    /// <param name="findOC3"></param>
    private void ViewUi(TestOC1? findOC1, List<TestOC2>? findOC2, TestOC3? findOC3)
    {
        if (null != findOC1)
        {
            this.txtDb_TestOC1_Int.Text = findOC1.Int.ToString();
            this.txtDb_TestOC1_Str.Text = findOC1.Str;
        }

        if (null != findOC2)
        {
            GlobalStatic.frmParent!.ViewUi_Data(findOC2);
        }

        if (null != findOC3)
        {
            this.txtDb_TestOC3_Int.Text = findOC3.Int.ToString();
            this.txtDb_TestOC3_Str.Text = findOC3.Str;
        }
    }

}