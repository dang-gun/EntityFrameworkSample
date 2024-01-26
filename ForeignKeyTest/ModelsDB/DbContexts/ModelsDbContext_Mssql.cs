using System;
using Global.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ModelsDB;

/// <summary>
/// mssql전용 컨텍스트
/// </summary>
///<remarks>
/// Add-Migration InitialCreate -Context ModelsDB.ModelsDbContext_Mssql -OutputDir Migrations/Mssql 
/// Remove-Migration -Context ModelsDB.ModelsDbContext_Mssql
/// Update-Database -Context ModelsDbContext_Mssql
/// Update-Database -Context ModelsDbContext_Mssql -Migration 0
///</remarks>
public class ModelsDbContext_Mssql : ModelsDbContext
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_Mssql(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
    }

	/// <summary>
	/// 
	/// </summary>
	public ModelsDbContext_Mssql()
	{
	}
}

/// <summary>
///  mssql전용 컨텍스트 팩토리
/// </summary>
public class ModelsDbContext_MssqlFactory
	: IDesignTimeDbContextFactory<ModelsDbContext_Mssql>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	public ModelsDbContext_Mssql CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<ModelsDbContext> optionsBuilder
			= new DbContextOptionsBuilder<ModelsDbContext>();

		return new ModelsDbContext_Mssql(optionsBuilder.Options);
	}
}