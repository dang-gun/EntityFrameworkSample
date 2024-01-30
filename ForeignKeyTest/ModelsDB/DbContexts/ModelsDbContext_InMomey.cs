using System;
using Global.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ModelsDB;

/// <summary>
/// InMomey전용 컨텍스트
/// </summary>
/// <remarks>
/// InMomey는 마이그레이션 개념이 없다.
/// </remarks>
public class ModelsDbContext_InMomey : ModelsDbContext
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_InMomey(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
		ModelDllGlobal.DBType = UseDbType.InMemory;
    }
	/// <summary>
	/// 
	/// </summary>
	public ModelsDbContext_InMomey()
	{
	}
}

/// <summary>
/// Sqlite전용 컨텍스트 팩토리
/// </summary>
public class ModelsDbContext_InMomeyFactory
    : IDesignTimeDbContextFactory<ModelsDbContext_InMomey>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	public ModelsDbContext_InMomey CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<ModelsDbContext> optionsBuilder
			= new DbContextOptionsBuilder<ModelsDbContext>();

		return new ModelsDbContext_InMomey(optionsBuilder.Options);
	}
}