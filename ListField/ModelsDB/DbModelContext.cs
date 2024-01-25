using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ListField.Global;
using System.Text.Json;
using EfTest.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ModelsDB;

public class DbModelContext : DbContext
{
#pragma warning disable CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
    public DbModelContext(DbContextOptions<DbModelContext> options)
            : base(options)
    {
    }

    public DbModelContext()
    {
    }

#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        switch (GlobalStatic.DbType)
        {
            case "sqlite":
                options.UseSqlite(GlobalStatic.DbConnectString);
                break;
            case "mssql":
                options.UseSqlServer(GlobalStatic.DbConnectString);
                break;

        }
    }

	//public DbSet<EfList_Test1> EfList_Test1 { get; set; }
	public DbSet<EfList_Test2> EfList_Test2 { get; set; }


	/// <summary>
	/// 
	/// </summary>
	/// <param name="modelBuilder"></param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		//에러 확인
		//     modelBuilder.Entity<EfList_Test1>().HasData(
		//         new EfList_Test1
		//         {
		//             idEfList_Test1 = 1,
		//             ListInt1 = new int[] { 1, 2, 3 },
		//             ListString1= new string[] { "a", "b", "c" },
		//             ListString2= new List<string>{ "a", "b", "c" },
		//});

		//문자열 배열
		modelBuilder.Entity<EfList_Test2>()
			.Property(p => p.ListString1)
			.HasConversion(
				//배열을 콤마(,)로 구분하는 문자열로 바꾸기
				c => string.Join(',', c)
				//콤마(,)로 구분된 문자열을 배열로 변환
				,c => c.Split(',', StringSplitOptions.RemoveEmptyEntries)
				, new ValueComparer<string[]>(
					(c1, c2) => c1!.SequenceEqual(c2!)
					, c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode()))
					, c => c.ToArray()));

		
		//문자열 리스트
		modelBuilder.Entity<EfList_Test2>()
			.Property(p => p.ListString2)
			.HasConversion(
				//배열을 콤마(,)로 구분하는 문자열로 바꾸기
				c => string.Join(',', c)
				//콤마(,)로 구분된 문자열을 리스트로 변환
				, c => c.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
				, new ValueComparer<List<string>>(
					(c1, c2) => c1!.SequenceEqual(c2!)
					, c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode()))
					, c => c.ToList()));


		//json 리스트
		modelBuilder.Entity<EfList_Test2>()
			.Property(p => p.ListJson1)
			.HasConversion(
				//JSON 모델을 리스트로 사용하는 문자열로 변환
				c => JsonSerializer.Serialize(c, new JsonSerializerOptions())
				//JSON 모델을 리스트를 리스트 모델로 전환
				, c => JsonSerializer.Deserialize<List<JsonTestModel>>(c, new JsonSerializerOptions())!
				, new ValueComparer<List<JsonTestModel>>(
					(c1, c2) => c1!.SequenceEqual(c2!)
					, c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode()))
					, c => c.ToList()));
		
		//데이터 넣기
		modelBuilder.Entity<EfList_Test2>().HasData(
			new EfList_Test2
			{
				idEfList_Test2 = 1,
				ListString1 = new string[] { "a", "b", "c" },
				ListString2 = new List<string> { "a", "b", "c" },
				ListJson1 = new List<JsonTestModel>() { new JsonTestModel() {id=1, Name="test", Age=10 } },
			});

		modelBuilder.Entity<EfList_Test2>().HasData(
			new EfList_Test2
			{
				idEfList_Test2 = 2,
				ListString1 = new string[] { "a", "b", "c" },
				ListString2 = new List<string> { "a", "b", "c" },
				ListJson1 = new List<JsonTestModel>() { new JsonTestModel() { id = 1, Name = "test", Age = 10 } },
			});

		modelBuilder.Entity<EfList_Test2>().HasData(
			new EfList_Test2
			{
				idEfList_Test2 = 3,
				ListString1 = new string[] { "a", "b", "c" },
				ListString2 = new List<string> { "a", "b", "c" },
				ListJson1 = new List<JsonTestModel>() { new JsonTestModel() { id = 3, Name = "test", Age = 10 } },
			});

	}
}