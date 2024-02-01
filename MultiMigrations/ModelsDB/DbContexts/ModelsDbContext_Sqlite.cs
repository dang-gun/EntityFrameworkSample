using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Global.DB;
using ModelsDB.MultiMigrations;

namespace ModelsDB;

/// <summary>
/// Sqlite전용 컨텍스트
/// </summary>
/// <remarks>
/// Add-Migration InitialCreate -Context ModelsDbContext_Sqlite -OutputDir Migrations/Sqlite
/// Remove-Migration -Context ModelsDbContext_Sqlite
/// Update-Database -Context ModelsDbContext_Sqlite -Migration 0
/// Update-Database -Context ModelsDbContext_Sqlite
/// </remarks>
public class ModelsDbContext_Sqlite : ModelsDbContext
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_Sqlite(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
        if (UseDbType.SQLite != GlobalDb.DBType)
        {//기존 DBType과 다르다.

            //DB 연결정보를 다시 불러온다.
            DbContextDefaultInfo_Sqlite newDbInfo = new DbContextDefaultInfo_Sqlite();
			GlobalDb.DBString = newDbInfo.DBString;
        }

        GlobalDb.DBType = UseDbType.SQLite;
    }

    /// <summary>
    /// GlobalDb.DBString에 설정된 정보로 컨택스트 생성
    /// </summary>
    /// <remarks>
    /// 약간의 성능이라도 높이기 위해 GlobalDb.DBString의 무결성 검사를 하지 않는다.
    /// <para>이 생성자를 호출하기 전에 GlobalDb.DBString에 정확한 연결문자를 넣어야 한다.</para>
    /// </remarks>
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