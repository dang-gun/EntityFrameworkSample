using ListField.Global;
using EfTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;

namespace ModelsDB;

public class DbModel_MssqlContext : DbModelContext
{
	public DbModel_MssqlContext(DbContextOptions<DbModelContext> options)
		: base(options)
	{
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

		//설정 파일 읽기
		string sJson = File.ReadAllText("SettingInfo_gitignore.json");
		SettingInfoModel? loadSetting = JsonConvert.DeserializeObject<SettingInfoModel>(sJson);

		//Add-Migration InitialCreate -Context ModelsDB.DbModel_MssqlContext -OutputDir Migrations/Mssql
		//Update-Database -Context ModelsDB.DbModel_MssqlContext -Migration 0
		//"Server=[주소];DataBase=[데이터 베이스];UId=[아이디];pwd=[비밀번호]"
		GlobalStatic.DbType = "mssql";
		GlobalStatic.DbConnectString = loadSetting!.ConnectionString_Mssql;

		optionsBuilder.UseSqlServer(GlobalStatic.DbConnectString);

		return new DbModel_MssqlContext(optionsBuilder.Options);
	}
}
