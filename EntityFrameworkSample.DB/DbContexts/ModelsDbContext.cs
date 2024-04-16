using Microsoft.EntityFrameworkCore;

using EntityFrameworkSample.DB.MultiMigrations;

namespace EntityFrameworkSample.DB.Models;

/// <summary>
/// 공통 컨택스트
/// </summary>
public class ModelsDbContext : DbContext
{

#pragma warning disable CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
	/// <summary>
	/// 
	/// </summary>
	public ModelsDbContext()
	{
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public ModelsDbContext(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
        //Console.WriteLine($"ModelsDbContext : {GlobalDb.DBString}");
    }
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
        //Console.WriteLine($"OnConfiguring DbType : {GlobalDb.DBType}");

        //연결 문자열이 없어도 마이그레이션 생성은 가능하다.
        //하지만 몇몇 동작이 재대로 되지 않는다.(예> Remove-Migration)

        switch (GlobalDb.DBType)
		{
			case UseDbType.SQLite:
				options.UseSqlite(GlobalDb.DBString);
				break;
			case UseDbType.MSSQL:
                options.UseSqlServer(GlobalDb.DBString);
                break;
            case UseDbType.PostgreSQL:
                options.UseNpgsql(GlobalDb.DBString);
                break;
            case UseDbType.MariaDB:
                options.UseMySql(
                    GlobalDb.DBString
                    , new MySqlServerVersion(new Version(11, 1, 2)));
                break;

            case UseDbType.InMemory:
				options.UseInMemoryDatabase(GlobalDb.DBString);
				break;

			default:
				break;
		}
	}


}
