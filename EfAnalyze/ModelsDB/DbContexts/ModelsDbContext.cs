using System;
using System.Diagnostics;
using EfAnalyze.Globals;
using Global.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

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
        switch (GlobalDb.DBType)
		{
			case UseDbType.Sqlite:
				options.UseSqlite(GlobalDb.DBString);
				break;
			case UseDbType.Mssql:
				options.UseSqlServer(GlobalDb.DBString);
				break;

			case UseDbType.Memory:
			default:
				//options.UseInMemoryDatabase("TestDb");
				break;
		}


        //https://learn.microsoft.com/ko-kr/ef/core/logging-events-diagnostics/simple-logging

        //options.LogTo(Console.WriteLine);
        options.LogTo(sMsg => Debug.WriteLine(sMsg), LogLevel.Information);
        //options.LogTo(
        //    sMsg => Debug.WriteLine(sMsg)
        //    , new[] 
        //    {
        //        Microsoft.EntityFrameworkCore.Update.
        //    });
        


        options.EnableSensitiveDataLogging();
    }


    /// <summary>
    /// 테스트용 테이블 - 클라이언트 관리 토큰
    /// </summary>
    public DbSet<TestOC1> TestOC1 { get; set; }
    /// <summary>
    /// 테스트용 테이블 - SQL 서버 관리 토큰
    /// </summary>

    public DbSet<TestOC2> TestOC2 { get; set; }
    /// <summary>
    /// 테스트용 테이블 - 관리토큰 없음
    /// </summary>
    public DbSet<TestOC3> TestOC3 { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.Entity<TestOC1>().HasData(
			new TestOC1
            {
                idTestOC1 = 1,
                Int = 1,
                Str = "str 1",
            });

        modelBuilder.Entity<TestOC2>().HasData(
            new TestOC2
            {
                idTestOC2 = 1,
                Int = 2,
                Str = "str 2",
            });
        modelBuilder.Entity<TestOC3>().HasData(
            new TestOC3
            {
                idTestOC3 = 1,
                Int = 3,
                Str = "str 3",
            });
    }
}
