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
		//Console.WriteLine($"OnConfiguring DbType : {GlobalDb.DBType}");

        switch (ModelDllGlobal.DBType)
		{
			case UseDbType.Sqlite:
				options.UseSqlite(ModelDllGlobal.DBString);
				break;
			case UseDbType.Mssql:
				options.UseSqlServer(ModelDllGlobal.DBString);
				break;

			case UseDbType.InMemory:
                options.UseInMemoryDatabase("TestDb");
                break;

            default:
				break;
		}
	}

	/// <summary>
	/// 테스트1 블로그
	/// </summary>
    public DbSet<ForeignKeyTest1_Blog> ForeignKeyTest1_Blog { get; set; }
    /// <summary>
    /// 테스트1 포스트
    /// </summary>
    public DbSet<ForeignKeyTest1_Post> ForeignKeyTest1_Post { get; set; }

    /// <summary>
    /// 테스트2 블로그 - 외래키 리스트 연결안함
    /// </summary>
    public DbSet<ForeignKeyTest2_Blog> ForeignKeyTest2_Blog { get; set; }
    /// <summary>
    /// 테스트2 포스트
    /// </summary>
    public DbSet<ForeignKeyTest2_Post> ForeignKeyTest2_Post { get; set; }

	/// <summary>
	/// 테스트3 블로그 - 다른 네임스페이스 지정
	/// </summary>
	public DbSet<ForeignKeyTest3_Blog> ForeignKeyTest3_Blog { get; set; }
	/// <summary>
	/// 테스트3 포스트
	/// </summary>
	public DbSet<ForeignKeyTest3_Post> ForeignKeyTest3_Post { get; set; }


	/// <summary>
	/// 
	/// </summary>
	/// <param name="modelBuilder"></param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
    }
}
