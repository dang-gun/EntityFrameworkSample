using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiMigrationsSample;
using MultiMigrationsSample.Models;

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
        switch (GlobalDb.DbType)
        {
            case TargetDbType.Mssql:
                options.UseSqlServer(GlobalDb.DbConnectString);

                break;
            case TargetDbType.Sqlite:
                options.UseSqlite(GlobalDb.DbConnectString);
                break;
        }
    }

    public DbSet<DbData1Model> DbData1Model { get; set; }

    public DbSet<DbData2Model> DbData2Model { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbData1Model>().HasData(
            new DbData1Model
            {
                idDbData1Model = 1,
                Name = "Test",
                Age = 1,
            });

        modelBuilder.Entity<DbData2Model>().HasData(
            new DbData2Model
            {
                idDbData2Model = 1,
                FirstName = "T",
                LastName = "est",
            });
    }
}


/// <summary>
/// https://stackoverflow.com/a/60602620/6725889
/// </summary>
//public class YourDbContextFactory : IDesignTimeDbContextFactory<DbModelContext>
//{
//    public DbModelContext CreateDbContext(string[] args)
//    {
//        DbContextOptionsBuilder<DbModelContext> optionsBuilder
//            = new DbContextOptionsBuilder<DbModelContext>();
//        //optionsBuilder.UseSqlite(DGAuthServerGlobal.DbConnectString);
//        Console.WriteLine("aaaaa - " + ModelDllGlobal.DbType);

//        if (string.Empty != ModelDllGlobal.DbConnectString)
//        {


//            switch (ModelDllGlobal.DbType)
//            {
//                case DbType.Mssql:
//                    optionsBuilder.UseSqlServer(ModelDllGlobal.DbConnectString);
//                    break;
//                case DbType.Sqlite:
//                    optionsBuilder.UseSqlite(ModelDllGlobal.DbConnectString);
//                    break;
//            }
//        }

//        return new DbModelContext(optionsBuilder.Options);
//    }
//}
