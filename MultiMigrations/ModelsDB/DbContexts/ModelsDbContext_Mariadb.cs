using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Global.DB;
using ModelsDB.MultiMigrations;

namespace ModelsDB;

/// <summary>
/// Mariadb전용 컨텍스트
/// </summary>
///<remarks>
/// Add-Migration InitialCreate -Context ModelsDbContext_Mariadb -OutputDir Migrations/Mariadb 
/// Remove-Migration -Context ModelsDbContext_Mariadb
/// Update-Database -Context ModelsDbContext_Mariadb
/// Update-Database -Context ModelsDbContext_Mariadb -Migration 0
///</remarks>
public class ModelsDbContext_Mariadb : ModelsDbContext
{
	/// <summary>
	/// ef 명령을 직접 사용하면 여기로 들어와 진다.
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_Mariadb(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{

        if (UseDbType.MariaDB != GlobalDb.DBType 
			|| string.Empty == GlobalDb.DBString)
        {//기존 DBType과 다르다.
			//DB 연결 문자열 정보가 없다.

            //DB 연결정보를 다시 불러온다.
            DbContextDefaultInfo_Mariadb newDbInfo = new DbContextDefaultInfo_Mariadb();
			GlobalDb.DBString = newDbInfo.DBString;
		}

        GlobalDb.DBType = UseDbType.MariaDB;
    }

    /// <summary>
    /// GlobalDb.DBString에 설정된 정보로 컨택스트 생성
    /// </summary>
	/// <remarks>
	/// 약간의 성능이라도 높이기 위해 GlobalDb.DBString의 무결성 검사를 하지 않는다.
	/// <para>이 생성자를 호출하기 전에 GlobalDb.DBString에 정확한 연결문자를 넣어야 한다.</para>
	/// </remarks>
    public ModelsDbContext_Mariadb()
	{
        
    }
}

/// <summary>
///  Maria db전용 컨텍스트 팩토리
/// </summary>
public class ModelsDbContext_MariadbFactory
    : IDesignTimeDbContextFactory<ModelsDbContext_Mariadb>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	public ModelsDbContext_Mariadb CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<ModelsDbContext> optionsBuilder
			= new DbContextOptionsBuilder<ModelsDbContext>();

		return new ModelsDbContext_Mariadb(optionsBuilder.Options);
	}
}