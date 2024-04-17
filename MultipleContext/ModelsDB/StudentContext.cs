using EfMultipleContext.Global;
using Microsoft.EntityFrameworkCore;


namespace ModelsDB;

public class StudentContext : DbContext
{
#pragma warning disable CS8618
	public virtual DbSet<StudentModel> Students { get; set; }
#pragma warning restore CS8618

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite(GlobalStatic.DBString);
	}
}
