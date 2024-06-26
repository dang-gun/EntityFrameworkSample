﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using ModelsDB.MultiMigrations;
using Global.DB;


namespace ModelsDB;

/// <summary>
/// InMomey전용 컨텍스트
/// </summary>
/// <remarks>
/// InMomey는 마이그레이션 개념이 없다.
/// </remarks>
public class ModelsDbContext_InMemory : ModelsDbContext
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_InMemory(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
        GlobalDb.DbStringLoad(UseDbType.InMemory);
    }
	/// <summary>
	/// 
	/// </summary>
	public ModelsDbContext_InMemory()
	{
	}
}

/// <summary>
/// Sqlite전용 컨텍스트 팩토리
/// </summary>
public class ModelsDbContext_InMomeyFactory
    : IDesignTimeDbContextFactory<ModelsDbContext_InMemory>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	public ModelsDbContext_InMemory CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<ModelsDbContext> optionsBuilder
			= new DbContextOptionsBuilder<ModelsDbContext>();

		return new ModelsDbContext_InMemory(optionsBuilder.Options);
	}
}