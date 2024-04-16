using ForeignKeyTest.TableModels;
using Microsoft.EntityFrameworkCore;


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
        //System.Console.WriteLine($"ModelsDbContext : {GlobalDb.DBString}");
    }
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.

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
