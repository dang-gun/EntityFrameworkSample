using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using EntityFrameworkSample.DB.MultiMigrations;

namespace EntityFrameworkSample.DB.Models;

/// <summary>
/// Sqlite전용 컨텍스트
/// </summary>
/// <remarks>
/// Add-Migration InitialCreate -Context ModelsDbContext_Sqlite -OutputDir Migrations/Sqlite
/// Remove-Migration -Context ModelsDbContext_Sqlite
/// Update-Database -Context ModelsDbContext_Sqlite -Migration 0
/// Update-Database -Context ModelsDbContext_Sqlite
/// </remarks>
public class ModelsDbContext_Sqlite : ModelsDbContextTable
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_Sqlite(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
        if (UseDbType.SQLite != GlobalDb.DBType
			|| string.Empty == GlobalDb.DBString)
        {//기존 DBType과 다르다.
			//DB 연결 문자열 정보가 없다.

            //DB 연결정보를 다시 불러온다.
            DbContextDefaultInfo_Sqlite newDbInfo = new DbContextDefaultInfo_Sqlite();
			GlobalDb.DBString = newDbInfo.DBString;
        }

        GlobalDb.DBType = UseDbType.SQLite;
    }

    /// <summary>
    /// GlobalDb.DBString에 설정된 정보로 컨택스트 생성
    /// <para>사용은 ModelsDbContextTable로 한다.</para>
	/// </summary>
    public ModelsDbContext_Sqlite()
	{
	}
}

/// <summary>
/// Sqlite전용 컨텍스트 팩토리
/// </summary>
public class ModelsDbContext_SqliteFactory
	: IDesignTimeDbContextFactory<ModelsDbContext_Sqlite>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	public ModelsDbContext_Sqlite CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<ModelsDbContext> optionsBuilder
			= new DbContextOptionsBuilder<ModelsDbContext>();

		return new ModelsDbContext_Sqlite(optionsBuilder.Options);
	}
}