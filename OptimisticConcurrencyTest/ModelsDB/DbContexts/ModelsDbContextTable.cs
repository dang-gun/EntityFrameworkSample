using Microsoft.EntityFrameworkCore;

using EntityFrameworkSample.DB.MultiMigrations;
using OptimisticConcurrencyTest.TableModels;

namespace EntityFrameworkSample.DB.Models;

/// <summary>
/// 공통 컨택스트
/// </summary>
public class ModelsDbContextTable : ModelsDbContext
{

#pragma warning disable CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
	/// <summary>
	/// 
	/// </summary>
	public ModelsDbContextTable()
	{
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public ModelsDbContextTable(DbContextOptions<ModelsDbContext> options)
		: base(options)
	{
        //Console.WriteLine($"ModelsDbContext : {GlobalDb.DBString}");
    }
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.

    
    public DbSet<TestOC1> TestOC1 { get; set; }
    public DbSet<TestOC2> TestOC2 { get; set; }
    public DbSet<TestOC3> TestOC3 { get; set; }

    /// <summary>
    /// 데이터 넣기 동작
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
        modelBuilder.Entity<TestOC2>().HasData(
            new TestOC2
            {
                idTestOC2 = 2,
                Int = 22,
                Str = "str 22",
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
