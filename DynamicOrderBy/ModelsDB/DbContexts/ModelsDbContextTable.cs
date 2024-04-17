using Microsoft.EntityFrameworkCore;

using DynamicOrderBy.TableModels;
using EntityFrameworkSample.DB.Models;

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
    /// 테스트용 테이블
    /// </summary>
    public DbSet<TestOrderBy> TestOrderBy { get; set; }
    /// <summary>
    /// 테스트용 테이블 - 많은 데이터
    /// </summary>

    public DbSet<TestOrderBy_Big> TestOrderBy_Big { get; set; }

    /// <summary>
    /// 데이터 넣기 동작
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
    }
}
