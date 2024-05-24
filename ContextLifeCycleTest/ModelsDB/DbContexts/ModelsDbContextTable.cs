using Microsoft.EntityFrameworkCore;

using EntityFrameworkSample.DB.Models;
using TableModels;

namespace ModelsDB;

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
        //System.Console.WriteLine($"ModelsDbContext : {GlobalDb.DBString}");
    }
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.

    /// <summary>
    /// 테스트용 테이블1
    /// </summary>
    public DbSet<TestTable1> TestTable1 { get; set; }

    /// <summary>
    /// 테스트용 테이블2
    /// </summary>
    public DbSet<TestTable2> TestTable2 { get; set; }

    /// <summary>
    /// 테스트용 테이블3
    /// </summary>
    public DbSet<TestTable3> TestTable3 { get; set; }


    /// <summary>
    /// 데이터 넣기 동작
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
    }
}
