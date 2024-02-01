using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Global.DB;
using ModelsDB.MultiMigrations;

namespace ModelsDB;

/// <summary>
/// mssql전용 컨텍스트
/// </summary>
///<remarks>
/// Add-Migration InitialCreate -Context ModelsDbContext_Postgresql -OutputDir Migrations/Postgresql
/// Remove-Migration -Context ModelsDbContext_Postgresql
/// Update-Database -Context ModelsDbContext_Postgresql
/// Update-Database -Context ModelsDbContext_Postgresql -Migration 0
///</remarks>
public class ModelsDbContext_Postgresql : ModelsDbContext
{
	/// <summary>
	/// ef 명령을 직접 사용하면 여기로 들어와 진다.
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_Postgresql(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{


        if (UseDbType.PostgreSQL != GlobalDb.DBType)
        {//기존 DBType과 다르다.

            //DB 연결정보를 다시 불러온다.
            DbContextDefaultInfo_Postgresql newDbInfo = new DbContextDefaultInfo_Postgresql();
			GlobalDb.DBString = newDbInfo.DBString;
		}

        GlobalDb.DBType = UseDbType.PostgreSQL;

        //https://duongnt.com/datetime-net6-postgresql/
        //https://stackoverflow.com/questions/69961449/net6-and-datetime-problem-cannot-write-datetime-with-kind-utc-to-postgresql-ty
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    /// <summary>
    /// GlobalDb.DBString에 설정된 정보로 컨택스트 생성
    /// </summary>
	/// <remarks>
	/// 약간의 성능이라도 높이기 위해 GlobalDb.DBString의 무결성 검사를 하지 않는다.
	/// <para>이 생성자를 호출하기 전에 GlobalDb.DBString에 정확한 연결문자를 넣어야 한다.</para>
	/// </remarks>
    public ModelsDbContext_Postgresql()
	{
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}

/// <summary>
///  Postgre sql전용 컨텍스트 팩토리
/// </summary>
public class ModelsDbContext_PostgresqlFactory
    : IDesignTimeDbContextFactory<ModelsDbContext_Postgresql>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	public ModelsDbContext_Postgresql CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<ModelsDbContext> optionsBuilder
			= new DbContextOptionsBuilder<ModelsDbContext>();

		return new ModelsDbContext_Postgresql(optionsBuilder.Options);
	}
}