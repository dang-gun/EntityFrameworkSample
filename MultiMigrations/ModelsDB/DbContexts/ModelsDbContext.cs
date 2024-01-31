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

        //연결 문자열이 없어도 마이그레이션 생성은 가능하다.
        //하지만 몇몇 동작이 재대로 되지 않는다.(예> Remove-Migration)

        switch (GlobalDb.DBType)
		{
			case UseDbType.Sqlite:
				options.UseSqlite(GlobalDb.DBString);
				break;
			case UseDbType.Mssql:
                options.UseSqlServer(GlobalDb.DBString);
                break;

			case UseDbType.InMemory:
				options.UseInMemoryDatabase(GlobalDb.DBString);
				break;

			default:
				break;
		}
	}

	/// <summary>
	/// 테스트1 데이터
	/// </summary>
    public DbSet<Test1Model> Test1Model { get; set; }

    /// <summary>
    /// 테스트2 데이터
    /// </summary>
    public DbSet<Test2Model> Test2Model { get; set; }


    /// <summary>
    /// 데이터 넣기 동작
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        //테스트1 데이터 한개 삽입
        modelBuilder.Entity<Test1Model>().HasData(
		new Test1Model
		{
			idTest1Model = 1,
			Int = 1,
			Str = "Test",
			Date = DateTime.Now,
		});

        //테스트2 데이터 한개 삽입
        modelBuilder.Entity<Test2Model>().HasData(
        new Test2Model
        {
            idTest2Model = 1,
            idTest1Model = 1,
        });
    }
}
