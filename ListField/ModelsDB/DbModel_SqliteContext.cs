using ListField.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System.Text;

namespace ModelsDB;

public class DbModel_SqliteContext : DbModelContext
{
	public DbModel_SqliteContext(DbContextOptions<DbModelContext> options)
			: base(options)
	{
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

		//Add-Migration InitialCreate -Context ModelsDB.DbModel_SqliteContext -OutputDir Migrations/Sqlite
		GlobalStatic.DbType = "sqlite";
		GlobalStatic.DbConnectString
			= "Data Source=Test.db";

		optionsBuilder.UseSqlite(GlobalStatic.DbConnectString);

		return new DbModel_SqliteContext(optionsBuilder.Options);
	}
}
