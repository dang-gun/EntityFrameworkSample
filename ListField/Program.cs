using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using EfTest.Models;
using ListField.Global;
using ModelsDB;
using EntityFrameworkSample.Console;
using EntityFrameworkSample.DB;
using ListField.TableModels;
using System.Text;

namespace ListField;

internal class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	static void Main(string[] args)
	{
        Console.WriteLine("Hello, Entity Framework List Field!");
        Console.WriteLine("DB엔진에 따라서 동작이 안되거나 이상하게 될 수 있습니다.");

        //db 선택 받기
        DbConsole consoleMenuDb = new DbConsole();
        consoleMenuDb.DbSelectConsole(UseDbType.All);

        #region 마이그레이션
        //마이그레이션
        //마이그레이션은 마이그레이션을 생성할때 사용한 DbContext를 사용해야 재대로 동작하므로
        //라이브러리화를 할 수 없다.
        System.Console.WriteLine("DB Setting....");

        //DB 정보가 없으면 기본 정보 불러오기
        GlobalDb.DbStringReload(true);


        //db 마이그레이션 적용
        //DB연결 문자열이 없으면 기본값을 사용
        switch (GlobalDb.DBType)
        {
            case UseDbType.SQLite:
                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    //마이그레이션
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.MSSQL:
                using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                {
                    //마이그레이션
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.PostgreSQL:
                using (ModelsDbContext_Postgresql db1 = new ModelsDbContext_Postgresql())
                {
                    //마이그레이션
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.MariaDB:
                using (ModelsDbContext_Mariadb db1 = new ModelsDbContext_Mariadb())
                {
                    //마이그레이션
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.InMemory://InMomey는 마이그레이션 개념이 없다.
            default:
                //동작 없음
                break;
        }
        #endregion

        System.Console.WriteLine("DB Setting complete");
        System.Console.WriteLine("");





        //리스트에 접근하기
        Console.WriteLine("List Info : ");
        List<EfList_Test2> efList_Test2s = new List<EfList_Test2>();

        using (ModelsDbContextTable db3 = new ModelsDbContextTable())
        {
            efList_Test2s = db3.EfList_Test2.ToList();
        }

        Console.WriteLine("List count : " + efList_Test2s.Count);
        Console.WriteLine("-----------------------------");

        StringBuilder sbTemp;
        foreach (EfList_Test2 item in efList_Test2s)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"□□□□□ item : {item.idEfList_Test2} □□□□□");

            sbTemp = new StringBuilder();
            foreach (string itemListString1 in item.ListString1)
            {
                sbTemp.Append(itemListString1 + ",");
            }
            Console.WriteLine($"ListString1 => {sbTemp.ToString()}");

            sbTemp = new StringBuilder();
            foreach (string itemListString2 in item.ListString2)
            {
                sbTemp.Append(itemListString2 + ",");
            }
            Console.WriteLine($"ListString2 => {sbTemp.ToString()}");

            sbTemp = new StringBuilder();
            foreach (JsonTestModel itemListJson1 in item.ListJson1)
            {
                sbTemp.Append($"{itemListJson1.id}(id):{itemListJson1.Name}(Name):{itemListJson1.Age}(Age) ,");
            }
            Console.WriteLine($"ListJson1 => {sbTemp.ToString()}");
        }
    }
}