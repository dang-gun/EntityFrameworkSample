using Microsoft.EntityFrameworkCore;

using ForeignKeySpeedTest.TableModels;

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


    public DbSet<ForeignKeyTest1_Blog> ForeignKeyTest1_Blog { get; set; }
    public DbSet<ForeignKeyTest1_Post> ForeignKeyTest1_Post { get; set; }

    public DbSet<ForeignKeyTest2_Blog> ForeignKeyTest2_Blog { get; set; }
    public DbSet<ForeignKeyTest2_Post> ForeignKeyTest2_Post { get; set; }

    public DbSet<ForeignKeyTest3_Blog> ForeignKeyTest3_Blog { get; set; }
    public DbSet<ForeignKeyTest3_Post> ForeignKeyTest3_Post { get; set; }

    /// <summary>
    /// 데이터 넣기 동작
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
    }
}
