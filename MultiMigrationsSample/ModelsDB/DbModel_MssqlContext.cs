using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiMigrationsSample;
using MultiMigrationsSample.Models;
using Newtonsoft.Json;

namespace ModelsDB;

/// <summary>
/// mssql전용 컨텍스트
/// </summary>
///<remarks>
/// Add-Migration InitialCreate -Context DbModel_MssqlContext -OutputDir Migrations/Mssql 
/// Remove-Migration -Context DbModel_MssqlContext
/// Update-Database -Context DbModel_MssqlContext
/// Update-Database -Context DbModel_MssqlContext -Migration 0
///</remarks>
public class DbModel_MssqlContext : DbModelContext
{
	public DbModel_MssqlContext(DbContextOptions<DbModelContext> options)
		: base(options)
	{

		if (string.Empty == GlobalDb.DbConnectString)
		{
			//설정 파일 읽기
			string sJson = File.ReadAllText("SettingInfo_gitignore.json");
			SettingInfoModel? loadSetting = JsonConvert.DeserializeObject<SettingInfoModel>(sJson);

			GlobalDb.DbType = TargetDbType.Mssql;
			GlobalDb.DbConnectString = loadSetting!.ConnectionString_Mssql;
		}
    }

	public DbModel_MssqlContext()
	{
	}
}



public class DbContext_MssqlFactory : IDesignTimeDbContextFactory<DbModel_MssqlContext>
{
	public DbModel_MssqlContext CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<DbModelContext> optionsBuilder
			= new DbContextOptionsBuilder<DbModelContext>();

		return new DbModel_MssqlContext(optionsBuilder.Options);
	}
}
