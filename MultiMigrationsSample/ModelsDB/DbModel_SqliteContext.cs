using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiMigrationsSample;
using MultiMigrationsSample.Models;

namespace ModelsDB;

/// <summary>
/// Sqlite전용 컨텍스트
/// </summary>
/// <remarks>
/// Add-Migration InitialCreate -Context DbModel_SqliteContext -OutputDir Migrations/Sqlite
/// Remove-Migration -Context DbModel_SqliteContext
/// Update-Database -Context DbModel_SqliteContext -Migration 0
/// Update-Database -Context DbModel_SqliteContext
/// </remarks>
public class DbModel_SqliteContext : DbModelContext
{
	public DbModel_SqliteContext(DbContextOptions<DbModelContext> options)
			: base(options)
	{
        GlobalDb.DbType = TargetDbType.Sqlite;
        if (string.Empty == GlobalDb.DbConnectString)
        {
            GlobalDb.DbConnectString = "Data Source=Test.db";
        }
        
    }

	public DbModel_SqliteContext()
	{
	}
}

/// <summary>
/// https://stackoverflow.com/a/60602620/6725889
/// </summary>
public class DbContext_SqliteFactory : IDesignTimeDbContextFactory<DbModel_SqliteContext>
{
	public DbModel_SqliteContext CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<DbModelContext> optionsBuilder
			= new DbContextOptionsBuilder<DbModelContext>();

		return new DbModel_SqliteContext(optionsBuilder.Options);
	}
}
