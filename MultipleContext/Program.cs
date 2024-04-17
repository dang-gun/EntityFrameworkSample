using Microsoft.EntityFrameworkCore;
using ModelsDB;

namespace EfMultipleContext;

public class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, entity framework Multiple DbContext!");

		//학생 첫 마이그레이션 생성
		//Add-Migration InitialCreate -Context ModelsDB.StudentContext -OutputDir Migrations\StudentMigrations
		//학생 마이그레이션 적용
		using (StudentContext db1 = new StudentContext())
		{
			db1.Database.Migrate();
		}

		//선생 첫 마이그레이션 생성
		//Add-Migration InitialCreate -Context ModelsDB.TeacherContext -OutputDir Migrations\TeacherMigrations
		//선생 마이그레이션 적용
		using (TeacherContext db2 = new TeacherContext())
		{
			db2.Database.Migrate();
		}


		//테스트 데이터 넣기
		using (StudentContext db1 = new StudentContext())
		{
			db1.Students.Add(
				new StudentModel()
				{
					LastName = "s1",
					FirstMidName = "s2",
					EnrollmentDate = DateTime.Now,
				});
			db1.SaveChanges();
		}

		using (TeacherContext db2 = new TeacherContext())
		{
			db2.Database.Migrate();

			db2.Teachers.Add(
				new TeacherModel()
				{
					LastName = "t1",
					FirstMidName = "t2",
					HireDate = DateTime.Now,
				});
			db2.SaveChanges();
		}
	}
}