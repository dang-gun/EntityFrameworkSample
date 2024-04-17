using Microsoft.EntityFrameworkCore;
using ModelsDB;
using System;

namespace EfMultipleContext2;

public class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, entity framework Multiple DbContext!");

		long nBefor = 0;



		//전체 첫 마이그레이션 생성
		//Add-Migration InitialCreate -Context ModelsDB.AllContext -OutputDir Migrations\AllMigrations
		using (AllContext dbAll = new AllContext())
		{
			dbAll.Database.Migrate();
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




		nBefor = DateTime.Now.Ticks;

		using (AllContext dbAll = new AllContext())
		{
			var all
				= (from s in dbAll.Students
				   join t in dbAll.Teachers
					 on s.ID equals t.ID
				   select new { t, s })
					.ToList();


			Console.WriteLine(all);

		}

		//경과 시간 표시
		Console.WriteLine("dbAll join : " + (DateTime.Now.Ticks - nBefor));




		nBefor = DateTime.Now.Ticks;
		using (StudentContext db_1 = new StudentContext())
		{
			using (TeacherContext db_2 = new TeacherContext())
			{
				List<StudentModel> listStu
					= db_1.Students.ToList();

				var all
				= (from s in listStu
				   join t in db_2.Teachers
					 on s.ID equals t.ID
				   select new { t, s })
					.ToList();

				Console.WriteLine(all);
			}
		}

		//경과 시간 표시
		Console.WriteLine("db_1, db_2 join : " + (DateTime.Now.Ticks - nBefor));
	}
}