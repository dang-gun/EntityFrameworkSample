using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using EntityFrameworkSample.DB.MultiMigrations;

namespace EntityFrameworkSample.DB.Models;

/// <summary>
/// mssql전용 컨텍스트
/// </summary>
///<remarks>
/// Add-Migration InitialCreate -Context ModelsDbContext_Mssql -OutputDir Migrations/Mssql 
/// Remove-Migration -Context ModelsDbContext_Mssql
/// Update-Database -Context ModelsDbContext_Mssql
/// Update-Database -Context ModelsDbContext_Mssql -Migration 0
///</remarks>
public class ModelsDbContext_Mssql : ModelsDbContext
{
	/// <summary>
	/// ef 명령을 직접 사용하면 여기로 들어와 진다.
	/// </summary>
	/// <param name="options"></param>
	public ModelsDbContext_Mssql(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
        if (UseDbType.MSSQL != GlobalDb.DBType 
			|| string.Empty == GlobalDb.DBString)
        {//기존 DBType과 다르다.
			//DB 연결 문자열 정보가 없다.

            //DB 연결정보를 다시 불러온다.
            DbContextDefaultInfo_Mssql newDbInfo = new DbContextDefaultInfo_Mssql();
			GlobalDb.DBString = newDbInfo.DBString;
		}

        GlobalDb.DBType = UseDbType.MSSQL;
    }

    /// <summary>
    /// GlobalDb.DBString에 설정된 정보로 컨택스트 생성
    /// </summary>
	/// <remarks>
	/// 약간의 성능이라도 높이기 위해 GlobalDb.DBString의 무결성 검사를 하지 않는다.
	/// <para>이 생성자를 호출하기 전에 GlobalDb.DBString에 정확한 연결문자를 넣어야 한다.</para>
	/// </remarks>
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