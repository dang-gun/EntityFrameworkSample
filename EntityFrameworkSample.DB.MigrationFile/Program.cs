using System;

using DGU_ConsoleAssist;
using EntityFrameworkSample.Console;
using EntityFrameworkSample.DB.MigrationFile.TableModels;
using EntityFrameworkSample.DB.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFrameworkSample.DB.MigrationFile;

/// <summary>
/// EntityFrameworkSample.DB와 EntityFrameworkSample.Console을 테스트하기위한 프로젝트
/// 이 프로젝트의 내용을 적절히 복사하여 EF프로젝트에 적용하면 된다.
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Hello, World!");

        GlobalDb.DbStringReload(UseDbType.MariaDB, true);
        using (ModelsDbContext_Mariadb db1 = new ModelsDbContext_Mariadb())
        {
            TestTable temp = db1.TestTable.First();
        }


        //.NET 콘솔 지원
        //https://github.com/dang-gun/DGUtility_DotNet/tree/main/DGU_ConsoleAssist
        ConsoleMenuAssist newCA = new ConsoleMenuAssist();

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


        System.Console.WriteLine("Test select start!");
        List<TestTable> listTemp = new List<TestTable>();
        using (ModelsDbContextTable db1 = new ModelsDbContextTable())
        {
            listTemp = db1.TestTable.ToList();
        }

        for (int i = 0; i < listTemp.Count; ++i)
        {
            TestTable item = listTemp[i];
            System.Console.WriteLine($"[{i}] id:{item.idTestTable}, Int:{item.Int}, Str:{item.Str}");
        }
    }
}
