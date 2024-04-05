using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using EntityFrameworkSample.DB.MultiMigrations;

namespace EntityFrameworkSample.DB.Models;

//public class ModelsDbContext_InMemory2_base : DbContext
//{
//	public ModelsDbContext_InMemory2_base(DbContextOptions options)
//		: base(options)
//	{

//	}
//}

///// <summary>
///// InMomey전용 컨텍스트
///// </summary>
///// <remarks>
///// InMomey는 마이그레이션 개념이 없다.
///// </remarks>
//public class ModelsDbContext_InMemory2<T> where T : ModelsDbContext_InMemory2_base
//{
//	/// <summary>
//	/// 
//	/// </summary>
//	/// <param name="options"></param>
//	public ModelsDbContext_InMemory2(DbContextOptions<T> options)
//		: base(options)
//	{
//		GlobalDb.DBType = UseDbType.InMemory;

//        if (string.Empty == GlobalDb.DBString)
//        {
//            DbContextDefaultInfo_InMemory newDbInfo = new DbContextDefaultInfo_InMemory();
//            GlobalDb.DBString = newDbInfo.DBString;
//        }
//    }
//	/// <summary>
//	/// 
//	/// </summary>
//	public ModelsDbContext_InMemory2()
//	{
//	}
//}

///// <summary>
///// Sqlite전용 컨텍스트 팩토리
///// </summary>
//public class ModelsDbContext_InMomey2Factory
//    : IDesignTimeDbContextFactory<ModelsDbContext_InMemory2>
//{
//	/// <summary>
//	/// 
//	/// </summary>
//	/// <param name="args"></param>
//	/// <returns></returns>
//	public ModelsDbContext_InMemory2 CreateDbContext(string[] args)
//	{
//		DbContextOptionsBuilder<ModelsDbContext> optionsBuilder
//			= new DbContextOptionsBuilder<ModelsDbContext>();

//		return new ModelsDbContext_InMemory2(optionsBuilder.Options);
//	}
//}