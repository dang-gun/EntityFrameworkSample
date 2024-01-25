using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using EfTest.Models;
using ListField.Global;
using ModelsDB;

namespace ListField;

internal class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	static void Main(string[] args)
	{
        Console.WriteLine("Hello, Entity Framework List Field!");

        //���� ���� �б�
        string sJson = File.ReadAllText("SettingInfo_gitignore.json");
        SettingInfoModel? loadSetting 
            = JsonConvert.DeserializeObject<SettingInfoModel>(sJson);

        if(null == loadSetting)
        {
            GlobalStatic.DbType = "sqlite";
        }
        else
        {
            //GlobalStatic.DbType = "sqlite";
            GlobalStatic.DbType = "mssql";
        }

        Console.WriteLine("DB Setting....");
        //db ���� �� ���̱׷��̼� ����
        switch (GlobalStatic.DbType)
        {
            case "sqlite":
                //Add-Migration InitialCreate -Context ModelsDB.DbModel_SqliteContext -OutputDir Migrations/Sqlite
                //Remove-Migration -Context ModelsDB.DbModel_SqliteContext
                GlobalStatic.DbConnectString
                    = "Data Source=Test.db";

                using (DbModel_SqliteContext db1 = new DbModel_SqliteContext())
                {
                    db1.Database.Migrate();
                }
                break;

            case "mssql":
                //Add-Migration InitialCreate -Context ModelsDB.DbModel_MssqlContext -OutputDir Migrations/Mssql
                //Update-Database -Context ModelsDB.DbModel_MssqlContext -Migration 0	
                //Remove-Migration -Context ModelsDB.DbModel_MssqlContext
                //ModelDllGlobal.DbConnectString = "Server=[�ּ�];DataBase=[������ ���̽�];UId=[���̵�];pwd=[��й�ȣ]";
                GlobalStatic.DbConnectString = loadSetting!.ConnectionString_Mssql;

                using (DbModel_MssqlContext db2 = new DbModel_MssqlContext())
                {
                    db2.Database.Migrate();
                }
                break;
        }




        //����Ʈ�� �����ϱ�
        Console.WriteLine("List Info : ");
        List<EfList_Test2> efList_Test2s = new List<EfList_Test2>();

        using (DbModelContext db3 = new DbModelContext())
        {
            efList_Test2s = db3.EfList_Test2.ToList();
        }

        Console.WriteLine(efList_Test2s.Count);
        Console.WriteLine(efList_Test2s[0].ListString2);
    }
}