using System;
using Global.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ModelsDB;

/// <summary>
/// 
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
	}
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.

	/// <summary>
	/// 
	/// </summary>
	/// <param name="options"></param>
	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
        //options.UseSqlite(GlobalDb.DBString);
        options.UseSqlite("Data Source=Test.db");

        switch (GlobalDb.DBType)
		{
			case UseDbType.Sqlite:
				options.UseSqlite(GlobalDb.DBString);
				break;
			case UseDbType.Mssql:
				//options.UseSqlServer(GlobalDb.DBString);
				break;

			case UseDbType.Memory:
			default:
				//options.UseInMemoryDatabase("TestDb");
				break;
		}
	}

	/// <summary>
	/// 테스트용 테이블
	/// </summary>
    public DbSet<TestOrderBy> TestOrderBy { get; set; }
    /// <summary>
    /// 테스트용 테이블 - 많은 데이터
    /// </summary>

    public DbSet<TestOrderBy_Big> TestOrderBy_Big { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		

    }
}
