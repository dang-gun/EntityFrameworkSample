using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using EntityFrameworkSample.DB.MultiMigrations;

namespace EntityFrameworkSample.DB.Models;

/// <summary>
/// InMomey전용 컨텍스트
/// </summary>
/// <remarks>
/// InMomey는 마이그레이션 개념이 없다.
/// </remarks>
public class ModelsDbContext_InMemory : ModelsDbContextTable
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_InMemory(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
		GlobalDb.DBType = UseDbType.InMemory;

        if (string.Empty == GlobalDb.DBString)
        {
            DbContextDefaultInfo_InMemory newDbInfo = new DbContextDefaultInfo_InMemory();
            GlobalDb.DBString = newDbInfo.DBString;
        }
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