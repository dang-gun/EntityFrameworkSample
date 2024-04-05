using EntityFrameworkSample.DB.MultiMigrations;
using Microsoft.EntityFrameworkCore;


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
    /// GlobalDb.DBType을 기준으로 GlobalDb.DBString을 다시 불러 저장한다.
    /// </summary>
    /// <remarks>
    /// DB정보를 다시 불러와야 할 상황에서만 사용하는 것이 좋다.
    /// </remarks>
    /// <param name="bDbStringLoad"></param>
    public ModelsDbContext(bool bDbStringLoad)
    {
        if(true == bDbStringLoad)
        {
            DbContextDefaultInfoInterface newDbInfo 
                = new DbContextDefaultInfo_Temp();

            switch (GlobalDb.DBType)
            {
                case UseDbType.SQLite:
                    newDbInfo = new DbContextDefaultInfo_InMemory();
                    break;

                case UseDbType.MSSQL:
                    newDbInfo = new DbContextDefaultInfo_Mssql();
                    break;

                case UseDbType.PostgreSQL:
                    newDbInfo = new DbContextDefaultInfo_Postgresql();
                    break;

                case UseDbType.MariaDB:
                    newDbInfo = new DbContextDefaultInfo_Mariadb();
                    break;

                case UseDbType.InMemory:
                    newDbInfo = new DbContextDefaultInfo_InMemory();
                    break;
            }//end switch

            GlobalDb.DBString = newDbInfo.DBString;
        }
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


    /// <summary>
    /// 부모
    /// </summary>
    public DbSet<AutoIncreases_Test1> AutoIncreases_Test1 { get; set; }
    /// <summary>
    /// 자식 - 정상
    /// </summary>

    public DbSet<AutoIncreases_Test2> AutoIncreases_Test2 { get; set; }
    /// <summary>
    /// 자식 - 비정상
    /// </summary>
    public DbSet<AutoIncreases_Test3> AutoIncreases_Test3 { get; set; }
    

    /// <summary>
    /// 데이터 넣기 동작
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.Entity<AutoIncreases_Test1>().HasData(
            new AutoIncreases_Test1
            {
                idAutoIncreases_Test1 = 1,
                Name = "Test",
            });
    }
}
