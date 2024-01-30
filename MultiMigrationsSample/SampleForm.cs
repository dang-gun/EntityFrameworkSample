using System.Text;

using Microsoft.EntityFrameworkCore;


using ModelsDB;
using MultiMigrationsSample.Models;
using Newtonsoft.Json;


namespace MultiMigrationsSample;

public partial class SampleForm : Form
{
    public SampleForm()
    {
        InitializeComponent();

        this.radioSqlite_CheckedChanged(null, null);
    }

    private void radioSqlite_CheckedChanged(object? sender, EventArgs? e)
    {
        GlobalDb.DbType = TargetDbType.Sqlite;

        GlobalDb.DbConnectString
            = "Data Source=Test.db";

        using (DbModel_SqliteContext db1 = new DbModel_SqliteContext())
        {
            db1.Database.Migrate();
        }
    }

    private void radioMssql_CheckedChanged(object sender, EventArgs e)
    {
        GlobalDb.DbType = TargetDbType.Mssql;

        //설정 파일 읽기
        string sJson = File.ReadAllText("SettingInfo_gitignore.json");
        SettingInfoModel? loadSetting = JsonConvert.DeserializeObject<SettingInfoModel>(sJson);


        //GlobalDb.DbConnectString = "Server=[주소];DataBase=[데이터 베이스];UId=[아이디];pwd=[비밀번호]";
        GlobalDb.DbConnectString = loadSetting!.ConnectionString_Mssql;

        using (DbModel_MssqlContext db1 = new DbModel_MssqlContext())
        {
            db1.Database.Migrate();
        }
    }


    private void btnSelectAll_Click(object sender, EventArgs e)
    {
        using (DbModelContext db1 = new DbModelContext())
        {
            List<DbData1Model> findDbData1ModelList
                = db1.DbData1Model.ToList();

            StringBuilder sbTemp = new StringBuilder();
            foreach (DbData1Model item in findDbData1ModelList)
            {
                sbTemp.Append($"index = {item.idDbData1Model}, Name = {item.Name},    Age = {item.Age} {Environment.NewLine}");
            }
            this.txtDbData1Model_Log.Text = sbTemp.ToString();




            List<DbData2Model> findDbData2ModelList
                = db1.DbData2Model.ToList();

            sbTemp = new StringBuilder();
            foreach (DbData2Model item in findDbData2ModelList)
            {
                sbTemp.Append($"index = {item.idDbData2Model}, FirstName = {item.FirstName},    LastName = {item.LastName} {Environment.NewLine}");
            }
            this.txtDbData2Model_Log.Text = sbTemp.ToString();
        }
    }

    #region DbData1Model 관련

    private void btnDbData1Model_Add_Click(object sender, EventArgs e)
    {
        int nAge = 0;
        int.TryParse(this.txtDbData1Model_Age.Text, out nAge);

        using (DbModelContext db1 = new DbModelContext())
        {
            db1.DbData1Model.Add(
                new DbData1Model()
                {
                    Name = this.txtDbData1Model_Name.Text,
                    Age = nAge,
                });

            db1.SaveChanges();
        }

        this.txtDbData1Model_Log.Text
            = $"Add Data : Name = {this.txtDbData1Model_Name.Text}, Age = {nAge}";
    }
    #endregion

    #region DbData2Model 관련
    private void btnDbData2Model_Add_Click(object sender, EventArgs e)
    {


        using (DbModelContext db1 = new DbModelContext())
        {
            db1.DbData2Model.Add(
                new DbData2Model()
                {
                    FirstName = this.txtDbData2Model_FirstName.Text,
                    LastName = this.txtDbData2Model_LastName.Text,
                });

            db1.SaveChanges();
        }

        this.txtDbData2Model_Log.Text
            = $"Add Data : First Name = {this.txtDbData2Model_FirstName.Text}, Last Name = {this.txtDbData2Model_LastName.Text}";
    }
    #endregion


    
}
